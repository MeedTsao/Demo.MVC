using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Homework.SkillTree.Models
{
    public enum CategoryEnum
    {
        [Display(Name = "支出")]
        Expend,
        [Display(Name = "收入")]
        Income
    }
    public class CategoriesViewModel
    {
        [Required]
        [Display(Name = "類別")]
        public CategoryEnum Category { get; set; }
        [Required]
        [Display(Name = "金額")]
        [RegularExpression(@"^[0-9]*[1-9][0-9]*$", ErrorMessage = "金額請輸入正整數")]
        public int Money { get; set; }
        [Required]
        [Display(Name = "日期")]
        [DataType(DataType.Date)]
        [Remote("CheckDate", "Validate","", ErrorMessage ="日期不能大於今日")]
        public DateTime Date { get; set; }
        [Required]
        [Display(Name = "備註")]
        [StringLength(100)]
        public string Notes { get; set; }
    }
}