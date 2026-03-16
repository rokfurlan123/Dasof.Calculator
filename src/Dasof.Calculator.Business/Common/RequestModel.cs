namespace Dasof.Calculator.Business.Common
{
    public class RequestModel
    {
        public decimal? Vat { get; set; }
        public decimal? BaseVehiclePriceNeto { get; set; }
        public decimal? BaseVehiclePriceBruto { get; set; }
        public bool? IsBaseVehiclePriceNetoSelected { get; set; }
        public decimal? AdditionalEquipmentPriceNeto { get; set; }
        public decimal? AdditionalEquipmentPriceBruto { get; set; }
        public bool? IsAdditionalEquipmentNetoSelected { get; set; }
    }
}
