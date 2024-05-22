using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace AgencyProject.ViewModels
{
    public class AdminLoginVm
    {
        [Required]
        [MaxLength(10)]
        [MinLength(3)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(10)]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
