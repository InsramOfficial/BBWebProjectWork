using BBWebProject.Data;
using BBWebProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BBWebProject.Pages.Issues.Items
{
    public class AddItemModel : PageModel
    {
        private readonly BBWebDbContext db;
        private readonly IWebHostEnvironment env;

        [BindProperty]
        public Non_Variated_Items items { get; set; }
        public List<Category>? categories { get; set; }
        public string Name = "";
        public AddItemModel(BBWebDbContext _db, IWebHostEnvironment _env)
        {
            db = _db;
            env = _env;
        }
        public void OnGet()
        {
            categories = db.tbl_category.ToList();
            Name = HttpContext.Session.GetString("Name");
        }
        public IActionResult OnPostCreate() 
        {
            if (ModelState.IsValid)
            {
                Non_Variated_Items newitem = new();
                newitem.Title = items.Title;
                newitem.Description = items.Description;
                newitem.Price = items.Price;
                newitem.CategoryId = items.CategoryId;
                newitem.Image = items.Photo.FileName;

                var folder = Path.Combine(env.WebRootPath, "images");
                var imagepath = Path.Combine(folder, items.Photo.FileName);
                items.Photo.CopyTo(new FileStream(imagepath, FileMode.Create));

                db.tbl_non_variated_items.Add(newitem);
                db.SaveChanges();
                return RedirectToPage("Index");
            }

            return RedirectToPage("AddItem");
        }

    }
}
