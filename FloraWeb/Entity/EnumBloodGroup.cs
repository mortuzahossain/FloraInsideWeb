using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FloraWeb.Entity
{
    public enum EnumBloodGroup
    {
        [Display(Name = "A+")]
        APositive,
        [Display(Name = "A-")]
        ANegative,
        [Display(Name = "B+")]
        BPositive,
        [Display(Name = "B-")]
        BNegative,
        [Display(Name = "AB+")]
        ABPositive,
        [Display(Name = "AB-")]
        ABNegative,
        [Display(Name = "O+")]
        OPositive,
        [Display(Name = "O-")]
        [Description("O-")]
        ONegative,
    }
}