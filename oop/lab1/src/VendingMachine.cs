using System;
using System.Collections.Generic;
using System.Linq;
namespace VendingMachine;


public class Coin
{
    private int _value;
    private int _count;
    public Coin(int value)
    {
        _value = value;
        _count = 1;
    }
    public int Value => _value;
    public int Count => _count;
    public void IncreaseCount()
    {
        _count += 1;
    }
}

public class Product
{
    private string _name;
    private int _price;
    private int _count;
    public Product(string name, int price, int count)
    {
        _name = name;
        _price = price;
        _count = count;
    }
    public string Name => _name;
    public int Price => _price;
    public int Count => _count;
    public override string ToString()
    {
        return $"{_name}| Цена: {_price}рб| Осталось: {_count}шт";
    }

    public void IncreaseCount(int count)
    {
        if (count <= 0)
            throw new ArgumentException("Количество не может быть отрицательным или нулевым");
        _count += count;
    }
    public void DecreaseCount(int count = 1)
    {
        if (count <= 0)
            throw new ArgumentException("Количество не может быть отрицательным или нулевым");
        _count -= count;
    }
}

public class VendingMachine
{
    private List<Product> _products = new List<Product>();
    private List<Coin> _bank = new List<Coin>();

    public void Menu()
    {
        if (_products.Count == 0)
        {
            Console.WriteLine("Товаров нет в наличии");
            return;
        }

        for (int i = 0; i < _products.Count; i++)
            Console.WriteLine($"{i + 1}) {_products[i]}");
    }

    public bool ChoiceIsValid(int product_id)
    {
        return (product_id >= 1 && product_id <= _products.Count);
    }

    public Product MakeChoice(int product_id)
    {
        if (_products[product_id - 1].Count < 1)
            throw new ArgumentException();
        Console.WriteLine($"Вы выбрали {_products[product_id - 1].Name}");

        return _products[product_id - 1];
    }

    public void AddCoin(Coin coin)
    {
        var existingCoin = _bank.FirstOrDefault(p => p.Value.Equals(coin.Value));

        if (existingCoin != null)
            existingCoin.IncreaseCount();
        else
            _bank.Add(coin);
    }

    public int Buy(Product product, List<Coin> userMoney)
    {
        int sumUserMoney = userMoney.Sum(coin => coin.Value);
        if (sumUserMoney < product.Price)
            throw new ArgumentException("Недостаточно средств");
        var actualProduct = _products.FirstOrDefault(p => p.Name == product.Name);
        if (actualProduct == null || actualProduct.Count < 1)
            throw new ArgumentException("Товар закончился");

        actualProduct.DecreaseCount(1);

        foreach (Coin coin in userMoney)
        {
            this.AddCoin(coin);
        }
        int change = sumUserMoney - product.Price;
        Console.WriteLine($"Спасибо за покупку! Ваша сдача: {change}рб");
        this.AddCoin(new Coin(-change));
        return sumUserMoney - product.Price;
    }

    public void AddProduct(Product product)
    {
        var existingProduct = _products.FirstOrDefault(p => p.Name.Equals(product.Name));

        if (existingProduct != null)
            existingProduct.IncreaseCount(product.Count);
        else
            _products.Add(product);
    }

    public int DailyProfit()
    {
        int profit = 0;
        foreach (Coin coin in _bank)
        {
            profit += coin.Count * coin.Value;
        }
        _bank.Clear();
        return profit;
    }
}
