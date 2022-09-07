using System.ComponentModel.DataAnnotations;

namespace AM.Server.Data.DataModel
{
    public class UnitInfo
    {
        [Key]
        public int Id { get; set; }
        public string NameFamilyMalek { get; set; } = string.Empty;
        public string NumberUnit { get; set; } = string.Empty;
        public string NumberParking { get; set; } = string.Empty;
        public bool isResidence { get; set; } // true mineshinan - false khali ast
        public bool MalekIsThere { get; set; } // true malek mishine - false mostaje
        public string NameFamilyMostajer { get; set; } = string.Empty;
        public string MobileMalek { get; set; } = string.Empty;
        public string MobileMostajer { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
        public DateTime? LastLogin { get; set; }
        public string IPAddress { get; set; } = string.Empty;
        public string Device { get; set; } = string.Empty;

        public bool isActive { get; set; } = true;

        public DateTime CreateAt { get; set; }


        public UnitInfo()
        {
            CreateAt = DateTime.Now;
        }
    }
}
