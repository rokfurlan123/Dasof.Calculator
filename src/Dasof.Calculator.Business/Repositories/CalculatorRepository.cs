using Dasof.Calculator.Business.Common;

namespace Dasof.Calculator.Business.Repositories
{
    public class CalculatorRepository : ICalculatorRepository
    {
        public async Task<ResponseModel> CalculateTotalVehiclePrice(RequestModel request)
        {
            decimal vat = request.Vat!.Value;
            decimal multiplier = 1 + (vat / 100m);

            decimal baseNeto;
            decimal baseBruto;

            if (request.IsBaseVehiclePriceNetoSelected!.Value)
            {
                baseNeto = request.BaseVehiclePriceNeto!.Value;
                baseBruto = baseNeto * multiplier;
            }
            else
            {
                baseBruto = request.BaseVehiclePriceBruto!.Value;
                baseNeto = baseBruto / multiplier;
            }

            decimal equipmentNeto;
            decimal equipmentBruto;

            if (request.IsAdditionalEquipmentNetoSelected!.Value)
            {
                equipmentNeto = request.AdditionalEquipmentPriceNeto!.Value;
                equipmentBruto = equipmentNeto * multiplier;
            }
            else
            {
                equipmentBruto = request.AdditionalEquipmentPriceBruto!.Value;
                equipmentNeto = equipmentBruto / multiplier;
            }

            return new ResponseModel
            {
                BaseVehiclePriceNeto = Math.Round(baseNeto, 2),
                BaseVehiclePriceBruto = Math.Round(baseBruto, 2),
                AdditionalEquipmentPriceNeto = Math.Round(equipmentNeto, 2),
                AdditionalEquipmentPriceBruto = Math.Round(equipmentBruto, 2),
                TotalVehiclePriceNeto = Math.Round(baseNeto + equipmentNeto, 2),
                TotalVehiclePriceBruto = Math.Round(baseBruto + equipmentBruto, 2)
            };
        }
    }
}
