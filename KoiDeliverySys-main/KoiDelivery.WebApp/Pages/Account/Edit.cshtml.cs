using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KoiDelivery.Repositories.Entities;

namespace KoiDelivery.WebApp.Pages.Account
{
    public class EditModel : PageModel
    {
        private readonly KoiDelivery.Repositories.Entities.TaiKhoanContext _context;

        public EditModel(KoiDelivery.Repositories.Entities.TaiKhoanContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TaiKhoanKhachHang TaiKhoanKhachHang { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taikhoankhachhang =  await _context.TaiKhoanKhachHangs.FirstOrDefaultAsync(m => m.AccId == id);
            if (taikhoankhachhang == null)
            {
                return NotFound();
            }
            TaiKhoanKhachHang = taikhoankhachhang;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TaiKhoanKhachHang).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaiKhoanKhachHangExists(TaiKhoanKhachHang.AccId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TaiKhoanKhachHangExists(int id)
        {
            return _context.TaiKhoanKhachHangs.Any(e => e.AccId == id);
        }
    }
}
