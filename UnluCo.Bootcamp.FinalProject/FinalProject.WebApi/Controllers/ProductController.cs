
using FinalProject.Application.DTOs;
using FinalProject.Application.Interfaces;
using FinalProject.WebApi.Common.ProductImage;
using FinalProject.WebApi.Models.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinalProject.WebApi.Controllers
{
    [Route("api/products")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IAppUserService _userService;

        public ProductController(IProductService productService, IAppUserService userService)
        {
            _productService = productService;
            _userService = userService;
        }

        [HttpGet("getallofferdable")]
        public async Task<IActionResult> GetOfferdableProducts()
        {
            try
            {
                var products = await _productService.GetAllOfferdable();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                var products = await _productService.GetAll();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("getallactive")]
        public async Task<IActionResult> GetAllActiveProducts()
        {
            try
            {
                var products = await _productService.GetAllActive();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("getallinactive")]
        public async Task<IActionResult> GetAllInActiveProducts()
        {
            try
            {
                var products = await _productService.GetAllInActive();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            try
            {
                if (id > 0)
                {
                    var product = await _productService.GetbyId(id);
                    if (product != null)
                    {
                        return Ok(product);
                    }
                    return BadRequest(new { message = "Böyle bir ürün bulunmuyor!" });
                }
                else
                {
                    return BadRequest(new { message = "Böyle bir id bulunmuyor!" });
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getproductsByUser/{id}")]
        public async Task<IActionResult> GetProductByUserId(string id)
        {
            try
            {
                var result = await _userService.AnybyId(id);
                if (result)
                {
                    var products = _productService.GetbyUserId(id);

                    return Ok(products);
                }
                return BadRequest("Böyle bir kullanıcı bulunamadı!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                if (id > 0)
                {
                    var result = await _productService.Any(id);
                    if (result)
                    {
                        await _productService.Delete(id);
                        return Ok(new { message = "Silme işlemi gerçekleşti!" });
                    }
                    return BadRequest(new { message = "Böyle bir ürün bulunmuyor!" });
                }
                return BadRequest(new { message = "Böyle bir id bulunmuyor!" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("removeroduct/{id}")]
        public async Task<IActionResult> RemoveProduct(int id)
        {
            try
            {
                if (id > 0)
                {
                    var result = await _productService.Any(id);
                    if (result)
                    {
                        await _productService.RemoveFromDb(id);
                        return Ok(new { message = "Kayıtlardan tamamen silindi!" });
                    }
                    return BadRequest(new { message = "Böyle bir ürün bulunmuyor!" });
                }
                return BadRequest(new { message = "Böyle bir id bulunmuyor!" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] AddProductModel productModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ProductDto newProduct = new ProductDto();
                    
                    newProduct.ProductName = productModel.ProductName;
                    newProduct.BrandId = productModel.BrandId;
                    newProduct.ColorId = productModel.ColorId;
                    newProduct.Description = productModel.Description;
                    newProduct.IsOfferdable = productModel.IsOfferdable;
                    newProduct.Price = productModel.Price;
                    newProduct.SubCategoryId = productModel.SubCategoryId;
                    newProduct.UnitsInStock = productModel.UnitsInStock;
                    newProduct.UsageStatus = productModel.UsageStatus;
                    newProduct.ImagePath = "noimage.jpg";
                    newProduct.AppUserId = productModel.AppUserId;

                    await _productService.Add(newProduct);
                    return Ok();
                }
                return BadRequest(productModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("uploadproductimage/{id}")]
        public async Task<IActionResult> UploadProductImage(int id, IFormFile formFile)
        {
            try
            {
                if (formFile == null || formFile.Length > 409600)
                {
                    return BadRequest(new { message = "Resim yüklenemedi ya da boyutu 400kb'den büyük!" });
                }

                List<string> validExtensions = new List<string>() {
                "png", "jpg", "jpeg"
                };

                var fileExtension = formFile.FileName.Split(".");

                var isValid = validExtensions.Contains(fileExtension[fileExtension.Length - 1]);

                if (!isValid)
                {
                    return BadRequest("Yalnızca png/jpg/jpeg uzantılı dosyalar kabul edilmektedir!");
                }

                if (id > 0)
                {
                    var result = await _productService.Any(id);

                    if (result)
                    {
                        var product = await _productService.GetbyId(id);

                        ProductImageOperations imageOperations = new ProductImageOperations();
                        var message = await imageOperations.UploadImage(_productService, formFile, product);

                        return Ok(new { message = $"{message}" });
                    }

                    return BadRequest("Böyle bir ürün bulunmuyor!");
                }
                

                return BadRequest("Böyle bir ürün bulunmuyor!");
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        [HttpDelete("deleteproductimage/{id}")]
        public async Task<IActionResult> DeleteProductImage(int id)
        {
            if (id>0)
            {
                var result = await _productService.Any(id);

                if (result)
                {
                    var product = await _productService.GetbyId(id);

                    ProductImageOperations imageOperations = new ProductImageOperations();

                    var message = await imageOperations.DeleteImage(_productService, product);

                    return Ok(new { message = $"{message}" });
                }

                return BadRequest("Böyle bir ürün bulunmuyor!");
            }
            return BadRequest("Böyle bir ürün bulunmuyor!");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateColor(int id, [FromBody] UpdateProductModel productModel)
        {
            try
            {
                if (id > 0)
                {
                    var result = await _productService.Any(id);
                    if (!result)
                    {
                        return BadRequest(new { message = "Böyle bir ürün bulunmamaktadır!" });
                    }
                    if (ModelState.IsValid)
                    {
                        var product = await _productService.GetbyId(id);

                        product.ProductName = productModel.ProductName;
                        product.Description = productModel.Description;
                        product.IsOfferdable = productModel.IsOfferdable;
                        product.Price = productModel.Price;
                        product.SubCategoryId = productModel.SubCategoryId;
                        product.UnitsInStock = productModel.UnitsInStock;
                        product.UsageStatus = productModel.UsageStatus;
                        
                        await _productService.Update(product);
                        return Ok(new { message = $"{productModel.ProductName} güncellendi" });

                    }
                    return BadRequest(productModel);
                }
                return BadRequest(new { message = "Böyle bir id bulunmuyor!" });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
