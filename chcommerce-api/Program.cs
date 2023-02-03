using chcommerce_api.Handler;
using chcommerce_api.Models;

UserHandler userHandler = new UserHandler();
SaleHandler saleHandler = new SaleHandler();
ProductSaleHandler productSaleHandler = new ProductSaleHandler();
ProductHandler productHandler = new ProductHandler();

Usuario login = userHandler.Login("tcasazza", "SoyTobiasCasazza");
List<Usuario> allusers = userHandler.GetUsers();
Usuario oneuser = userHandler.GetUserById(1);

List<Venta> sales = saleHandler.GetSalesById(1);
List<Producto> productsales = productSaleHandler.GetProductSales(1);
List<Producto> products = productHandler.GetProducts(1);

Console.ReadLine();
