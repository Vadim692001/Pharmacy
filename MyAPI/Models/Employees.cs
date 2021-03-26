using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyAPI.Models
{
    public class Employees
    {
        public int IdEmployees { get; set; }
        [Display(Name = "Прізвище працівника")]
        [Required(ErrorMessage =
           "Потрібно заповнити поле \'Прізвище працівника\'")]
        [StringLength(30, MinimumLength = 3,
           ErrorMessage = "Прізвище  працівника  "
           + "повинно містити від 3 до 30 символів")]
        public string SuernameEmployees { get; set; }
        [Display(Name = "Ім'я працівника")]
        [Required(ErrorMessage =
          "Потрібно заповнити поле \'Ім'я працівника\'")]
        [StringLength(30, MinimumLength = 3,
          ErrorMessage = "Ім'я  працівника  "
          + "повинно містити від 3 до 30 символів")]
        public string NameEmployees { get; set; }
        [Display(Name = "По батькові працівника")]
        [Required(ErrorMessage =
        "Потрібно заповнити поле \'По батькові працівника\'")]
        [StringLength(30, MinimumLength = 3,
        ErrorMessage = "По батькові працівника  "
        + "повинно містити від 3 до 30 символів")]
        public string MiddleNameEmployees { get; set; }
        

        [Display(Name = "Посада працівника")]
        [Required(ErrorMessage =
       "Потрібно заповнити поле \'Посада працівника\'")]
        [StringLength(30, MinimumLength = 3,
       ErrorMessage = "Посада працівника  "
       + "повинно містити від 3 до 30 символів")]
        public string Posada { get; set; }

    }
}
