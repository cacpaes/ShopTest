using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ShopTest.Entities;
using ShopTest.Interfacies;
using ShopTest.Repositories;

namespace ShopTest.ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Bem-vindo à loja!");

            RepositoryCustomer repositoryCustomer = new ();
            RepositoryProduct repositoryProduct = new ();
            RepositoryTransaction repositoryTransaction = new ();
            RepositoryStock repositoryStock = new ();
            bool showMenu = true;
            while (showMenu)
            {
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1 - Comprar Produto");
                Console.WriteLine("2 - Listar Produtos");
                Console.WriteLine("3 - Sair");

                char key = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (key)
                {
                    case '1':
                        await ComprarProduto(repositoryCustomer, repositoryProduct, repositoryTransaction, repositoryStock);
                        break;
                    case '2':
                        await ListarProdutos(repositoryProduct);
                        break;
                    case '3':
                        showMenu = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
        }

        static async Task ComprarProduto(RepositoryCustomer repositoryCustomer, RepositoryProduct repositoryProduct, RepositoryTransaction repositoryTransaction, RepositoryStock repositoryStock)
        {
            try
            {
                // Aqui você pode pedir os detalhes do produto e do cliente ao usuário
                Console.WriteLine("Digite o ID do Cliente:");
                int customerId = int.Parse(Console.ReadLine());

                Console.WriteLine("Digite o ID do Produto:");
                int productId = int.Parse(Console.ReadLine());

                Console.WriteLine("Digite a quantidade:");
                int quantity = int.Parse(Console.ReadLine());

                // Criando a transação
                var transaction = new Transactions
                {
                    PersonId = customerId,
                    TotalAmount = 0, // Defina o valor total com base no produto
                    TransactionType = "Compra",
                    TransactionDate = DateTime.Now,
                    CreatedDate = DateTime.Now
                };

                // Buscando o cliente e o produto no repositório
                var customer = await repositoryCustomer.GetById(customerId);
                var product = await repositoryProduct.GetById(productId);

                if (customer != null && product != null)
                {
                    var sell = new Sells
                    {
                        TransactionId = transaction.TransactionId,
                        ProductId = productId,
                        Quantity = quantity,
                        TotalAmount = product.SaleValue * quantity, // Calcula o valor total da compra
                        SellDate = DateTime.Now
                    };

                    var result = await repositoryCustomer.Purchase(new List<Sells> { sell }, transaction);
                    Console.WriteLine(result);
                }
                else
                {
                    Console.WriteLine("Cliente ou Produto não encontrado!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao realizar a compra: " + ex.Message);
            }
        }

        static async Task ListarProdutos(RepositoryProduct repositoryProduct)
        {
            var products = await repositoryProduct.List();

            Console.WriteLine("Lista de Produtos:");
            foreach (var product in products)
            {
                Console.WriteLine($"ID: {product.ProductId}, Nome: {product.ProductName}, Valor: {product.SaleValue}");
            }
        }
    }
}
