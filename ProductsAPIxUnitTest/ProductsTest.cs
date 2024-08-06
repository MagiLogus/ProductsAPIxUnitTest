using Moq;
using ProductsAPI.Domains;
using ProductsAPI.Interface;

namespace ProductsAPIxUnitTest
{
    public class ProductsTest
    {
        [Fact]
        public void Get()
        {
            //Arrange: Organizar

            var product = new List<Products>
            {
                new Products {IdProduct = Guid.NewGuid(), Name= "Produto 1", Price = 10},
                new Products {IdProduct = Guid.NewGuid(), Name= "Produto 2", Price = 20},
                new Products {IdProduct = Guid.NewGuid(), Name= "Produto 3", Price = 30}
            };

            //Cria um obj de simulacao do tipo ProductsRepository
            var mockRepository = new Mock<IProductsRepository>();

            //Configura o metodo Get para retornar a lista de produtos "mockada"
            mockRepository.Setup(x => x.Get()).Returns(product);

            //Act: Agir

            //Chama o metodo Get e armazena o resultado
            var result = mockRepository.Object.Get();

            //Assert: Provar

            //Prova se o resultado esperado e igual ao resultado obtido atraves da busca
            Assert.Equal(3, result.Count); 
        }

        [Fact]
        public void GetById()
        {
            // Arrange
            var productId = Guid.NewGuid();
            var product = new Products { IdProduct = productId, Name = "Produto 1", Price = 10 };

            var mockRepository = new Mock<IProductsRepository>();
            mockRepository.Setup(x => x.GetById(productId)).Returns(product);

            // Act
            var result = mockRepository.Object.GetById(productId);

            // Assert
            Assert.Equal(productId, result.IdProduct);
        }

        [Fact]
        public void Post()
        {
            // Arrange
            var newProduct = new Products { IdProduct = Guid.NewGuid(), Name = "Produto Novo", Price = 50 };

            var mockRepository = new Mock<IProductsRepository>();
            mockRepository.Setup(x => x.Post(It.IsAny<Products>()));

            // Act
            mockRepository.Object.Post(newProduct);

            // Assert
            mockRepository.Verify(x => x.Post(It.Is<Products>(p => p.IdProduct == newProduct.IdProduct)), Times.Once);
        }

        [Fact]
        public void Put()
        {
            // Arrange
            var productId = Guid.NewGuid();
            var updatedProduct = new Products { IdProduct = productId, Name = "Produto Atualizado", Price = 100 };

            var mockRepository = new Mock<IProductsRepository>();
            mockRepository.Setup(x => x.Put(productId, updatedProduct));

            // Act
            mockRepository.Object.Put(productId, updatedProduct);

            // Assert
            mockRepository.Verify(x => x.Put(productId, updatedProduct), Times.Once);
        }

        [Fact]
        public void Delete()
        {
            // Arrange
            var productId = Guid.NewGuid();

            var mockRepository = new Mock<IProductsRepository>();
            mockRepository.Setup(x => x.Delete(productId));

            // Act
            mockRepository.Object.Delete(productId);

            // Assert
            mockRepository.Verify(x => x.Delete(productId), Times.Once);
        }
    }
}