using GrpcServiceApp.Services;

namespace gRPC_traslator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddGrpc();
            var app = builder.Build();

            app.MapGet("/", () => "Hello World!");
            app.MapGrpcService<TranslatorService>();
            app.Run();
        }
    }
}