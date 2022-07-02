using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCNedir.Models.ViewModels
{
    public class ManagerViewModel
    {
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage ="Mail Boş Bırakılamaz")]
        public string Mail { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Şifre Boş Bırakılamaz")]
        public string Password { get; set; }
    }
}