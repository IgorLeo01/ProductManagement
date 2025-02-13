using ProductManagementApp.Data;
using ProductManagementApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ProductManagementApp.Services
{
    public class ProductService
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Produto>> GetProdutosAsync()
        {
            return await _context.Produtos.ToListAsync();
        }

        public async Task<Produto> GetProdutoByIdAsync(int id)
        {
            return await _context.Produtos.FindAsync(id);
        }

        public async Task AddProdutoAsync(Produto produto)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProdutoAsync(Produto produto)
        {
            _context.Produtos.Update(produto);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> RemoveProdutoAsync(int id)
        {
            var produto = await GetProdutoByIdAsync(id);
            if (produto != null && produto.QuantidadeEmEstoque == 0)
            {
                _context.Produtos.Remove(produto);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
