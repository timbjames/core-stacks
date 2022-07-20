// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Running;
using Microsoft.Extensions.DependencyInjection;
//using SimpleConsole.BenchmarkTests;
//using SimpleConsole.DateTimeExamples;

using AutoMapper;
using SimpleConsole;
using SimpleConsole.Models;
using SimpleConsole.Data;

var config = new MapperConfiguration(cfg =>
{
    cfg.CreateMap<Blog, BlogExtra>()
        .ForMember(dest => dest.BlogId, opt => opt.MapFrom(src => src.BlogId))
        .ForMember(dest => dest.BlogExtendedName, opt => opt.MapFrom(src => src.BlogExtended.Name));
});

IMapper mapper = config.CreateMapper();

Console.WriteLine("Simple console running.");

//DateTimeRunner.Run();

//var summary = BenchmarkRunner.Run<Md5VsSha256>();

//DbTesting.AddBlog();

//DbTesting.ReadBlog();

//DbTesting.UpdateBlog();

DbTesting.ReadBlog(mapper);

//DbTesting.DeleteBlog();

//new SimpleConsole.AsyncTest.Tests().Run1();
//new SimpleConsole.AsyncTest.Tests().Run2();

//new SimpleConsole.AsyncTest.Tests().Run1();
//new SimpleConsole.AsyncTest.Tests().Run2();

//new SimpleConsole.AsyncTest.Tests().Run1();
//new SimpleConsole.AsyncTest.Tests().Run2();

//new SimpleConsole.AsyncTest.Tests().Run1();
//new SimpleConsole.AsyncTest.Tests().Run2();

//new SimpleConsole.AsyncTest.Tests().Run1();
//new SimpleConsole.AsyncTest.Tests().Run2();

//string query = null;

//var people = new List<Person>()
//{
//    new Person() { Id = 1 },
//    new Person() { Name = "Tim", Id = 2}
//};

//var singlePerson = people.FirstOrDefault(x => x.Name == query);

//Console.WriteLine($"Name: {singlePerson?.Name} Id: {singlePerson?.Id}");

//Console.ReadLine();