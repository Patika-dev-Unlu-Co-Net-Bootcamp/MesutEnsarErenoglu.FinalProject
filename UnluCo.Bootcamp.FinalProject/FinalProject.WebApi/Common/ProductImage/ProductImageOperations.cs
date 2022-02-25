using FinalProject.Application.DTOs;
using FinalProject.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace FinalProject.WebApi.Common.ProductImage
{
    public class ProductImageOperations
    {
        public async Task<string> UploadImage(IProductService productService, IFormFile formFile, ProductDto product)
        {
            var oldPath = product.ImagePath; 

            product.ImagePath = await AddImageServer(formFile);

            await productService.UpdateProductImage(product);

            if (!String.IsNullOrEmpty(oldPath) || oldPath != "noimage.jpg")
            {
                DeleteImageFromServer(oldPath);
            }

            return "Resim yükleme işlemi tamamlandı!";
        }
        public async Task<string> AddImageServer(IFormFile formFile)
        {
            string fileName = null;
            fileName = Guid.NewGuid().ToString() + "_" + formFile.FileName;
            string filePath = Path.Combine("Content/Images/Product", fileName);
            await formFile.CopyToAsync(new FileStream(filePath, FileMode.Create));
            return fileName;
        }

        public async Task<string> DeleteImage(IProductService productService, ProductDto product)
        {
            DeleteImageFromServer(product.ImagePath);
            
            product.ImagePath = "noimage.jpg";

            await productService.UpdateProductImage(product);

            return "Silme işlemi tamamlandı!";
        }
        public void DeleteImageFromServer(string imagePath)
        {
            var filePath = Path.Combine("Content/Images/Product", imagePath);

            FileInfo info = new FileInfo(filePath);

            if (info != null)
            {
                System.IO.File.Delete(filePath);
            }
        }


    }
}
