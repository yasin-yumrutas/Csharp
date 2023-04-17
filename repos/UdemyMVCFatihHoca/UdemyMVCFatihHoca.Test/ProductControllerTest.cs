using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UdemyMVCFatihHoca.web.Controllers;
using UdemyMVCFatihHoca.web.Models;
using UdemyMVCFatihHoca.web.Views.Repository;
using Xunit;

namespace UdemyMVCFatihHoca.Test
{
    public class ProductControllerTest
    {
        private readonly Mock<IRepository<Product>> _mockRepo;
        private readonly ProductsController _controller;
        private List<Product> products;


        //burda kullancağım objeleri atadım
        public ProductControllerTest()
        {
            _mockRepo = new Mock<IRepository<Product>>();

            _controller = new ProductsController(_mockRepo.Object);

            products = new List<Product>() { new Product { Id = 1, Name = "Mause", Color = "Red", Price = 1000, Stock = 5 },
                new Product{Id=2,Name="Klavye",Color="Black",Price=2000,Stock=2 } };
        }





        [Fact]
        public async void Index_ActionExecutes_ResultView()
        {
            var result = await _controller.Index();
            Assert.IsType<ViewResult>(result);
        }





        [Fact]
        public async void Index_ActionExecutes_ReturnList()
        {
            _mockRepo.Setup(repo => repo.GetAll()).ReturnsAsync(products);

            var result = await _controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);

            var productList = Assert.IsAssignableFrom<IEnumerable<Product>>(viewResult.Model);

            Assert.Equal<int>(2, productList.Count());

        }





        [Fact]
        public async void Details_ActionExecutes_StateOfZero()
        {
            var result = await _controller.Details(null);

            var redirect = Assert.IsType<RedirectToActionResult>(result);

            Assert.Equal("Index", redirect.ActionName);


        }




        [Fact]
        public async void Details_IdInValid_ReturnNotFound()
        {
            Product product = null;

            _mockRepo.Setup(x => x.GetById(0)).ReturnsAsync(product);

            var result = await _controller.Details(0);

            var redirect = Assert.IsType<NotFoundResult>(result);

            Assert.Equal<int>(404, redirect.StatusCode);


        }






        [Theory]
        [InlineData(1)]
        public async void Details_ValidId_ReturnProduct(int productId)
        {
            Product product = products.First(x => x.Id == productId);

            _mockRepo.Setup(x => x.GetById(productId)).ReturnsAsync(product);

            var result = await _controller.Details(productId);

            var viewResult = Assert.IsType<ViewResult>(result);

            var resultProduct = Assert.IsAssignableFrom<Product>(viewResult.Model);

            Assert.Equal(product.Id, resultProduct.Id);

            Assert.Equal(product.Stock, resultProduct.Stock);

        }




        [Fact]
        public void Create_ActionExecutes_ReturnView()
        {
            var result = _controller.Create();

            Assert.IsType<ViewResult>(result);
        }


        [Fact]
        public async void CreatePOST_InValidModelState_ReturnView()
        {
            _controller.ModelState.AddModelError("name", "name alanı giriniz");

            var result = await _controller.Create(products.First());

            var viewResult = Assert.IsType<ViewResult>(result);

            Assert.IsType<Product>(viewResult.Model);

        }




        [Fact]
        public async void CreatePOST_InValidModelState_ReturnRedirectToActionIndex()
        {
            var result = await _controller.Create(products.First());

            var indexName = Assert.IsType<RedirectToActionResult>(result);

            Assert.Equal("Index", indexName.ActionName);

        }




        [Fact]
        public async void CreatePOST_ValidModelState_CreateMethodExecute()
        {
            Product product = null;

            //_mockRepo.Setup(x => x.Create(It.IsAny<Product>())).Callback<Product>(x => product = x);

            _mockRepo.Setup(x => x.Create(It.IsAny<Product>()));
            //-- Deneme yap normal şekilde setup oluşturup productın içine sonra gönder olucakmı

            product = products.First();               //-->İki şekildede olur

            var result = await _controller.Create(products.First());

            _mockRepo.Verify(x => x.Create(It.IsAny<Product>()), Times.Once());

            Assert.Equal(products.First().Id, product.Id);

            Assert.Equal(products.First().Name, product.Name);

        }




        [Fact]
        public async void CreatePOST_InValidModelState_NeverCreate()
        {
            _controller.ModelState.AddModelError("Name", "");

            var result = await _controller.Create(products.First());

            _mockRepo.Verify(x => x.Create(It.IsAny<Product>()), Times.Never());
        }




        //Burda Editin içine null değer gelince ProductController içindeki Edit in if bloğuna girip istediğimiz noktaya dönüyor mu onu test ettik
        [Fact]
        public async void Edit_InValidNull_RedirectToActionIndexResult()
        {
            var result = await _controller.Edit(null);

            var redirect = Assert.IsType<RedirectToActionResult>(result);

            Assert.Equal("Index", redirect.ActionName);
        }


