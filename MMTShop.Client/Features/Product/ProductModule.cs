﻿using MMTShop.Client.Base;
using MMTShop.Shared.Constants;
using MMTShop.Shared.Contracts.Modules;
using MMTShop.Shared.Contracts.Provider;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Models = MMTShop.Shared.Models;

namespace MMTShop.Client.Features.Product
{
    public class ProductModule 
        : ModuleBase, IProductModule
    {
        public async Task<bool> DisplayFeaturedProductsAsync(
            CancellationToken cancellationToken)
        {
            var products = await productProvider
                .GetFeaturedProductsAsync(
                    cancellationToken);

            DisplayProducts(products);
            return true;
        }

        public async Task<bool> DisplayProductsByCategoryAsync(
            string categoryName,
            CancellationToken cancellationToken)
        {
            var products = await productProvider
                .GetProductsByCategoryName(
                    categoryName,
                    cancellationToken);

            DisplayProducts(
                products);

            return true;
        }

        private static void DisplayProducts(
            IEnumerable<Models.Product> products)
        {
            Display(
                products, 
                "Product", 
                product => 
                    string.Format("\tSku: {0}{4}" +
                        "\tName: {1}{4}" +
                        "\tDescription: {2}{4}" +
                        "\tPrice: {3:c2}{4}",
                    product.Sku,
                    product.Name,
                    product.Description,
                    product.Price,
                    FormatConstants.NewLine));
        }

        public ProductModule(
            IProductProvider productProvider)
        {
            this.productProvider = productProvider;
        }

        private readonly IProductProvider productProvider;
    }
}
