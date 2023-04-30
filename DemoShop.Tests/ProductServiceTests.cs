using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoolEvents.Tests
{
    public class Tests
    {
        private ShopDbContext context;
        private ProductService productService;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ShopDbContext>()
                .UseInMemoryDatabase("TestDb").Options;

            this.context = new ShopDbContext(options);
            productService = new ProductService(this.context);
        }


        [TearDown]
        public void TearDown()
        {
            context.Database.EnsureDeleted();
        }

        [Test]
        public void TestGetAll()
        {
            Product product = CreateProduct(1, "Product Name");
            Product product2 = CreateProduct(2, "Product Name 2");
            Product product3 = CreateProduct(3, "Product Name 3");

            User user = new User();
            productService.Create(product, user);
            productService.Create(product2, user);
            productService.Create(product3, user);

            List<ProductDTO> productDTOs = productService.GetAll();

            Assert.AreEqual(3, productDTOs.Count);
            Assert.AreEqual("Product Name", productDTOs[0].Name);
        }

        [Test]
        public void TestGetById()
        {
            Product product = CreateProduct(1, "Product Name");
            User user = new User();
            productService.Create(product, user);

            Product dbProduct = productService.GetById(1);

            Assert.AreEqual(dbProduct.Name ,"Product Name");
        }

        [Test]
        public void TestCreate()
        {
            Product product = CreateProduct(1, "Product Name");
            User user = new User();

            productService.Create(product, user);

            Product dbProduct = context.Products.FirstOrDefault();

            Assert.NotNull(dbProduct);
        }

        [Test]
        public void TestEdit()
        {
            ProductService postService = new ProductService(this.context);

            Product product = new Product();
            product.Id = 1;
            product.Name = "Product Name";
            User user = new User();

            productService.Create(product, user);

            Product editProduct = new Product();

            editProduct.Id = 1;
            editProduct.Name = "asd";

            postService.Edit(editProduct);

            Product dbProduct = context.Products.FirstOrDefault(x => x.Id == 1);

            Assert.NotNull(dbProduct);
            Assert.AreEqual(dbProduct.Name, "asd");
        }

        [Test]
        public void TestDelete()
        {
            ProductService postService = new ProductService(this.context);

            Product product = new Product();
            product.Id = 1;
            product.Name = "Product Name";
            User user = new User();

            productService.Create(product, user);

            productService.Delete(1);

            Product dbProduct = context.Products.FirstOrDefault(x => x.Id == 1);
            Assert.Null(dbProduct);
        }

        private Product CreateProduct(int id, string name)
        {
            Product product = new Product();
            product.Id = id;
            product.Name = name;

            return product;
        }

        private class ProductDTO
        {
            internal double Name;
        }

        private class DbContextOptionsBuilder<T>
        {
            public DbContextOptionsBuilder()
            {
            }

            internal object UseInMemoryDatabase(string v)
            {
                throw new NotImplementedException();
            }
        }
    }

    internal class Product
    {
        public Product()
        {
        }

        public string Name { get; internal set; }
        public int Id { get; internal set; }
    }
}