        //Bunda bir mantık hatası var       *********************
        //ProductController içindeki Edite veritabınında olmayan bir id verince notfound dönmesi lazım onu test ettik
        [Theory]
        [InlineData(3)]
        public async void Edit_UnValidRepository_ReturnNotFound(int productId)
        {
            Product product = null;

            //product = products.First(x => x.Id == productId);        ---->Bunu uyguladığımda ne eksik onu araştır

            _mockRepo.Setup(x => x.GetById(productId)).ReturnsAsync(product);

            var result = await _controller.Edit(productId);

            var redirect = Assert.IsType<NotFoundResult>(result);

            Assert.Equal<int>(404, redirect.StatusCode);
        }



        //ProductController içersindeki Edite ulaşıp repositoryimizde olan bir ürünün doğru şekilde gelip gelmediğini test ettik
        [Theory]
        [InlineData(2)]
        public async void Edit_InValidRepository_ReturnView(int productId)
        {
            var product = products.First(x => x.Id == productId);

            _mockRepo.Setup(x => x.GetById(productId)).ReturnsAsync(product);

            var result = await _controller.Edit(productId);

            var redirect = Assert.IsType<ViewResult>(result);

            var viewResult = Assert.IsAssignableFrom<Product>(redirect.Model);

            Assert.Equal(product.Color, viewResult.Color);
        }



        //Kullanıcıdan gelen id i product içindekiyle eşleşiyormu eşleşmiyorsa NotFound dönmesini görmek
        [Theory]
        [InlineData(1)]
        public void EditPOST_NotEqualProduct_ReturnNotFound(int productId)
        {
            var result = _controller.Edit(2, products.First(x => x.Id == productId));

            var redirect = Assert.IsType<NotFoundResult>(result);

        }


        //ProductController içindeki Edit[POST] un içindeki ModelState koşulunun hata aldığı durumda block içindeki işlemleri atlayıp product ı geri döndürüyor mu
        [Theory]
        [InlineData(1)]
        public void EditPOST_InValidModelState_ReturnView(int productId)
        {
            _controller.ModelState.AddModelError("Name", "");

            var result = _controller.Edit(productId, products.First(x => x.Id == productId));

            var redirect = Assert.IsType<ViewResult>(result);

            Assert.IsType<Product>(redirect.Model);
        }



        //ProductController içindeki Edit[POST] un içindeki ModelState koşulunu sağladıktan sonra Index sayfasına dönüş yapıyormu onu test ediyoruz
        [Theory]
        [InlineData(1)]
        public void EditPOST_InValidModelState_RedirectToIndexAction(int productId)
        {
            var result = _controller.Edit(productId, products.First(x => x.Id == productId));

            var redirect = Assert.IsType<RedirectToActionResult>(result);

            Assert.Equal("Index", redirect.ActionName);
        }



        [Theory]
        [InlineData(1)]
        public void EditPOST_InValidModelState_UpdateMethodExecute(int productId)
        {
            var product = products.First(x => x.Id == productId);

            _mockRepo.Setup(x => x.Update(product));

            _controller.Edit(productId, product);

            _mockRepo.Verify(x => x.Update(It.IsAny<Product>()), Times.Once());
        }





        [Fact]
        public async void Delete_IdIsNull_ReturnNotFound()
        {

            var result = await _controller.Delete(null);

            Assert.IsType<NotFoundResult>(result);
        }




        [Theory]
        [InlineData(0)]
        public async void Delete_IdIsNotEqualProduct_ReturnNotFound(int productId)
        {
            Product product = null;

            _mockRepo.Setup(deneme => deneme.GetById(productId)).ReturnsAsync(product);

            var result = await _controller.Delete(productId);

            Assert.IsType<NotFoundResult>(result);
        }




        [Theory]
        [InlineData(1)]
        public async void Delete_ActionExecute_ReturnView(int productId)
        {
            var p = products.First(x => x.Id == productId);

            _mockRepo.Setup(x => x.GetById(productId)).ReturnsAsync(p);

            var result = await _controller.Delete(productId);

            var redirect = Assert.IsType<ViewResult>(result);

            var viewResult = Assert.IsAssignableFrom<Product>(redirect.Model);

            Assert.Equal(p.Id, viewResult.Id);
        }




        [Theory]
        [InlineData(1)]
        public async void DeleteConfirmed_ActionExecute_RedirectToIndexAction(int productId)
        {
            var result = await _controller.DeleteConfirmed(productId);

            Assert.IsType<RedirectToActionResult>(result);
        }



        [Theory]
        [InlineData(1)]
        public async void DeleteConfirmed_ActionExecute_DeleteMethodExecute(int productId)
        {
            var product = products.First(x => x.Id == productId);

            _mockRepo.Setup(x => x.Delete(product));

            await _controller.DeleteConfirmed(productId);

            _mockRepo.Verify(x => x.Delete(It.IsAny<Product>()), Times.Once());
        }






    }
}
