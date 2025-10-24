using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Turcas_Roxana_lab2.Models;

namespace Turcas_Roxana_lab2.Data
{
    public class Turcas_Roxana_lab2Context : DbContext
    {
        public Turcas_Roxana_lab2Context(DbContextOptions<Turcas_Roxana_lab2Context> options)
            : base(options)
        {

        }

        public DbSet<Turcas_Roxana_lab2.Models.Book> Book { get; set; } = default!;
        public DbSet<Turcas_Roxana_lab2.Models.Publisher> Publisher { get; set; } = default!;

        public DbSet<Turcas_Roxana_lab2.Models.Author> Author { get; set; } = default!;

    }
}
