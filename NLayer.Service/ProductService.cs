using Microsoft.EntityFrameworkCore;
using NLayer.Data;
using NLayer.Data.Models;
using NLayer.Service.Dtos;
using NLayer.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service
{
    public class ProductService
    {
        private readonly AppDbContext _context;

        private readonly GenericRepository<Product> _productRepository;
        private readonly GenericRepository<Category> _categoryRepository;
        private readonly GenericRepository<ProductFeature> _productFeatureRepository;

        private readonly UnitOfWork _unitOfWork;

        public ProductService(AppDbContext context,GenericRepository<Product> productRepository,GenericRepository<Category> categoryRepository,GenericRepository<ProductFeature> productFeatureRepository,UnitOfWork unitOfWork)
        {
            _context = context;
            this._productRepository = productRepository;
            this._categoryRepository = categoryRepository;
            this._productFeatureRepository = productFeatureRepository;
            this._unitOfWork = unitOfWork;
        }
        /// <summary>
        /// return Product List
        /// </summary>
        public async Task<Response<List<ProductDto>>> GetAll()
        {
            var products = await _context.Products.ToListAsync();

            var productDtos = products.Select(p => new ProductDto()
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                CategoryId = p.CategoryId,
            }).ToList();

            if (!productDtos.Any())
            {
                return new Response<List<ProductDto>>()
                {
                    Data = productDtos,
                    Errors = new List<string>() { "Ürün mevcut değil" },
                    Status = 404
                };
            }
            return new Response<List<ProductDto>>()
            {
                Data = productDtos,
                Errors = null,
                Status = 200
            };
        }

        /// <summary>
        /// Transactionı  unitofwork ile sağlama
        /// </summary>
        public async Task<Response<string>> CreateAll(Category category, Product product, ProductFeature productFeature)
        {
            await _categoryRepository.Add(category);
            await _productRepository.Add(product);
            await _productFeatureRepository.Add(productFeature);

            await _unitOfWork.Commit();

            return new Response<string>();
        }

        /// <summary>
        /// Transactionı açık bir şekilde başlatma
        /// </summary>
        public async Task<Response<string>> CreateAll2(Category category, Product product, ProductFeature productFeature)
        {
            await _categoryRepository.Add(category);
            await _productRepository.Add(product);
            await _productFeatureRepository.Add(productFeature);

            using (var transaction = _unitOfWork.BeginTransaction())
            {
                transaction.Commit();
            }

            return new Response<string>();
        }
        /// <summary>
        ///  return sp_ProductDetails
        /// </summary>
        public async Task<Response<List<ProductFullModel>>> GetProductFullModel()
        {
            var list = await _context.ProductFullModels.FromSqlRaw("Exec sp_ProductDetails").ToListAsync();
            return new Response<List<ProductFullModel>>() { Data = list ,Status =200};
        }
        /// <summary>
        ///  return vw_ProductDetails
        /// </summary>
        public async Task<Response<List<ProductViewModel>>> GetProductViewModel()
        {
            var list = await _context.ProductViewModels.FromSqlRaw("SELECT * FROM vw_ProductDetails").ToListAsync();
            return new Response<List<ProductViewModel>>() { Data = list, Status = 200 };
        }
        /// <summary>
        ///  return fn_Combine
        /// </summary>
        public async Task<Response<List<ProductFnCombineModel>>> ProductFnCombineModel(string Code,string Name)
        {
            var list = await _context.ProductFnCombineModels.FromSqlInterpolated($"SELECT dbo.fn_Combine ({Code},{Name}) AS fn_Combine").ToListAsync();
            return new Response<List<ProductFnCombineModel>>() { Data = list, Status = 200 };
        }
    }
}
