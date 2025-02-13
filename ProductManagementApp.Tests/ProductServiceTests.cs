using Moq;
using ProductManagementApp.Data;
using ProductManagementApp.Models;
using ProductManagementApp.Services;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Threading.Tasks;
using System.Linq;

namespace ProductManagementApp.Tests
{
    [TestFixture]
    public class ProductServiceTests
    {
        private AppDbContext _context;
        private ProductService _service;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                          .UseInMemoryDatabase(databaseName: "TestDatabase")
                          .Options;

            _context = new AppDbContext(options);
            _service = new ProductService(_context);

            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }

        [Test]
        public async Task AddProdutoAsync_ShouldAddProduct()
        {
            var produto = new Produto { Nome = "Produto Teste", Descricao = "Descrição Teste", Preco = 10.0m, QuantidadeEmEstoque = 5 };

            await _service.AddProdutoAsync(produto);

            var produtoAdded = await _context.Produtos.FindAsync(produto.Id);

            Assert.IsNotNull(produtoAdded);
            Assert.AreEqual("Produto Teste", produtoAdded.Nome);
        }

        [Test]
        public async Task EditProdutoAsync_ShouldUpdateProduct()
        {
            var produto = new Produto { Nome = "Produto Teste", Descricao = "Descrição Teste", Preco = 10.0m, QuantidadeEmEstoque = 5 };

            await _service.AddProdutoAsync(produto);

            produto.Nome = "Produto Atualizado";
            await _service.UpdateProdutoAsync(produto);

            var produtoUpdated = await _context.Produtos.FindAsync(produto.Id);

            Assert.AreEqual("Produto Atualizado", produtoUpdated.Nome);
        }

        [Test]
        public async Task RemoveProdutoAsync_ShouldRemoveProduct()
        {
            var produto = new Produto { Nome = "Produto Teste", Descricao = "Descrição Teste", Preco = 10.0m, QuantidadeEmEstoque = 0 };

            await _service.AddProdutoAsync(produto);
            var sucesso = await _service.RemoveProdutoAsync(produto.Id);

            Assert.IsTrue(sucesso, "O produto foi removido.");

            var produtoRemoved = await _context.Produtos.FindAsync(produto.Id);
            Assert.IsNull(produtoRemoved, "O produto foi removido do DB.");
        }

    }
}
