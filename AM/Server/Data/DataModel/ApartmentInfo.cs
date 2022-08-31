using System.ComponentModel.DataAnnotations;

namespace AM.Server.Data.DataModel
{
    public class ApartmentInfo
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public int UnitNumber { get; set; }
    }
}
