namespace BTZTransports.Application.Models
{
    public class Driver : EntityBase
    {
        public string Name { get; set; }
        public string CPF { get; set; }
        public string CnhNumber { get; set; }
        public string CnhCategory { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Active { get; set; }
    }
}
