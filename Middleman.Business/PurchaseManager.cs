using Middleman.Data;
using Middleman.Domain.Domain;
using Middleman.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Middleman.Business
{
    public class PurchaseManager : IPurchaseManager
    {
        #region Attributes

        private IRepository _repository;

        #endregion

        #region Contructors
        public PurchaseManager(IRepository repository)
        {
            _repository = repository;
        }

        #endregion

        #region Implemeting IPurchaseManager
        public void Add(Purchase purchase)
        {
            var uow = _repository.UoW;

            try
            {
                uow.BeginTransaction();

                _repository.AddEntity<Purchase>(purchase);
                InsertPurchaseInStock(purchase);

                uow.CommitTransaction();
          
            }
            catch (Exception ex)
            {
                uow.RollbackTransaction();
                throw new Exception("purchase can not be added because, " + ex.Message);
            }
            
           

        }

        public List<Purchase> GetList()
        {
            return _repository.GetList<Purchase>().ToList();
        }

        public List<Purchase> GetList(Expression<Func<Purchase, bool>> query)
        {
            return _repository.GetList<Purchase>(query).ToList();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Insert last purchase of product in stock
        /// </summary>
        /// <param name="purchase"></param>
        private void InsertPurchaseInStock(Purchase purchase)
        {

            var productInStock = _repository.GetList<ProductInStock>(
                                                           ps => ps.ProductId == purchase.ProductId &&
                                                                 ps.ProviderId == purchase.ProviderId &&
                                                                 ps.State == StateEnum.Available)
                                                                 .FirstOrDefault();
            if (productInStock == null)
            {
                productInStock = new ProductInStock()
                {
                    Amount = purchase.Amount,
                    PriceInput = purchase.PriceInput,
                    ProductId = purchase.ProductId,
                    ProviderId = purchase.ProviderId,
                    State = StateEnum.Available
                };
                var code = GenerateCode(productInStock);
                productInStock.Code = code;
                _repository.AddEntity(productInStock);
            }
            else
            {
                productInStock.Amount += purchase.Amount;
                _repository.UpdateEntity(productInStock);

            }
        }

        public string GenerateCode(ProductInStock productInStock)
        {
            var code = productInStock.ProductId.ToString() +
                       productInStock.ProviderId.ToString() +
                       productInStock.State.ToString();
            return code;
        }

        #endregion

    }
}
