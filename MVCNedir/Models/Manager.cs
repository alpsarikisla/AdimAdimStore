using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCNedir.Models
{
    public class Manager
    {
        public int ID { get; set; }

        public int ManagerType_ID { get; set; }

        [ForeignKey("ManagerType_ID")]
        public virtual ManagerType ManagerType { get; set; }

        [Required(ErrorMessage = "Bu alan Zorunludur")]
        [StringLength(maximumLength:50, ErrorMessage ="Bu alan en fazla 50 karakter olmalıdır")]
        public string Name { get; set; }

        [StringLength(maximumLength: 50, ErrorMessage = "Bu alan en fazla 50 karakter olmalıdır")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Bu alan Zorunludur")]
        [StringLength(maximumLength: 110, ErrorMessage = "Bu alan en fazla 110 karakter olmalıdır")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Bu alan Zorunludur")]
        public string Password { get; set; }

        public bool Status { get; set; }
    }
}