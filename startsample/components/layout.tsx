// import Navbar from './navbar'
// import Footer from './footer'
import useSWR from 'swr'
import Link from 'next/link'
// 定义 fetcher 函数
const fetcher = async (url) => {
  try {
    const res = await fetch(url);
    if (!res.ok) {
      throw new Error('Failed to fetch data');
    }
    return res.json(); // 解析响应为 JSON 格式
  } catch (error) {
    console.error('Fetch error:', error);
    throw error; // 重新抛出错误以便 useSWR 处理
  }
};

export default function Layout({ children }) {
  // const { data, error } = useSWR('/api/navigation')
  // if (error) return <div>Failed to load</div>
  // if (!data) return <div>Loading...</div>
  return (
    <>
      {/* <Navbar /> */}
      <main>root layout : {children} Hello</main>
      {/* <Link href={data.Links??''}>
            data.Links
        </Link> */}
      {/* <Footer /> */}
    </>
  )
}