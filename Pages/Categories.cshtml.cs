using FinalGradeCalculatorWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FinalGradeCalculatorWeb.Pages
{
    public class CategoriesModel : PageModel
    {
        private readonly FinalGradeCalculatorWeb.Models.MyDbContext _context;

        public List<Category> Categories { get; set; } = new List<Category>();

        [BindProperty]
        public Category NewCategory { get; set; }

        public CategoriesModel(FinalGradeCalculatorWeb.Models.MyDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            Categories = _context.Categories.ToList();
        }

        public string GetFinalGrade()
        {
            double finalGrade = 0.0;
            foreach (var category in Categories)
            {
                finalGrade += category.Grade * category.Weight / 100;
            }
            return finalGrade.ToString();
        }

        public IActionResult OnPost()
        {
            _context.Categories.Add(NewCategory);
            _context.SaveChanges();
            return RedirectToPage();
        }
    }
}
