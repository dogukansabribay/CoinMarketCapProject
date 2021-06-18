using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
   public class User:IEntity
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage ="Ad boş geçilemez")]
        [Display(Name ="Adınız")]
        public string FirstName { get; set; }

        [Required(ErrorMessage ="Soyad boş geçilemez")]
        [Display(Name = "Soyadınız")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Kullanıcı Adı")]
        [MinLength(2,ErrorMessage ="Kullanıcı adı 2 karakterden az olamaz")]
        public string UserName { get; set; }


        [Required]
        [Display(Name = "Şifre")]
        public string Password { get; set; }
    }
}
