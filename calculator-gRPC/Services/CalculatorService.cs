using Grpc.Core;
using calculator_gRPC.eee;

namespace calculator_gRPC.Services
{
    public class CalculatorService : Calculator.CalculatorBase
    {
        private readonly ILogger<CalculatorService> _logger;
        public CalculatorService(ILogger<CalculatorService> logger)
        {
            _logger = logger;
        }

        public override Task<CalcResponse> DoCalculation(CalcRequest request, ServerCallContext context)
        {
            int result;
            switch (request.Operation.ToLower())
            {
                case "add":
                    result = request.X + request.Y;
                    break;
                case "subtract":
                    result = request.X - request.Y;
                    break;
                case "multiply":
                    result = request.X * request.Y;
                    break;
                case "divide":
                    if (request.Y != 0)
                        result = request.X / request.Y;
                    else
                        throw new RpcException(new Status(StatusCode.InvalidArgument, "Cannot divide by zero"));
                    break;
                default:
                    throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid operation"));
            }

            var response = new CalcResponse { Z = result };
            return Task.FromResult(response);
        }
    }
}
