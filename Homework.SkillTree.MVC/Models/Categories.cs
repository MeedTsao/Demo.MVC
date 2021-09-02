using System;
using System.ComponentModel.DataAnnotations;


namespace Homework.SkillTree.Models
{
    public enum CategoryEnum
    {
        [Display(Name = "支出")]
        Expend,
        [Display(Name = "收入")]
        Income
    }
    public class Categories
    {
        [Display(Name ="類別")]
        public CategoryEnum Category { get; set; }
        [Display(Name = "金額")]
        public int Money { get; set; }
        [Display(Name = "日期")]
        public DateTime Date { get; set; }
        [Display(Name = "備註")]
        public string Notes { get; set; }
    }
}