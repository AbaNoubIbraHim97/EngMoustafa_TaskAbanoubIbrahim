using Microsoft.AspNetCore.Mvc;
using Product.Domain.Dtos;
using Product.Infrastrucre.Services;

namespace VodusAssignent_Abanoub_Ibrahim.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await  _productService.GetAllProducts();
            return View(products);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(AddProductDto product)
        {
            if (ModelState.IsValid)
            {
                _productService.AddProduct(product);
                return Json(new {suceess=true, Messsage=$"{product.Name} added successfully"});
            }
            return View(product);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ProductDto productDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _productService.UpdateProductAsync(id, productDto);
                if (result)
                {
                    return RedirectToAction("Index");
                }
                return NotFound();
            }
            return View(productDto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _productService.DeleteProductAsync(id);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Details(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
    }
}
