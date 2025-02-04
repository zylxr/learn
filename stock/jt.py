# 运行环境 
# python:3.11.2
# akshare:1.15.80
# matplotlib: 3.10.0
#注意：低版本的 matplotlib 会导致程序不能运行
import akshare as ak
import pandas as pd
import matplotlib.pyplot as plt
import matplotlib.dates as dates

# 获取江西铜业 2024 年 A 股股票数据
def get_stock_data(symbol, start_date, end_date):
    try:
        df = ak.stock_zh_a_hist(symbol=symbol, start_date=start_date, end_date=end_date, adjust="qfq")
        return df
    except Exception as e:
        print(f"获取股票数据时出错: {str(e)}")
        return None

# 江西铜业股票代码
stock_code = "600362"  # 上海证券交易所代码
start_date = "20240101"
end_date = "20241231"

# 获取数据
jiangxi_copper_data = get_stock_data(stock_code, start_date, end_date)

# 数据清洗与预处理
if jiangxi_copper_data is not None:
    jiangxi_copper_data.columns = [
        "日期", "开盘价", "收盘价", "最高价", "最低价", "成交量", "成交额",
        "振幅", "涨跌幅", "涨跌额", "换手率", "成交笔数"
    ]
    
    jiangxi_copper_data["日期"] = pd.to_datetime(jiangxi_copper_data["日期"])
    jiangxi_copper_data.set_index("日期", inplace=True)

    print("数据清洗完成，无缺失值。")
    print(jiangxi_copper_data.head())  # 检查数据结构
else:
    print("数据为空，无法进行清洗。")

# 股票价格走势
if jiangxi_copper_data is not None:
    plt.figure(figsize=(12, 6))
    plt.plot(jiangxi_copper_data.index, jiangxi_copper_data["收盘价"], label="收盘价")
    plt.title("江西铜业 2024 年股票价格走势")
    plt.xlabel("日期")
    plt.ylabel("价格 (元)")
    plt.legend()
    plt.grid()
    plt.gca().xaxis.set_major_formatter(dates.DateFormatter("%Y-%m-%d"))
    plt.gcf().autofmt_xdate()
    plt.show()

# 移动平均线分析（保持不变）
if jiangxi_copper_data is not None:
    jiangxi_copper_data["MA20"] = jiangxi_copper_data["收盘价"].rolling(window=20).mean()
    jiangxi_copper_data["MA60"] = jiangxi_copper_data["收盘价"].rolling(window=60).mean()

    plt.figure(figsize=(12, 6))
    plt.plot(jiangxi_copper_data.index, jiangxi_copper_data["收盘价"], label="收盘价")
    plt.plot(jiangxi_copper_data.index, jiangxi_copper_data["MA20"], label="20日移动平均线")
    plt.plot(jiangxi_copper_data.index, jiangxi_copper_data["MA60"], label="60日移动平均线")
    plt.title("江西铜业 2024 年移动平均线分析")
    plt.xlabel("日期")
    plt.ylabel("价格 (元)")
    plt.legend()
    plt.grid()
    plt.show()

# 相对强弱指标 (RSI) 分析（保持不变）
if jiangxi_copper_data is not None:
    delta = jiangxi_copper_data["收盘价"].diff()
    gain = (delta.where(delta > 0, 0)).rolling(window=14).mean()
    loss = (-delta.where(delta < 0, 0)).rolling(window=14).mean()
    rs = gain / loss
    jiangxi_copper_data["RSI"] = 100 - (100 / (1 + rs))

    plt.figure(figsize=(12, 6))
    plt.plot(jiangxi_copper_data.index, jiangxi_copper_data["RSI"], label="RSI")
    plt.axhline(y=70, color="r", linestyle="--", label="超买 (70)")
    plt.axhline(y=30, color="g", linestyle="--", label="超卖 (30)")
    plt.title("江西铜业 2024 年 RSI 分析")
    plt.xlabel("日期")
    plt.ylabel("RSI 值")
    plt.legend()
    plt.grid()
    plt.show()