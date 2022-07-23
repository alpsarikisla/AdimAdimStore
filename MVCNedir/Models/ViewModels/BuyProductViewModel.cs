using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCNedir.Models.ViewModels
{
    public class BuyProductViewModel
    {
        [Required(ErrorMessage = "İsim Soyad Boş Bırakılamaz")]
        public string CardName { get; set; }

        [Required(ErrorMessage = "Kart Numarası Boş Bırakılamaz")]
        [StringLength(maximumLength:16, MinimumLength =16, ErrorMessage = "Kart Numarası 16 karakter olmalıdır")]
        [DataType(DataType.CreditCard)]
        public string CardNumber { get; set; }

        [Required(ErrorMessage = "Kart Numarası Boş Bırakılamaz")]
        public string ReqM { get; set; }

        [Required(ErrorMessage = "Kart Numarası Boş Bırakılamaz")]
        public string ReqY { get; set; }

        [Required(ErrorMessage = "Kart Numarası Boş Bırakılamaz")]
        [StringLength(maximumLength: 3, MinimumLength = 3, ErrorMessage = "CVV Numarası 3 karakter olmalıdır")]
        public string Cvv { get; set; }
    }
}