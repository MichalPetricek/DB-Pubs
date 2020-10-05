using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using PubBase.Models;

namespace PubBase.Pages
{
    public class DetailModel : PageModel
    {
        private readonly AppDbContext _db;
        public Pub Pub { get; set; }

        public DetailModel(AppDbContext db)
        {
            _db = db;
        }
        public ActionResult OnGet(int? id = null)
        {
            Pub = _db.Pubs.SingleOrDefault(p => p.Id == id);
            if (Pub == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
