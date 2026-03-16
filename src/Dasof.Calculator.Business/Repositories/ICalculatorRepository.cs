using Dasof.Calculator.Business.Frontend;

namespace Dasof.Calculator.Business.Repositories
{
    public interface ICalculatorRepository
    {
        Task<ResponseModel> CalculateTotalVehiclePrice(RequestModel request);
    }
}