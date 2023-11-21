using ShopTest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTest.Interfacies
{
    public interface IRepositoryCustomer : IRepositoryGeneric<Customers>
    {
        Task<string> Purchase(List<Sells> sells, Transactions transaction);
    }
}
