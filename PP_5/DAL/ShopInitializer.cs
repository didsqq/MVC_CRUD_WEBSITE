using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PP_5.Models;

namespace PP_5.DAL
{
    public class ShopInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ShopContext>
    {
        protected override void Seed(ShopContext context)
        {
            var providers = new List<Provider>
            {
                new Provider{Name="Asus", Country="USA", Email="asus@gmail.com", Phone="8800553535"},
                new Provider{Name="Intel", Country="USA", Email="intel@gmail.com", Phone="8800553536"},
                new Provider{Name="Samsung", Country="South Korea", Email="samsung@gmail.com", Phone="8800553537"},
                new Provider{Name="Gigabyte", Country="Taiwan", Email="gigabyte@gmail.com", Phone="8800553538"},
                new Provider{Name="MSI", Country="Taiwan", Email="msi@gmail.com", Phone="8800553539"},
                new Provider{Name="AMD", Country="USA", Email="amd@gmail.com", Phone="8800553540"},
                new Provider{Name="ASRock", Country="Taiwan", Email="asrock@gmail.com", Phone="8800553541"},
                new Provider{Name="Corsair", Country="USA", Email="corsair@gmail.com", Phone="8800553542"},
                new Provider{Name="Western Digital", Country="USA", Email="wd@gmail.com", Phone="8800553543"},
                new Provider{Name="Seagate", Country="USA", Email="seagate@gmail.com", Phone="8800553544"},
                new Provider{Name="Kingston", Country="USA", Email="kingston@gmail.com", Phone="8800553545"},
                new Provider{Name="Crucial", Country="USA", Email="crucial@gmail.com", Phone="8800553546"},
                new Provider{Name="Cooler Master", Country="Taiwan", Email="coolermaster@gmail.com", Phone="8800553547"},
                new Provider{Name="EVGA", Country="USA", Email="evga@gmail.com", Phone="8800553548"},
                new Provider{Name="Thermaltake", Country="Taiwan", Email="thermaltake@gmail.com", Phone="8800553549"}
            };

            providers.ForEach(s => context.Providers.Add(s));

            var componentTypes = new List<Component_Type>
            {
                new Component_Type { Name="Процессор" },
                new Component_Type { Name="Видеокарта" },
                new Component_Type { Name="Материнская плата" },
                new Component_Type { Name="Оперативная память" },
                new Component_Type { Name="Твердотельный накопитель (SSD)" },
                new Component_Type { Name="Жесткий диск (HDD)" },
                new Component_Type { Name="Блок питания" },
                new Component_Type { Name="Система охлаждения" },
                new Component_Type { Name="Корпус" },
                new Component_Type { Name="Монитор" },
                new Component_Type { Name="Клавиатура" },
                new Component_Type { Name="Мышь" },
                new Component_Type { Name="Звуковая карта" },
                new Component_Type { Name="Сетевая карта" },
                new Component_Type { Name="Оптический привод" }
            };

            componentTypes.ForEach(s => context.ComponentTypes.Add(s));

            var products = new List<Product>
            {
                new Product{Name="Intel Core i5 9400F", Count=34, Price=10000, Warranty_Period=3, TypeID=1, ProviderID=2},
                new Product{Name="AMD Ryzen 5 3600", Count=20, Price=12000, Warranty_Period=3, TypeID=1, ProviderID=6},
                new Product{Name="NVIDIA GeForce RTX 3070", Count=15, Price=45000, Warranty_Period=3, TypeID=2, ProviderID=1},
                new Product{Name="ASRock B450M Pro4", Count=25, Price=8000, Warranty_Period=3, TypeID=3, ProviderID=7},
                new Product{Name="Corsair Vengeance LPX 16GB", Count=50, Price=6000, Warranty_Period=3, TypeID=4, ProviderID=8},
                new Product{Name="Samsung 970 EVO Plus 1TB", Count=30, Price=15000, Warranty_Period=3, TypeID=5, ProviderID=3},
                new Product{Name="Western Digital Blue 1TB", Count=40, Price=5000, Warranty_Period=3, TypeID=6, ProviderID=9},
                new Product{Name="Cooler Master Hyper 212", Count=20, Price=2000, Warranty_Period=3, TypeID=8, ProviderID=13},
                new Product{Name="MSI MPG GUNGNIR 110R", Count=10, Price=7000, Warranty_Period=3, TypeID=9, ProviderID=5},
                new Product{Name="Dell UltraSharp U2720Q", Count=8, Price=35000, Warranty_Period=3, TypeID=10, ProviderID=1},
                new Product{Name="Logitech G Pro X", Count=50, Price=8000, Warranty_Period=3, TypeID=11, ProviderID=1},
                new Product{Name="Razer DeathAdder V2", Count=40, Price=6000, Warranty_Period=3, TypeID=12, ProviderID=1},
                new Product{Name="Creative Sound Blaster Z", Count=15, Price=7000, Warranty_Period=3, TypeID=13, ProviderID=1},
                new Product{Name="TP-Link Archer T6E", Count=25, Price=3000, Warranty_Period=3, TypeID=14, ProviderID=1},
                new Product{Name="LG Ultra Slim Portable DVD Writer", Count=30, Price=2000, Warranty_Period=3, TypeID=14, ProviderID=1}
            };
            products.ForEach(s => context.Products.Add(s));

            var customers = new List<Customer>()
            {
                new Customer{FIO="Петров Петя Петрович", Phone="88005553535", Email="petr@gmail.com", Password="1234"},
                new Customer{FIO="Иванов Иван Иванович", Phone="88005553536", Email="ivanov@gmail.com", Password="password1"},
                new Customer{FIO="Сидоров Сидор Сидорович", Phone="88005553537", Email="sidorov@gmail.com", Password="password2"},
                new Customer{FIO="Кузнецов Алексей Алексеевич", Phone="88005553538", Email="kuznetsov@gmail.com", Password="password3"},
                new Customer{FIO="Смирнова Мария Ивановна", Phone="88005553539", Email="smirnova@gmail.com", Password="password4"},
                new Customer{FIO="Попов Дмитрий Сергеевич", Phone="88005553540", Email="popov@gmail.com", Password="password5"},
                new Customer{FIO="Васильева Анна Викторовна", Phone="88005553541", Email="vasilieva@gmail.com", Password="password6"},
                new Customer{FIO="Морозов Павел Владимирович", Phone="88005553542", Email="morozov@gmail.com", Password="password7"},
                new Customer{FIO="Новикова Ольга Николаевна", Phone="88005553543", Email="novikova@gmail.com", Password="password8"},
                new Customer{FIO="Михайлов Андрей Петрович", Phone="88005553544", Email="mihailov@gmail.com", Password="password9"}
            };
            customers.ForEach(s => context.Customers.Add(s));

            var orders = new List<Order>()
            {
                new Order{Date=DateTime.Parse("2005-09-01"), Total_Amount=19500, Status="Завершен", Product_Count=2, CustomerID=1},
                new Order{Date=DateTime.Parse("2006-03-15"), Total_Amount=25000, Status="В процессе", Product_Count=3, CustomerID=2},
                new Order{Date=DateTime.Parse("2007-07-21"), Total_Amount=37000, Status="Отменен", Product_Count=1, CustomerID=3},
                new Order{Date=DateTime.Parse("2008-11-30"), Total_Amount=12000, Status="Завершен", Product_Count=2, CustomerID=4},
                new Order{Date=DateTime.Parse("2009-05-19"), Total_Amount=45000, Status="В процессе", Product_Count=5, CustomerID=5},
                new Order{Date=DateTime.Parse("2010-10-22"), Total_Amount=30000, Status="Завершен", Product_Count=4, CustomerID=6},
                new Order{Date=DateTime.Parse("2011-04-10"), Total_Amount=22000, Status="Отменен", Product_Count=3, CustomerID=7},
                new Order{Date=DateTime.Parse("2012-08-15"), Total_Amount=18000, Status="Завершен", Product_Count=2, CustomerID=8},
                new Order{Date=DateTime.Parse("2013-01-05"), Total_Amount=31000, Status="В процессе", Product_Count=4, CustomerID=9},
                new Order{Date=DateTime.Parse("2014-12-25"), Total_Amount=27000, Status="Завершен", Product_Count=3, CustomerID=10}
            };

            orders.ForEach(s => context.Orders.Add(s));

            var product_in_order = new List<Product_in_Order>
            {
                new Product_in_Order {ProductID = 1, OrderID = 1, Count = 2},
                new Product_in_Order {ProductID = 2, OrderID = 2, Count = 1},
                new Product_in_Order {ProductID = 3, OrderID = 3, Count = 1},
                new Product_in_Order {ProductID = 4, OrderID = 4, Count = 2},
                new Product_in_Order {ProductID = 5, OrderID = 5, Count = 3},
                new Product_in_Order {ProductID = 6, OrderID = 6, Count = 1},
                new Product_in_Order {ProductID = 7, OrderID = 7, Count = 2},
                new Product_in_Order {ProductID = 8, OrderID = 8, Count = 1},
                new Product_in_Order {ProductID = 9, OrderID = 9, Count = 2},
                new Product_in_Order {ProductID = 10, OrderID = 10, Count = 1},
                new Product_in_Order {ProductID = 11, OrderID = 2, Count = 1},
                new Product_in_Order {ProductID = 12, OrderID = 5, Count = 1},
                new Product_in_Order {ProductID = 13, OrderID = 8, Count = 1},
                new Product_in_Order {ProductID = 14, OrderID = 1, Count = 1},
                new Product_in_Order {ProductID = 10, OrderID = 9, Count = 1}
            };


            product_in_order.ForEach(s => context.Product_in_Orders.Add(s));
            context.SaveChanges();
        }
    }
}
