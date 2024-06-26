using BBWebProject.Data;
using BBWebProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BBWebProject.Pages.Issues.Testimonials
{
    public class IndexModel : PageModel
    {
        private readonly BBWebDbContext db;
        public Testimonial testimonial { get; set; }
        public List<Testimonial> testimonials { get; set; }
        public string Name = "";
        public IndexModel(BBWebDbContext _db)
        {
            db = _db;
        }
        public void OnGet()
        {
            testimonials = db.tbl_testimonials.ToList();
            Name = HttpContext.Session.GetString("Name");
        }

        public IActionResult OnPostDelete(int id)
        {
            testimonial = db.tbl_testimonials.Find(id);
            db.tbl_testimonials.Remove(testimonial);
            db.SaveChanges();
            return RedirectToPage("Index");
        }
        public IActionResult OnPostLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("/Issues/Login");
        }
    }
}
