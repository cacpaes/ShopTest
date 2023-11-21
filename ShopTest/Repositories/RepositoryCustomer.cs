using ShopTest.Entities;
using ShopTest.Interfacies;

namespace ShopTest.Repositories
{
    public class RepositoryCustomer : RepositoryGeneric<Customers>, IRepositoryCustomer
    {
        RepositoryTransaction repositoryTransaction = new();
        RepositoryStock repositoryStock = new();
        RepositorySells repositorySells = new();
        public async Task<string> Purchase(List<Sells> sells, Transactions transaction)
        {
            try
            {
                var transactionEntity = await repositoryTransaction.Create(transaction);

                foreach (var sellList in sells)
                {

                    //Obtem produto no stock
                    var stock = repositoryStock.List().GetAwaiter().GetResult().Where(x => x.ProductId == sellList.ProductId).FirstOrDefault();

                    //Verifica se tem stock suficiente
                    if (stock.UnitQuantity >= sellList.Quantity)
                    {
                        //Verifica se tem stock suficiente
                        if (stock.UnitQuantity >= sellList.Quantity)
                        {
                            //Deduz do stock
                            var stockEntity = await repositoryStock.GetById(stock.StockId);
                            stockEntity.UnitQuantity -= sellList.Quantity;
                            await repositoryStock.Update(stockEntity);

                            //Cria a Sell
                            if (repositoryTransaction != null && repositoryStock != null && repositorySells != null)
                            {
                                // Seus códigos que usam esses repositórios
                            }
                            else
                            {
                                Console.WriteLine("Algum repositório não foi inicializado corretamente.");
                            }

                        }
                        else
                        {
                            Console.WriteLine("Product " + sellList.ProductId + "Out of stock!");
                        }


                        //Cria a Sell
                        sellList.TransactionId = transactionEntity.TransactionId;
                        await repositorySells.Create(sellList);
                    }
                    else
                    {
                        Console.WriteLine("Product " + sellList.ProductId + "Out of stock!");
                    }
                }

                return "Operation Completed";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return "Error when creating your order.";
            }
        }
    }
}
