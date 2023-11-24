namespace BTZTransports.Application.Models
{
    public class Vehicle : EntityBase
    {
        public string Plate { get; set; }
        public string Name { get; set; }
        public string? Observations { get; set; }
        public FuelType FuelType { get; set; }
        public string Manufacturer { get; set; }
        public int ManufactureYear { get; set; }
        public int FuelCapacity { get; set; }
    }
}
