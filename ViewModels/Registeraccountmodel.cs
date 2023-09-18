using System.ComponentModel.DataAnnotations;

namespace Wasly.net.ViewModels
{
    public class Registeraccountmodel
    {
        [Required]
        public string username { get; set; }



        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string confirmpassword { get; set; }

 

    }
}
