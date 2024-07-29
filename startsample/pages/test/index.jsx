// `app/page.tsx` is the UI for the `/` URL
import useSWR from 'swr'

export default function Page() {
  // 定义 fetcher 函数
  const fetcher = async (url) => {
    try {
      const res = await fetch(url);
      if (!res.ok) {
        throw new Error(`Failed to fetch data with status: ${res.status}`);
      }
   
      return res.json(); // 解析响应为 JSON 格式
    } catch (error) {
      console.error('Fetch error:', error);
      throw error; // 重新抛出错误以便 useSWR 处理
    }
  };
    let m = "test home page"
    const { data, error } = useSWR('/api/navigation',fetcher)
    if (!data) {
      return <div>Loading...</div>;
    }
    return (
    <div>
    <h1>Hello, Home page!</h1>
    <h2>Navigation Links</h2>
    <ul>
      {data.data.Links.map((link) => (
        <li key={link.id}>
          {link.name} - <a href={link.link}>{link.link}</a>
        </li>
      ))}
    </ul>
  </div>);
  }