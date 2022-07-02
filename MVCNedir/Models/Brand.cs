using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCNedir.Models
{
    public class Brand
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        [Display(Name ="Marka Adı")]
        [StringLength(maximumLength: 75, ErrorMessage = "Bu alan en fazla 75 karakter olmalıdır")]
        public string Isim { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}