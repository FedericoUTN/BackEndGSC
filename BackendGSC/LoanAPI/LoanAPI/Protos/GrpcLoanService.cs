using Grpc.Core;
using LoadApi.Entities;
using LoanAPI.DataAccess;
using Google.Protobuf.WellKnownTypes;

namespace LoanAPI.Protos
{
    public class GrpcLoanService : LoanService.LoanServiceBase
    {
        //private readonly ILogger<GrpcLoanService> logger;
        private readonly IUnityOfWork uow;
        //ILogger<GrpcLoanService> logger,
        public GrpcLoanService( IUnityOfWork uow)
        {
            //this.logger = logger;
            this.uow = uow;
        }
        //probar con id = 2
        public override async Task<ResponseLoan> ChangeStatusLoan(RequestLoan request, ServerCallContext context)
        {
            var loan = await uow.LoanRepository.GetByIdAsync(request.LoanId);
            if (loan is not null)
            {
                loan.Status = "Devuelto";
                loan.ReturnDate = DateTime.UtcNow;
                uow.LoanRepository.Update(loan);
                await uow.CompleteAsync();
                return await Task.FromResult(new ResponseLoan
                {
                    Success = true,
                    LoanEntity = new LoanGrpc
                    {
                        Id = loan.Id,
                        Status = loan.Status
                    }
                });
            }
            else return await Task.FromResult(new ResponseLoan
            {
                Success = false
            });
            
        }
        public override Task<Res> Test(Req request, ServerCallContext context)
        {
            return Task.FromResult(new Res
            {
                Message = request.Message
            });
        }
    }
}
