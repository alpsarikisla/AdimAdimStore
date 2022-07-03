using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCNedir.Models
{
    public class Product
    {
        public int ID { get; set; }

        public int Category_ID { get; set; }

        [ForeignKey("Category_ID")]
        public virtual Category Category { get; set; }

        public int Brand_ID { get; set; }

        [ForeignKey("Brand_ID")]
        public virtual Brand Brand { get; set; }

        [Display(Name = "Ürün Adı")]
        [Required(ErrorMessage = "Bu alan zorunludur")]
        [StringLength(maximumLength:75, ErrorMessage ="bu alan en fazla 75 karkater olmalıdır")]
        public string Name { get; set; }

        [Display(Name = "Açıklama")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "Ürün Resim")]
        [StringLength(maximumLength: 150)]
        public string ImagePath { get; set; }

        [Display(Name = "Stok Adet")]
        public int Stock { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Fiyat")]
        public double Price { get; set; }

        [Display(Name = "Ekleme Tarihi")]
        public DateTime CreationTime { get; set; }

        [Display(Name = "Satış Durum")]
        public bool SellStatus { get; set; }
    }
}