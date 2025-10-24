using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Turcas_Roxana_lab2.Data;
using Turcas_Roxana_lab2.Models;

namespace Turcas_Roxana_lab2.Pages.Books
{
    public class CreateModel : PageModel
    {
        private readonly Turcas_Roxana_lab2.Data.Turcas_Roxana_lab2Context _context;

        public CreateModel(Turcas_Roxana_lab2.Data.Turcas_Roxana_lab2Context context)
        {
            _context = context;
        }
        public SelectList Authors { get; set; }


    
     public IActionResult OnGet()
        {
            ViewData["PublisherID"] = new SelectList(_context.Set<Publisher>(), "ID", "PublisherName");

            var authorsList = _context.Author
                .OrderBy(a => a.LastName)
                .ThenBy(a => a.FirstName)
                .Select(a => new { a.ID, FullName = a.FirstName + " " + a.LastName })
                .ToList();

            Authors = new SelectList(authorsList, "ID", "FullName");

            return Page();
        }

        [BindProperty]
        public Book Book { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Book.Add(Book);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
