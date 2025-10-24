using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Turcas_Roxana_lab2.Data;
using Turcas_Roxana_lab2.Models;

namespace Turcas_Roxana_lab2.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly Turcas_Roxana_lab2.Data.Turcas_Roxana_lab2Context _context;

        public IndexModel(Turcas_Roxana_lab2.Data.Turcas_Roxana_lab2Context context)
        {
            _context = context;
        }

        public IList<Book> Book { get; set; } = default!;
        public SelectList Authors { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? SelectedAuthorId { get; set; }

        public async Task OnGetAsync()
        {
            var authorsList = await _context.Author
       .OrderBy(a => a.LastName)
       .ThenBy(a => a.FirstName)
       .Select(a => new
       {
           a.ID,
           FullName = a.FirstName + " " + a.LastName
       })
       .ToListAsync();

            Authors = new SelectList(authorsList, "ID", "FullName");

            var booksQuery = _context.Book
               .Include(b => b.Publisher)
               .Include(b => b.Author)
               .AsQueryable();
            if (SelectedAuthorId.HasValue)
            {
                booksQuery = booksQuery.Where(b => b.AuthorId == SelectedAuthorId.Value);
            }

            Book = await booksQuery.ToListAsync();

        }
    } }


