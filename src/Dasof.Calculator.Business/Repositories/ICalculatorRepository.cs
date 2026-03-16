using Dasof.Calculator.Business.Common;

namespace Dasof.Calculator.Business.Repositories
{
    public interface ICalculatorRepository
    {
        Task<ResponseModel> CalculateTotalVehiclePrice(RequestModel request);
    }
}
