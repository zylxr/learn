import pandas as pd
#pandas 管道示例
g_encoding='utf8'
g_date_cols=['birthdate']

def load_df():
    return pd.read_csv('data/1.csv',
                       encoding=g_encoding,
                       parse_dates=g_date_cols)
def cal_split_mail(x_df):
    def ay_split_mail(x_s):
        arr = x_s.split('@')
        prefix = arr[0]
        postfix = arr[1]
        return pd.Series((prefix,postfix),index = 'mail_prefix mail_postfix'.split())
    res = x_df['mail'].apply(ay_split_mail)
    x_df[res.columns] = res
    return x_df

def cal_convert_sex(x_df):
    mapping={'M':'男','F':'女'}
    x_df['sex'] = x_df['sex'].map(mapping)
    return x_df

res = (load_df().pipe(cal_split_mail).pipe(cal_convert_sex)
       )
print(res.info())
print(res.head())
