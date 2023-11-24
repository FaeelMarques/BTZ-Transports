using System.ComponentModel.DataAnnotations.Schema;

namespace BTZTransports.Application.Models
{
    public class FuelSupplyHistory: EntityBase
    {
        public int DriverId { get; set; }
        public int VehicleId { get; set; }
        public DateTime Date { get; set; }
        public FuelType FuelType { get; set; }
        public int QuantitySupplied { get; set; }
        public double TotalValueSupplied { get; set; }
        
        [ForeignKey("DriverId")]
        public virtual Driver Driver { get; set; }

        [ForeignKey("VehicleId")]
        public virtual Vehicle Vehicle { get; set; }
    }
}
