using BookDiariesWebRazor_Temp.Data;
using BookDiariesWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookDiariesWebRazor_Temp.Pages.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly AppDbContext _db;
        public Category Category { get; set; }
        public EditModel(AppDbContext db)
        {
            _db = db;
        }
        public void OnGet(int? Id)
        {
            Category = _db.Categories.Find(Id);
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(Category);
                _db.SaveChanges();
                TempData["SuccessMessage"] = "Category updated successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }

    }
}
