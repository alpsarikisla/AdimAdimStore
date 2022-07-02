using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCNedir.Models
{
    public class ManagerType
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        [StringLength(maximumLength: 75, ErrorMessage = "Bu alan en fazla 75 karakter olmalıdır")]
        public string Name { get; set; }

        public virtual ICollection<Manager> Managers { get; set; }
    }
}