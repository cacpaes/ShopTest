using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using ShopTest.Entities;
using ShopTest.Interfacies;
using ShopTest.Repositories;

class Program
{
    private static IRepositoryProduct _productRepository;

    static async Task Main(string[] args)
    {
        var serviceProvider = new ServiceCollection()
            .AddTransient<IRepositoryProduct, RepositoryProduct>()
            .BuildServiceProvider();

        _productRepository = serviceProvider.GetService<IRepositoryProduct>();

        Console.WriteLine("Bem-vindo à Loja!");

        while (true)
        {
            Console.WriteLine("\nEscolha uma opção:");
            Console.WriteLine("1. Adicionar novo produto");
            Console.WriteLine("2. Ver lista de produtos");
            Console.WriteLine("0. Sair");

            var opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    await AdicionarNovoProduto();
                    break;
                case "2":
                    await VerListaProdutos();
                    break;
                case "0":
                    Console.WriteLine("Saindo...");
                    return;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }
    }

    static async Task AdicionarNovoProduto()
    {
        try
        {
            Console.WriteLine("\n--- Novo Produto ---");
            Console.Write("Nome do produto: ");
            var nome = Console.ReadLine();
            // ... outras informações do produto

            var novoProduto = new Product
            {
                ProductName = nome,
                // ... preencha outras informações do produto
            };

            await _productRepository.Create(novoProduto);
            Console.WriteLine("Novo produto adicionado com sucesso!");

            await VerListaProdutos(); // Mostra a lista atualizada após adição do novo produto
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao adicionar novo produto: " + ex.Message);
        }
    }


    static async Task VerListaProdutos()
    {
        Console.WriteLine("\n--- Lista de Produtos ---");
        var produtos = await _productRepository.List();

        if (produtos.Count == 0)
        {
            Console.WriteLine("Nenhum produto cadastrado ainda.");
        }
        else
        {
            Console.WriteLine("Produtos disponíveis:");
            foreach (var produto in produtos)
            {
                Console.WriteLine($"- {produto.ProductName}");
                // Mostrar outras informações relevantes do produto, se necessário
            }
        }
    }
}
