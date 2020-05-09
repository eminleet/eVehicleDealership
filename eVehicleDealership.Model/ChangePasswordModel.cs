using System.ComponentModel.DataAnnotations;

namespace eVehicleDealership.Modeli
{
    public class ChangePasswordModel
    {
        public string OldPassword { get; set; }
        [MinLength(8)]
        public string NewPassword { get; set; }
        [Compare("NewPassword")]
        public string PasswordConfirmation { get; set; }
    }
}
