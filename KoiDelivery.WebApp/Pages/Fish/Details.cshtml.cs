using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiDelivery.Repositories.Entities;
using KoiDelivery.Services.Interfaces;

namespace KoiDelivery.WebApp.Pages.Fish
{
    public class DetailsModel : PageModel
    {
        private readonly IKoiFishService _service;

        public DetailsModel(IKoiFishService service)
        {
            _service = service;
        }

        public KoiFish KoiFish { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var koifish = await _service.GetKoiFishById(id.Value);
            if (koifish == null)
            {
                return NotFound();
            }
            else
            {
                KoiFish = koifish;
            }
            return Page();
        }
    }
}
