# akshare github 地址：
https://github.com/akfamily/akshare

# akshare 文档地址
https://akshare.akfamily.xyz/data/

AkShare 是一个面向 Python 的开源财经数据接口库，旨在为金融、经济研究等领域提供高效的数据获取和处理工具。它提供了丰富的金融市场数据，包括但不限于股票、期货、基金、宏观数据等，并且支持多种数据源。

## 安装 AkShare

在使用 AkShare 之前，首先需要安装它。可以通过 pip 来安装：

```bash
pip install akshare
```

## 基本使用示例

### 获取股票数据

下面是一个简单的例子，展示如何使用 AkShare 获取中国A股市场的某只股票的历史行情数据。

```python
import akshare as ak

# 获取江西铜业的股票历史行情数据
stock_data = ak.stock_zh_a_hist(symbol="600362", start_date="20240101", end_date="20250201", adjust="qfq")

print(stock_data.head())
```

在这个例子中，我们通过 `ak.stock_zh_a_hist` 函数获取了股票代码为"600362"（即江西铜业）从2024年1月1日到2025年2月1日的前复权历史行情数据。

### 获取宏观经济数据

除了股票数据，AkShare 还可以用来获取宏观经济数据。例如，我们可以用它来获取中国的GDP数据：

```python
import akshare as ak

# 获取中国的GDP数据
gdp_data = ak.macro_china_gdp()

print(gdp_data)
```

这个例子展示了如何获取中国的季度GDP数据。

### 获取基金数据

同样地，获取基金数据也是十分方便的：

```python
import akshare as ak

fund_code = "161725"  # 示例代码
fund_info = ak.fund_individual_basic_info_xq(symbol=fund_code)
print(fund_info)
```

这里，我们通过 `ak.fund_individual_basic_info_xq` 函数获取了基金代码为"161725"的单位净值走势数据。
