using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class ApplicationUser : IdentityUser
{
    [Required]
    [Display(Name = "First name")]
    [ProtectedPersonalData]
    public string FirstName { get; set; } = null!;

    [Required]
    [Display(Name = "Last name")]
    [ProtectedPersonalData]
    public string LastName { get; set; } = null!;

    public string? UserBasicInfoId { get; set; }
    public UserBasicInfo? BasicInfo { get; set; }
    public string? UserAddressId { get; set; }
    public UserAddress? UserAddress { get; set; }
}
