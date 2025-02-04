import akshare as ak

# 获取江西铜业的股票历史行情数据
stock_data = ak.stock_zh_a_hist(symbol="600362", start_date="20240101", end_date="20250201", adjust="qfq")

print(stock_data.head())


import akshare as ak

# 获取中国的GDP数据
gdp_data = ak.macro_china_gdp()

print(gdp_data)


import akshare as ak

fund_code = "161725"  # 示例代码
fund_info = ak.fund_individual_basic_info_xq(symbol=fund_code)
print(fund_info)