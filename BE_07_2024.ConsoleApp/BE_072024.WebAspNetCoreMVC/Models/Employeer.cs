using System.ComponentModel.DataAnnotations;

namespace BE_072024.WebAspNetCoreMVC.Models
{
    public class Employeer
    {
        [Required(ErrorMessage = "Vui lòng nhập Firstname")]
        [StringLength(100, ErrorMessage = "Firstname khong duoc qua 100 ky tu")]
        [MaxLength(20)]
        public string? Firstname { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập LastName")]
        [StringLength(100, ErrorMessage = "LastName khong duoc qua 100 ky tu")]
        [MaxLength(20)]
        public string? LastName { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập Email")]
        [StringLength(100, ErrorMessage = "Email khong duoc qua 100 ky tu")]
        [MaxLength(20)]
        [EmailAddress(ErrorMessage ="Vui lòng nhập định dạng email")]
        public string? Email { get; set; }

    }

    public class Employeer1
    {
       
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

    }

    

}
