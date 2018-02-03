using System;

namespace Automation.Model.MainModels
{
   [Serializable]
   public class Order
    {

        private  CustomersInfoCollection _customer;
        private  ProductsInfoCollection _products;

        private Order()
        {
            _customer = new CustomersInfoCollection();
            _products = new ProductsInfoCollection();
        }

        public static Order Instance { get; } = new Order();

        public ProductsInfoCollection GetProductsInfoCollection()
        {
            return _products;
        }

        public void SetProductsInfoCollection(ProductsInfoCollection productsInfoCollection)
        {
            _products = productsInfoCollection;
        }

        public CustomersInfoCollection GetCustomerInfoCollection()
        {
            return _customer;
        }

        public void SetCustomerInfoCollection(CustomersInfoCollection customersInfoCollection)
        {
            _customer = customersInfoCollection;
        }





    }
}
