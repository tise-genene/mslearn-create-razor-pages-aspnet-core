using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ContosoPizza.Models;
using ContosoPizza.Services;

namespace ContosoPizza.pages
{
    public class PizzaListModel : PageModel
    {
        [BindProperty]
        public Pizza NewPizza { get; set; } = default!;
        private readonly PizzaService _service;
        public IList<Pizza> PizzaList { get; set; } = default!;

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid || NewPizza == null)
            {
                return Page();
            }

            _service.AddPizza(NewPizza);

            return RedirectToAction("Get");
        }
        
        public PizzaListModel(PizzaService service)
        {
            _service = service;
        }

        public void OnGet()
        {
            PizzaList = _service.GetPizzas();
        }
    }
}
