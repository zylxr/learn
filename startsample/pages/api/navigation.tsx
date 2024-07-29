// pages/api/users.js
export default function handler(req, res) {
    // 获取请求方法
    const { method } = req;
  
    switch (method) {
      case 'GET':
        // 返回一组用户数据
        return res.status(200).json({
          "data": {
            "Links": [
              { "id": 1, "name": "John Doe", "link": "http://john.com" },
              { "id": 2, "name": "Jane Doe", "link": "http://jane.com" }
            ]
          },
          "error": null
    });
      default:
        // 如果请求方法不被支持，则返回 405 Method Not Allowed
        return res.status(405).end(`Method ${method} Not Allowed`);
    }
  }