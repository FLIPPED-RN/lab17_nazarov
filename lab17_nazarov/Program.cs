//18, средний уровень
try
{
    Console.WriteLine("Введите количество товаров: ");
    int productCount = int.Parse(Console.ReadLine());
    Product[] products = new Product[productCount];

    for (int i = 0; i < productCount; i++)
    {
        products[i] = new Product();
        Console.Write("Введите наименование товара: ");
        products[i].Name = Console.ReadLine();
        Console.Write("Введите цену товара: ");
        products[i].Price = decimal.Parse(Console.ReadLine());
        Console.Write("Введите дату производства товара (гггг-мм-дд): ");
        products[i].ProductionDate = DateTime.Parse(Console.ReadLine());
        Console.Write("Введите срок годности товара (в днях): ");
        products[i].ShelfLife = int.Parse(Console.ReadLine());
        Console.Write("Введите количество товара: ");
        products[i].Quantity = int.Parse(Console.ReadLine());
        Console.Write("Введите производителя товара: ");
        products[i].Manufacturer = Console.ReadLine();
    }

    int expiredProductsCount = 0;

    foreach (Product product in products)
    {
        int daysRemaining = (product.ProductionDate.AddDays(product.ShelfLife) - DateTime.Now).Days;

        if (daysRemaining < 20)
        {
            Console.WriteLine($"Наименование: {product.Name}");
            Console.WriteLine($"Цена: {product.Price}");
            Console.WriteLine($"Дата производства: {product.ProductionDate.ToShortDateString()}");
            Console.WriteLine($"Срок годности: {product.ShelfLife} дней");
            Console.WriteLine($"Количество: {product.Quantity}");
            Console.WriteLine($"Производитель: {product.Manufacturer}");
            Console.WriteLine($"Дней до истечения срока годности: {daysRemaining}");
            Console.WriteLine();

            if (daysRemaining < 0)
            {
                expiredProductsCount++;
            }
        }
    }

    Console.WriteLine($"Количество просроченных товаров: {expiredProductsCount}");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

struct Product
{
    public string Name;
    public decimal Price;
    public DateTime ProductionDate;
    public int ShelfLife;
    public int Quantity;
    public string Manufacturer;
}