using AutoMapper;
using AutoMapperBenchmark.Dtos;
using AutoMapperBenchmark.Mapper;
using AutoMapperBenchmark.Models;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;

namespace AutoMapperBenchmark;
[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.SlowestToFastest)]
public class MappingBenchmark
{
    private IMapper _mapper;
    private List<Product> _products;
    private IManualMapper _manualMapper;

    [Params(10, 100, 1000)]
    public int NumberOfElements { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Product, ProductDto>().ReverseMap();
        });
        _mapper = config.CreateMapper();
        _products = GenerateProducts();

        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);
        var serviceProvider = serviceCollection.BuildServiceProvider();

        // Resolve a dependência
        _manualMapper = serviceProvider.GetRequiredService<IManualMapper>();
    }

    private void ConfigureServices(IServiceCollection services)
    {
        // Registre o IManualMapper e sua implementação
        services.AddScoped<IManualMapper, ManualMapper>();

        // Adicione outras dependências conforme necessário
    }

    [Benchmark]
    public List<ProductDto> AutoMapperMapping()
    {
        return _mapper.Map<List<ProductDto>>(_products);
    }

    [Benchmark]
    public List<ProductDto> ManualMappingFor()
    {
        return _manualMapper.MapProductDtoListByFor(_products);
    }

    [Benchmark]
    public List<ProductDto> ManualMappingForeach()
    {
        return _manualMapper.MapProductDtoListByForeach(_products);
    }

    private List<Product> GenerateProducts()
    {
        var products = new List<Product>();

        for (int i = 1; i <= NumberOfElements; i++)
        {
            var product = new Product
            {
                Id = i,
                Name = $"Product name {i}",
                Description = $"Product description {i}",
                Price = 45.50m,
                Percentage = 19
            };

            products.Add(product);
        }

        return products;
    }
}