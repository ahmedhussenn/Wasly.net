using System.ComponentModel.DataAnnotations;

namespace Wasly.net.ViewModels
{
    public class LoginModel
    {
        [Required]
        public string username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}
