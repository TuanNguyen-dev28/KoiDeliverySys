using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KoiDelivery.Repositories.Entities;
using KoiDelivery.Services.Interfaces;

namespace KoiDelivery.WebApp.Pages.Fish
{
    public class EditModel : PageModel
    {
        private readonly IKoiFishService _service;

        public EditModel(IKoiFishService service)
        {
            _service = service;
        }

        [BindProperty]
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
            KoiFish = koifish;
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                _service.UpdateKoiFish(KoiFish);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KoiFishExists(KoiFish.Id))
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

        private bool KoiFishExists(int id)
        {
            return _service.UpdateKoiFish(KoiFish);
        }
    }
}
