using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyAPI.Models
{
    public class Goods
    {
        public int IdGoods { get; set; }
        [Display(Name = "Назва товару")]
        [Required(ErrorMessage =
           "Потрібно заповнити поле \'Назва товару\'")]
        [StringLength(60, MinimumLength = 3,
           ErrorMessage = "Назва товару  "
           + "повинно містити від 3 до 60 символів")]
        public string NameGoods { get; set; }
        [Display(Name = "Кількість товару")]
        [Range(1, 999)]
        [Required(ErrorMessage =
       "Потрібно заповнити поле \'Кількість товару від 1 до 400\'")]
        public int CountGoods { get; set; }
        [Display(Name = "Ціну товару")]
        [Range(1, 10000)]
        [Required(ErrorMessage =
        "Потрібно заповнити поле \'Ціну товару від 1 до 10000\'")]
        public  decimal PriceGoods { get; set; }
        public string PhotoGoods { get; set; }
    }
}
