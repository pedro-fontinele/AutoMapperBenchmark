// See https://aka.ms/new-console-template for more information

using AutoMapperBenchmark;
using AutoMapperBenchmark.Mapper;
using BenchmarkDotNet.Running;
using Microsoft.Extensions.DependencyInjection;


BenchmarkRunner.Run<MappingBenchmark>();