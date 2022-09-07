using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Shared.ViewModel
{
    public class UnitInfoView
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "نام مالک الزامی می باشد.")]
        public string NameFamilyMalek { get; set; } = string.Empty;
        [Required(ErrorMessage = "شماره واحد الزامی می باشد.")]
        public string NumberUnit { get; set; } = string.Empty;
        public string NumberParking { get; set; } = string.Empty;
        private bool _isresidence = true;
        public bool isResidence { get { return _isresidence; } set {
                _isresidence = value;
                if (!value)
                {
                    MalekIsThere = true;
                    NameFamilyMostajer = string.Empty;
                    MobileMostajer = string.Empty;
                }
            } } // true mineshinan - false khali ast

        private bool _malekisthere = true;
        public bool MalekIsThere { get { return _malekisthere; } set {
                _malekisthere = value;
                if (value)
                {
                    NameFamilyMostajer = string.Empty;
                    MobileMostajer = string.Empty;
                }
            } } // true malek mishine - false mostaje
        public string NameFamilyMostajer { get; set; } = string.Empty;
        [Required(ErrorMessage = "موبایل مالک الزامی می باشد.")]
        [RegularExpression("(^09[0-9]{9})$", ErrorMessage = "فرمت شماره همراه مالک اشتباه می باشد.")]
        public string MobileMalek { get; set; } = string.Empty;
        [RegularExpression("(^09[0-9]{9})$", ErrorMessage = "فرمت شماره همراه مستاجر اشتباه می باشد.")]
        public string MobileMostajer { get; set; } = string.Empty;

        public bool isActive { get; set; } = true;

        public string Password { get; set; } = string.Empty;

    }
}
