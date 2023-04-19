using Domian;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.ShoppingMethods
{
    public interface IShoppingMethod : IRepository<ShoppingMethod,int>
    {
        
    }
}
