using chcommerce_api.Handler;

UserHandler userHandler = new UserHandler();
SaleHandler saleHandler = new SaleHandler();
ProductSaleHandler productSaleHandler = new ProductSaleHandler();
ProductHandler productHandler = new ProductHandler();

var login = userHandler.Login("tcasazza", "SoyTobiasCasazza");
var allusers = userHandler.GetUsers();
var oneuser = userHandler.GetUserById(1);

var sales = saleHandler.GetSalesById(1);
var productsales = productSaleHandler.GetProductSales(1);
var products = productHandler.GetProducts(1);

Console.ReadLine();
