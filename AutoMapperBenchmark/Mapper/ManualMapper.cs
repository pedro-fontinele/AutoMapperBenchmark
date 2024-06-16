using AutoMapperBenchmark.Dtos;
using AutoMapperBenchmark.Models;
using System.Collections.Generic;
using System.Linq;

namespace AutoMapperBenchmark.Mapper
{
    public class ManualMapper : IManualMapper
    {
        public ProductDto MapProductDto(Product product)
        {
            if (product == null)
            {
                return new ProductDto();
            }

            return new ProductDto()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Percentage = product.Percentage
            };
        }

        public List<ProductDto> MapProductDtoListByFor(List<Product> products)
        {
            if (products == null || products.Count == 0)
            {
                return new List<ProductDto>();
            }

            var productDtos = new List<ProductDto>();

            for (int i = 0; i < products.Count; i++)
            {
                var product = products[i];
                productDtos.Add(MapProductDto(product));
            }

            return productDtos;
        }

        public List<ProductDto> MapProductDtoListByForeach(List<Product> products)
        {
            if (products == null || products.Count == 0)
            {
                return new List<ProductDto>();
            }

            var productDtos = new List<ProductDto>();

            foreach (var item in products)
            {
                productDtos.Add(MapProductDto(item));
            }

            return productDtos;
        }
    }
}
