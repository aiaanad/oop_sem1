using System;
using System.Collections.Generic;
using System.Linq;
namespace VendingMachine;


public class Program
{
    private static VendingMachine _vendingMachine = new VendingMachine();

    public static void Main()
    {
    
        Console.WriteLine("\n\n\nВыберите режим: Администратор - 0, Покупатель - 1");
        string input = Console.ReadLine();
        if (int.TryParse(input, out int mode))
        {
            if (mode == 0)
            {
                Console.Clear();
                while (true)
                {
                    DisplayAdminMenu();
                    string actionInput = Console.ReadLine();
                    if (int.TryParse(actionInput, out int action) && (action == 3 || action == 4 || action == 5 || action == 0))
                        DoAction(action);
                    else
                        ShowError("Выберите из 0, 3, 4, 5");
                }


            }
            else if (mode == 1)
            {
                Console.Clear();
                while (true)
                {
                    DisplayUserMenu();
                    string actionInput = Console.ReadLine();

                    if (int.TryParse(actionInput, out int action) && (action >= 0 && action <= 3))
                        DoAction(action);
                    else
                        ShowError("Введите целое число от 0 до 3");
                }

            }
            else
            {
                ShowError("Введите 0 или 1");
                Main();
            }
        }
                
        else
        {
            ShowError("Введите число");
            Main();
        }
        
    }

    private static void DisplayUserMenu()
    {
        Console.WriteLine("\n-----------------------------");
        Console.WriteLine("=== ВЕНДИНГОВЫЙ АППАРАТ ===");
        Console.WriteLine("1. Показать меню");
        Console.WriteLine("2. Купить товар");
        Console.WriteLine("3. Поменять режим пользователя");
        Console.WriteLine("0. Выйти из программы");
        Console.WriteLine("-----------------------------");
        Console.Write("Выберите действие: ");
    }
    private static void DisplayAdminMenu()
    {
        Console.WriteLine("\n-----------------------------");
        Console.WriteLine("=== ВЕНДИНГОВЫЙ АППАРАТ ===");
        Console.WriteLine("3. Поменять режим пользователя");
        Console.WriteLine("4. Пополнение ассортимента");
        Console.WriteLine("5. Сбор средств");
        Console.WriteLine("0. Выйти из программы");
        Console.WriteLine("-----------------------------");
        Console.Write("Выберите действие: ");
    }
    private static void DoAction(int action)
    {
        switch (action)
        {
            case 0:
                if (ConfirmExit())
                    Environment.Exit(0);
                break;

            case 1:
                _vendingMachine.Menu();
                break;

            case 2:
                Console.Write("Введите номер товара: ");
                string productInput = Console.ReadLine();
                if (int.TryParse(productInput, out int product_id) && _vendingMachine.ChoiceIsValid(product_id))
                {
                    try
                    {
                        Product product = _vendingMachine.MakeChoice(product_id);
                        
                        Console.WriteLine("Введите через пробелы номиналы своих монет");
                        Console.WriteLine("-----------------------------");
                        string moneyInput = Console.ReadLine();
                        var parts = moneyInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                        if (parts.Length > 0 && parts.All(x => int.TryParse(x, out _)))
                        {
                            List<Coin> userMoney = parts.Select(x => new Coin(int.Parse(x))).ToList();
                            _vendingMachine.Buy(product, userMoney);
                        }
                        else
                            ShowError("Введите целые числа!");
                    }
                    catch
                    {
                        ShowError("Извините, товар закончился. Выберите другой");
                    }
                }
                else
                    ShowError("Неверный ввод");
                break;

            case 3:
                Main();
                break;

            case 4:
                Console.WriteLine("Введите данные в формате: имя товара, цена, количество");
                Console.WriteLine("Пример: Шоколад молочный, 50, 10");
                Console.WriteLine("-----------------------------");
                string input;

                while (true)
                {
                    input = Console.ReadLine();
                    if (string.IsNullOrEmpty(input)) break;

                    string[] parts3 = input.Split(',');


                    if (parts3.Length == 3 &&
                        int.TryParse(parts3[1], out int price) && price > 0 &&
                        int.TryParse(parts3[2], out int count) && count > 0)
                    {
                        _vendingMachine.AddProduct(new Product(parts3[0], price, count));
                        Console.WriteLine("-----------------------------");
                        Console.WriteLine($"Продукт '{parts3[0]}' добавлен");
                    }
                    else
                    {
                        ShowError("Неверный формат данных ;(");
                    }

                    Console.WriteLine("Продолжайте ввод или пустая строка для завершения");
                    Console.WriteLine("-----------------------------");
                }
                Console.WriteLine("Текущий ассортимент: \n");
                _vendingMachine.Menu();
                break;


            case 5:
                int profit = _vendingMachine.DailyProfit();
                Console.WriteLine($"За сегодняшний день заработано: {profit}рб");
                break;
        }

        Console.WriteLine("Нажмите любую клавишу для продолжения...");
        Console.ReadKey();
    }

    private static bool ConfirmExit()
    {
        while (true)
        {
            Console.Write("Вы уверены, что хотите выйти? (Y/N): ");
            string input = Console.ReadLine();
            if (input == null) continue;
            
            input = input.Trim().ToUpper();

            if (input == "Y")
                return true;
            else if (input == "N")
                return false;
            else
                Console.WriteLine("Пожалуйста, введите Y или N.");
        }
    }

    private static void ShowError(string message)
    {
        Console.WriteLine(message);
        Console.WriteLine("Нажмите любую клавишу для продолжения...");
        Console.ReadKey();
    }
}