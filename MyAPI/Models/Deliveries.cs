
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyAPI.Models
{
    public class Deliveries
    {
        public int IdOperation { get; set; }
        public Employees IdEmployees { get; set; }
        public Goods IdGoods { get; set; }
        public Supplier IdSupplier { get; set; }
        [Display(Name = "Кількість товару")]
        [Range(1, 999)]
        [Required(ErrorMessage =
       "Потрібно заповнити поле \'Кількість товару від 1 до 400\'")]
        public int CountDeliveries { get; set; }
        [Display(Name = "Ціну закупки товару")]
        [Range(1, 10000)]
        [Required(ErrorMessage =
      "Потрібно заповнити поле \'Ціну закупки товару від 1 до 10000\'")]
        public decimal PricePurchase { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy/  }", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата ")]
        [Required(ErrorMessage =
         "Потрібно заповнити поле \'Дата \'")]
        public string Data { get; set; }

      


    }


}
