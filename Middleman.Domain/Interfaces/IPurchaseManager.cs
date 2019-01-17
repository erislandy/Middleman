using Middleman.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Middleman.Domain.Interfaces
{
    public interface IPurchaseManager
    {
        void Add(Purchase purchase);
        List<Purchase> GetList();

        List<Purchase> GetList(Expression<Func<Purchase, bool>> query);


    }
}
