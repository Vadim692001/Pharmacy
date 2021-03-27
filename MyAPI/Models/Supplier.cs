
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyAPI.Models
{
    public class Supplier
    {
        public int IdSupplier { get; set; }
        [Display(Name = "Назва постачальника")]
        [Required(ErrorMessage =
            "Потрібно заповнити поле \'Назва постачальника\'")]
        [StringLength(30, MinimumLength = 1,
            ErrorMessage = "Назва постачальника  "
            + "повинно містити від 1 до 30 символів")]
        public string NameSupplier { get; set; }
        [Display(Name = "Місто постачальника")]
        [Required(ErrorMessage =
          "Потрібно заповнити поле \'Місто постачальника\'")]
        [StringLength(30, MinimumLength = 1,
          ErrorMessage = "Місто постачальника  "
          + "повинно містити від 1 до 30 символів")]
        public string CitySupplier { get; set; }
        [Display(Name = "Країна постачальника")]
        [Required(ErrorMessage =
          "Потрібно заповнити поле \'Країна постачальника\'")]
        [StringLength(30, MinimumLength = 3,
          ErrorMessage = "Країна постачальника  "
          + "повинно містити від 3 до 30 символів")]
        public string CountrySupplier { get; set; }


    }
}
