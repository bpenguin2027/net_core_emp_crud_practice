using System;
using System.Collections.Generic;
// 驗證用 namespace
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EmployeeCrud.Models
{
    public partial class TEmployee
    {
        [Display(Name = "員工編號")]
        [Required(ErrorMessage = "員工編號必填")]
        public string FEmpId { get; set; }

        [Display(Name = "姓名")]
        [Required(ErrorMessage = "姓名必填")]
        public string FName { get; set; }

        [Display(Name = "性別")]
        public string FGender { get; set; }

        [Display(Name = "信箱")]
        [EmailAddress(ErrorMessage = "必須符合信箱格式")]
        public string FMail { get; set; }

        [Display(Name = "薪資")]
        [Range(23000, 65000, ErrorMessage = "薪資範圍23000-65000")]
        public int? FSalary { get; set; }

        [Display(Name = "雇用日期")]
        [DataType(DataType.Date)]
        public DateTime? FEmploymentDate { get; set; }
    }
}