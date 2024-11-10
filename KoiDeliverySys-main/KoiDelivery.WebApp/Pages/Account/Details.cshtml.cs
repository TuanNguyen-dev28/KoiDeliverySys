using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiDelivery.Repositories.Entities;

namespace KoiDelivery.WebApp.Pages.Account
{
    public class DetailsModel : PageModel
    {
        private readonly KoiDelivery.Repositories.Entities.TaiKhoanContext _context;

        public DetailsModel(KoiDelivery.Repositories.Entities.TaiKhoanContext context)
        {
            _context = context;
        }

        public TaiKhoanKhachHang TaiKhoanKhachHang { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taikhoankhachhang = await _context.TaiKhoanKhachHangs.FirstOrDefaultAsync(m => m.AccId == id);
            if (taikhoankhachhang == null)
            {
                return NotFound();
            }
            else
            {
                TaiKhoanKhachHang = taikhoankhachhang;
            }
            return Page();
        }
    }
}
