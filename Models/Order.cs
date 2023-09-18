using System.ComponentModel.DataAnnotations;

namespace Wasly.net.Models
{
    public class Order
    {
        
        public int Id { get; set; }
        [Required] 
        
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public String ClientId { get; set; }    

        public String? EmployeeId { get; set; }

       
        public DateTime Released_Date { get; set;} = DateTime.Now;

     
        public DateTime Delivered_Date { get; set;}

        [Required]
        public String Pickup_Address { get; set; }
        [Required]
        public String Destination_Address { get; set; }
    }
}
