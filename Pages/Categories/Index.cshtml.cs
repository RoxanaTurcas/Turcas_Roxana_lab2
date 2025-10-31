using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Turcas_Roxana_lab2.Data;
using Turcas_Roxana_lab2.Models;
using Turcas_Roxana_lab2.Models.ViewModels;

namespace Turcas_Roxana_lab2.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Turcas_Roxana_lab2.Data.Turcas_Roxana_lab2Context _context;

        public IndexModel(Turcas_Roxana_lab2.Data.Turcas_Roxana_lab2Context context)
        {
            _context = context;
        }

        public IList<Category> Category { get; set; } = default!;

        public int CategoryID { get; set; }
        public int BookID { get; set; }

        public string CurrentFilter { get; set; }

        public Category SelectedCategory { get; set; } = default!;


        public async Task OnGetAsync(int? id, int? bookID, string searchString)
        {
            CurrentFilter = searchString;

            Category = await _context.Category
                .Include(c => c.BookCategories)
                    .ThenInclude(bc => bc.Book)
                        .ThenInclude(b => b.Author)
                .OrderBy(c => c.CategoryName)
                .ToListAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                foreach (var category in Category)
                {
                    category.BookCategories = category.BookCategories
                        .Where(bc => bc.Book.Title.Contains(searchString) ||
                                     bc.Book.Author.FirstName.Contains(searchString) ||
                                     bc.Book.Author.LastName.Contains(searchString))
                        .ToList();
                }
            }

            if (id != null)
            {
                CategoryID = id.Value;
                SelectedCategory = await _context.Category
        .Include(c => c.BookCategories)
            .ThenInclude(bc => bc.Book)
                .ThenInclude(b => b.Author)
        .Include(c => c.BookCategories)
            .ThenInclude(bc => bc.Book)
                .ThenInclude(b => b.Publisher)
        .SingleOrDefaultAsync(c => c.ID == id.Value);
            }
        }
    }
}
