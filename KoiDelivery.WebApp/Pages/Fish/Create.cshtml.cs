using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiDelivery.Repositories.Entities;
using KoiDelivery.Services.Interfaces;

namespace KoiDelivery.WebApp.Pages.Fish
{
    public class CreateModel : PageModel
    {
        private readonly IKoiFishService _service;

        public CreateModel(IKoiFishService service)
        {
            _service = service;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public KoiFish KoiFish { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _service.AddKoiFish(KoiFish);
            return RedirectToPage("./Index");
        }
    }
}
