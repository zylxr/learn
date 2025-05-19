# 使用 grpc 示例,python 环境

**1.  python 下安装必要的工具和库**

   ``` python
   pip install grpcio
   pip install grpcio-tools
   pip install protobuf
  ```

  **2.  生成 proto 文件**
  ``` 
        syntax = "proto3";
        package helloworld;

        //定义服务
        service Greeter{
            //发送问候语的方法
            rpc SayHello(HelloRequest) returns (HelloReply){}
        }

        //请求消息格式
        message HelloRequest{
            string name=1;
        }

        //响应消息格式
        message HelloReply{
            string message = 2;
        }





  ```

**3.  生成 python 代码**

  ``` python
  python -m grpc_tools.protoc --python_out=. --grpc_python_out=. helloworld.proto
  ```

**4.  实现服务端和客户端逻辑**
**服务端**
``` python
    from concurrent import futures
    import grpc
    import hello_pb2
    import hello_pb2_grpc

    class Greeter(hello_pb2_grpc.GreeterServicer):
        def SayHello(self, request, context):
            # 打印客户端请求内容
            print(f"[DEBUG] Received request: {request}")

            # 构造响应对象
            response = hello_pb2.HelloReply(message=f'Hello, {request.name}!')

            # 打印发送给客户端的响应
            print(f"[DEBUG] Sending response: {response}")

            return response

    def serve():
        server = grpc.server(futures.ThreadPoolExecutor(max_workers=10))
        hello_pb2_grpc.add_GreeterServicer_to_server(Greeter(), server)
        server.add_insecure_port('[::]:50051')

        print("🚀 Starting gRPC server on port 50051...")
        server.start()

        try:
            server.wait_for_termination()
        except KeyboardInterrupt:
            print("\n🛑 Shutting down gRPC server...")

    if __name__ == '__main__':
        serve()
```

**客户端**
``` python
    import grpc
    import hello_pb2
    import hello_pb2_grpc

    def run():
        with grpc.insecure_channel('localhost:50051') as channel:
            stub = hello_pb2_grpc.GreeterStub(channel)
            response = stub.SayHello(hello_pb2.HelloRequest(name='you'))
        print("Greeter client received: " + response.message)

    if __name__ == '__main__':
        run()
```

**5.  运行服务端和客户端**
运行服务端
``` python
python server.py
```

运行客户端
``` python
python client.py
Greeter client received: Hello, you!
```
**6.  运行结果**
``` python
Greeter client received: Hello, you!
```

