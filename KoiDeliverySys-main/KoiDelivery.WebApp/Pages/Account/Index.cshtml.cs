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
    public class IndexModel : PageModel
    {
        private readonly IKhachHangService _service;
        public IndexModel(IKhachHangService service)
        {
            _service = service;
        }

        public IList<TaiKhoanKhachHang> TaiKhoanKhachHang { get;set; } = default!;

        public async Task OnGetAsync()
        {
            TaiKhoanKhachHang = await _service.TaiKhoanKhachHangs();
        }
    }
}
