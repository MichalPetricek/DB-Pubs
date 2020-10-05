using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PubBase.Models;
using PubBase.Services;

namespace PubBase.Pages
{
    public class ImputModel : PageModel
    {
        private readonly AppDbContext _db;
        private readonly PubsManager _methods;
        public List<Pub> Pubs { get; set; }
        [BindProperty]
        public Pub Pub { get; set; }
        [BindProperty]
        public string name { get; set; }
        [BindProperty]
        public string address { get; set; }

        public ImputModel(AppDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            _db.Pubs.Add(new Pub { Name = name, Address = address });
            _db.SaveChanges();
            return RedirectToPage("./Index");
            //_methods.Create(Pub);
        }
    }
}
