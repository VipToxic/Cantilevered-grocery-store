using System.Threading.Channels;

namespace Cantilevered_grocery_store
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                while (true)
                {


                    // Список продуктов
                    string[] products = {
                        "Яблоко весс 1шт 150 грм", // весс 150 грм
                        "Апельсин весс 1шт 150 грм", // весс 150 грм
                        "Картошка весс 1шт 100 грм", // 100 грм
                        "Бананы весс 1шт 150 грм", // 150 грм
                        "Котята весс 1шт 150 грм" // 150 грм
                     };

                    // Стоимость продуктов
                    int[] ProductCost = {
                        150,
                        250,
                        70,
                        150,
                        1000
                    };

                    double[] ProductWeight = { 
                        150,
                        150,
                        100,
                        150,
                        150
                    };

                    // количество продуктов
                    int[] productQuantity =
                    {
                        1000,
                        500,
                        3432,
                        238,
                        5
                    };


                    // Основная логика программы
                    Console.WriteLine("---ДОБРО ПОЖАЛОВАТЬ В МАГАЗИН МАГА БРАТ---");
                    Console.Write("Если хотите выйти из магазины введите quit если нет то просто enter: ");
                    string exit = Console.ReadLine();

                    // Проверяем хочет ли выйти пользователь из проограммы
                    if (exit == "quit")
                    {
                        Console.WriteLine("До свидания возврашайтесь снова..");
                        break;
                    }

                    // Выводим список продуктов
                    Console.WriteLine("---СПИСОК ПРОДУКТОВ---");
                    for (int i = 0; i < products.Length; i++)
                    {
                        Console.WriteLine($"Продукт {i + 1}: {products[i]}   Стоимость: {ProductCost[i]} рублей за кг\n");

                    }


                    // Переменная для размера корзины
                    // 6 потому что мы проверяем Numbers на false если нет то условие будет работать
                    int numbers = 6;

                    while (numbers >= 6)
                    {
                        // Просим ввести размер массива
                        Console.Write("Введите место для корзины в цифрах (макс 5): ");
                        numbers = int.Parse(Console.ReadLine());

                        // Проверяем введенное число больше или равно к 6 если false то 
                        // итерация заканчиваеться
                        if (numbers >= 6)
                        {
                            // Если да то мы пропускаем его и просим заново ввести
                            Console.WriteLine($"Вы ввели {numbers} введите число в диапазоне от 1 до 5");
                            continue;
                        }

                    }


                    // Создаем массив как корзину
                    int[] keybordBasketArray = new int[numbers];
                    Console.WriteLine("Размер корзины:" + (numbers));

                    // Это переменная для получение номера продукта
                    // оно равен к -1 потому что у нас есть условие который проверяет переменную к 0
                    int itemNumber = -1;

                    // Проходимся по циклу
                    for (int i = 0; i < keybordBasketArray.Length; i++)
                    {
                        // Просим ввести номер товара
                        Console.Write("Введите номер товаров которых хотите купить. '0' если хотите выйти: ");
                        itemNumber = int.Parse(Console.ReadLine());

                        // проверяем переменную на 0
                        if (itemNumber == 0)
                        {
                            // если значение true то заканчиваем цикл
                            Console.WriteLine("До свидания возврашайтесь снова..");
                            break;
                        }

                        // если значение false то к текушему индексу "i" добовляем полученное значение
                        keybordBasketArray[i] = itemNumber;
                    }

                    // Вторая проверка для выхода из основного цикла
                    if (itemNumber == 0)
                    {
                        break;
                    }

                    Console.WriteLine();
                    // Вывод списка продуктов
                    Console.WriteLine("---Ваш список продуктов---");

                    // Проходимся по всему массиву
                    for (int i = 0; i < keybordBasketArray.Length; i++)
                    {
                        Console.WriteLine(
                            // Мы с начала обрашаемся к массиву keybordBasketArray от туда вытаскиваем значение после чего вычитаем 1
                            // ведь индексы начинаеться с 0 если оставить как есть то
                            // например вместо апельсина выведиться картошка.

                            $"Продукт под номером {i + 1}: {products[keybordBasketArray[i] - 1]} " +
                            $"стоимость: {ProductCost[keybordBasketArray[i] - 1]} рублей в кг" +
                            $" количество в наличии {productQuantity[keybordBasketArray[i] - 1]}"

                            );

                    }

                    // Ввод количиство продуктов
                    Console.WriteLine();
                    int[] keybordQuantityArray = new int[numbers];

                    int itemNumberQ = -1;

                    for (int i = 0; i < keybordQuantityArray.Length; i++)
                    {
                        
                        bool stoping = true;
                        while (stoping == true)
                        {
                            // Просим ввести количиство n ного товара
                            Console.WriteLine("Введите '0' если хотите выйти");
                            Console.Write($"Введите количиство: {products[keybordBasketArray[i] - 1]} " +
                                          $"в наличии: {productQuantity[keybordBasketArray[i] - 1]}: ");
                            itemNumberQ = int.Parse(Console.ReadLine());

                            // проверяем переменную на 0
                            if (itemNumberQ == 0)
                            {
                                // если значение true то заканчиваем цикл
                                Console.WriteLine("До свидания возврашайтесь снова..");
                                break;
                            }
                            if (itemNumberQ > productQuantity[keybordBasketArray[i] - 1])
                            {
                                Console.WriteLine($"Недостаточно товаров в наличии {productQuantity[keybordBasketArray[i] - 1]} штук");
                                continue;
                            }
                            else
                            {
                                //если значение false то к текушему индексу "i" добовляем полученное значение
                                keybordQuantityArray[i] = itemNumberQ;
                                stoping = false;
                            }

                            // проверяем переменную на 0
                            if (itemNumberQ == 0)
                            {
                                Console.WriteLine("До свидания возврашайтесь снова..");
                                break;
                            }
                        }


                    }

                    // Вторая проверка для выхода из основного цикла
                    if (itemNumberQ == 0)
                    {
                        break;
                    }

                    // Итоговый расчет весса и продуктов
                    double[] finalWeightOfProducts = new double[numbers];

                    // Вычисляем весс товара 
                    for (int i = 0; i < finalWeightOfProducts.Length; i++)
                    {

                        double result = keybordQuantityArray[i] * ProductWeight[keybordBasketArray[i] - 1];
                        result = result / 1000;

                        finalWeightOfProducts[i] = result;

                    }

                    // Расчет ценыы продуктов
                    double[] finalPriceOfProducts = new double[numbers];
                    Console.WriteLine("-------Итоговая цена------");
                    for (int i = 0; i < finalPriceOfProducts.Length; i++)
                    {
                        double price = ProductCost[keybordBasketArray[i] - 1] * finalWeightOfProducts[i];
                        finalPriceOfProducts[i] = price;
                        Console.WriteLine($"Продукт {i + 1}: {products[keybordBasketArray[i] - 1]}, итоговый весс: {finalWeightOfProducts[i]}, стоимость: {finalPriceOfProducts[i]}");
                    }
                    Console.WriteLine($"");


                    // Итоговый расчет
                    double finSum = 0;

                    for (int i = 0; i < finalPriceOfProducts.Length; i++)
                    {
                        finSum += finalPriceOfProducts[i];
                    }


                    // Получение оплаты
                    double finalPayment = 0;
                    double change = 0;
                    while (finalPayment < finSum)
                    {
                        Console.WriteLine("Введите '0' если хотите выйти...");
                        Console.Write($"К оплате, {finSum} рублей: ");

                        // Получаем оплату
                        double finalPayment2 = double.Parse(Console.ReadLine());
                        finalPayment = finalPayment2;

                        // считаем сдачу
                        if (finalPayment > finSum)
                        {
                            change = finalPayment - finSum;
                        }

                        if (finalPayment == 0)
                        {
                            break;
                        }

                        if (finalPayment < finSum)
                        {
    
                            Console.WriteLine("Введенная сумма недостаточно!");
                            continue;
                        }
                    }

                    if (finalPayment == 0)
                    {
                        Console.WriteLine("Спасиобо что пришли удачного вам дня...");
                        break;
                    }

                    Console.WriteLine("Оплата прошла успешно возврашайтесь снова :)");
                    Console.WriteLine("Ваша сдача: " + change + " рублей");

                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Введите коректные данные: {ex.Message}");
            }
            catch (OverflowException ex)
            {
                Console.WriteLine($"Длина массива не может быть отрицательным: {ex.Message}");
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine($"Размер массива переполнен: {ex.Message}");
            }
        }
    }
}
