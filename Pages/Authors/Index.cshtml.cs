using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Turcas_Roxana_lab2.Data;
using Turcas_Roxana_lab2.Models;

namespace Turcas_Roxana_lab2.Pages.Authors
{
    public class IndexModel : PageModel
    {
        private readonly Turcas_Roxana_lab2.Data.Turcas_Roxana_lab2Context _context;

        public IndexModel(Turcas_Roxana_lab2.Data.Turcas_Roxana_lab2Context context)
        {
            _context = context;
        }

        public IList<Author> Author { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Author = await _context.Author.ToListAsync();
        }
    }
}
