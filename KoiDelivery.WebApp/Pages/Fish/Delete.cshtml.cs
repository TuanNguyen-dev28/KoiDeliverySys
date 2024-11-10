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
    public class DeleteModel : PageModel
    {
        private readonly IKoiFishService _service;

        public DeleteModel(IKoiFishService service)
        {
            _service = service;
        }

        [BindProperty]
        public KoiFish KoiFish { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            int Id = 0;
            if (id == null)
            {
                Id = 0;
                return NotFound();
            }
            Id = (int)id;

            var koifish = await _service.GetKoiFishById(Id);

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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            _service.DelKoiFish((int)id);
            return RedirectToPage("./Index");
        }
    }
}
