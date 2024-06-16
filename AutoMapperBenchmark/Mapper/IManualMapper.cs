using AutoMapperBenchmark.Dtos;
using AutoMapperBenchmark.Models;
using System.Collections.Generic;

namespace AutoMapperBenchmark.Mapper
{
    public interface IManualMapper
    {
        ProductDto MapProductDto(Product product);
        List<ProductDto> MapProductDtoListByFor(List<Product> products);
        List<ProductDto> MapProductDtoListByForeach(List<Product> products);
    }
}
