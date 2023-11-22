﻿using Microsoft.AspNetCore.Mvc.RazorPages;
using CO5227_Assignment.Data;
using CO5227_Assignment.wwwroot.Models;
using Microsoft.EntityFrameworkCore;

namespace CO5227_Assignment.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        private readonly CO5227_AssignmentContext _context;

        public IndexModel(CO5227_AssignmentContext context) {
        _context = context;
        }

        public IList<MenuItems> MenuItem { get; set; } = default!;
        public void OnGet()
        {
            MenuItem = _context.MenuItemss.FromSqlRaw("Select * From MenuItems").ToList();
        }
    }
}