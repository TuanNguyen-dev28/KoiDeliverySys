using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiDelivery.Repositories.Entities;

namespace KoiDelivery.WebApp.Pages.Account
{
    public class CreateModel : PageModel
    { 
        // Sai kien truc 3 lop
        // App -> Services -> Repositories
        // cham project neu nhom nao lam khong dung 0 diem
        private readonly KoiDelivery.Repositories.Entities.TaiKhoanContext _context;

        public CreateModel(KoiDelivery.Repositories.Entities.TaiKhoanContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public TaiKhoanKhachHang TaiKhoanKhachHang { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TaiKhoanKhachHangs.Add(TaiKhoanKhachHang);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
