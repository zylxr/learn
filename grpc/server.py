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