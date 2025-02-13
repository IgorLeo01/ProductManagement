using Microsoft.AspNetCore.Mvc;
using ProductManagementApp.Models;
using ProductManagementApp.Services;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagementApp.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly ProductService _productService;

        public ProdutoController(ProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index(string search, int page = 1, int pageSize = 5)
        {
            var produtos = await _productService.GetProdutosAsync();

            if (!string.IsNullOrEmpty(search))
            {
                produtos = produtos.Where(p => p.Nome.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                                                p.Descricao.Contains(search, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            produtos = produtos.OrderBy(p => p.Id).ToList();

            var paginatedProdutos = produtos.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling(produtos.Count / (double)pageSize);

            ViewData["Search"] = search;

            return View(paginatedProdutos);
        }


        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(Produto produto)
        {
            if (ModelState.IsValid)
            {
                await _productService.AddProdutoAsync(produto);
                return RedirectToAction(nameof(Index));
            }

            return View(produto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var produto = await _productService.GetProdutoByIdAsync(id);  

            if (produto == null)
            {
                return NotFound();  
            }

            return View(produto);  
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Produto produto)
        {
            if (id != produto.Id) return BadRequest();

            if (ModelState.IsValid)
            {
                await _productService.UpdateProdutoAsync(produto);
                return RedirectToAction(nameof(Index));
            }

            return View(produto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var produto = await _productService.GetProdutoByIdAsync(id);

            if (produto == null)
            {
                return NotFound();
            }

            if (produto.QuantidadeEmEstoque > 0)
            {
                TempData["ErrorMessage"] = "Não é possível remover um produto com quantidade em estoque maior que 0.";
                return RedirectToAction(nameof(Index));
            }

            var sucesso = await _productService.RemoveProdutoAsync(id);
            if (!sucesso)
            {
                TempData["ErrorMessage"] = "Ocorreu um erro ao remover o produto.";
            }
            else
            {
                TempData["SuccessMessage"] = "Produto removido com sucesso!";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
