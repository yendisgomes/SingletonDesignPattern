using SingletonDesignPattern.Domain;
using SingletonDesignPattern.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SingletonDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var repo = ProdutoRepository.GetInstance();

            var lista1 = repo.GetAll();

            repo.Insert(new Produto { Id = 1, Name = "xpto1", Price = 10 });
            repo.Insert(new Produto { Id = 1, Name = "xpto2", Price = 20 });

            var lista2 = repo.GetAll();

            var repo2 = ProdutoRepository.GetInstance();

            var lista3 = repo2.GetAll();

            Console.WriteLine("Garante a existência de apenas uma instância de uma classe em memória");
            Console.ReadKey();
        }
    }
}
