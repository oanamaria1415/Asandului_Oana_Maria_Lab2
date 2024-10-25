using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Asandului_Oana_Maria_Lab2.Data;
using Asandului_Oana_Maria_Lab2.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Asandului_Oana_Maria_Lab2.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly Asandului_Oana_Maria_Lab2.Data.Asandului_Oana_Maria_Lab2Context _context;

        public IndexModel(Asandului_Oana_Maria_Lab2.Data.Asandului_Oana_Maria_Lab2Context context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; } = default!;

        public async Task OnGetAsync(int? AuthorID)
        {
            ViewData["Authors"] = new SelectList(await _context.Set<Author>().ToListAsync(), "ID", "FullName");
            Book = await _context.Book
                .Include(b => b.Publisher)
                .ToListAsync();
        }
    }
}
