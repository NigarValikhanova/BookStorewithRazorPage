using BookDiariesWebRazor_Temp.Data;
using BookDiariesWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookDiariesWebRazor_Temp.Pages.Categories
{
    [BindProperties]

    public class CreateModel : PageModel
    {
        private readonly AppDbContext _db;
        public Category Category { get; set; }
        public CreateModel(AppDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            _db.Categories.Add(Category);
            _db.SaveChanges();
            TempData["SuccessMessage"] = "Category created successfully";
            return RedirectToPage("Index");
        }
    }
}
