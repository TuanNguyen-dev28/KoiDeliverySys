using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiDelivery.Repositories.Entities;
using KoiDelivery.Services.Interfaces;

namespace KoiDelivery.WebApp.Pages.Account
{
    public class DeleteModel : PageModel
    {
        private readonly IKhachHangService _service;

        public DeleteModel(IKhachHangService service)
        {
            _service = service;
        }

        [BindProperty]
        public TaiKhoanKhachHang TaiKhoanKhachHang { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            int Id = 0;
            if (id == null)
            {
                Id = 0;
                return NotFound();
            }
            Id = (int)(id);
            var taikhoankhachhang = await _service.GetTaiKhoanKhachHangById(Id);

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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            _service.DelTaiKhoanKhachHang((int)id);
            return RedirectToPage("./Index");
        }
    }
}
