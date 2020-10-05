using Lab3;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter;
            while (true) {
                Console.WriteLine("Выберите действие:\n1 - добавление нового продукта.\n2 - вывод всех продуктов в консоль.\n3 - поиск продуктов по наименованию и цене меньшей заданной." +
                    "\n4 - сумма продуктов в данном наименовании");
                counter = Convert.ToInt32(Console.ReadLine());
                switch (counter)
                {
                    case 1:
                        AddName();
                        break;
                    case 2:
                        foreach (var product in Product.Data)
                        {
                            Console.Write($"\nName: {product.Name}" + $"\nUPC :{ product.UPC}" +
                                $"\nManufacter:{ product.Manufacter}" + $"\nPrice: { product.Price}" +
                                $"\nStorage time: { product.Storage_time}" + $"\nNumber: { product.Number}\n");
                        }
                        break;
                    case 3:
                        {
                            Console.Write("Введите наименование: ");
                            string find = Console.ReadLine();
                            Console.Write("Введите цену: ");
                            int findd = Convert.ToInt32(Console.ReadLine());
                            List<Product> result = Product.GetUPC(ref find, ref findd);
                            if (result.Count == 0) Console.WriteLine("UPC товаров не найдено");
                            else
                                foreach (var Product in result)
                                {
                                    Console.Write($"\nName: { Product.Name}" +
                                    $"\nUPC: {Product.UPC}" +
                                    $"\nManufacter: {Product.Manufacter}" +
                                    $"\nPrice: {Product.Price}" +
                                    $"\nStorage time: {Product.Storage_time}" +
                                    $"\nNumber: {Product.Number}" +
                                    $"\n");
                                }
                        }
                        break;
                    case 4:
                        {
                            Console.Write("Введите наименование: ");
                            string find = Console.ReadLine();
                            Console.Write("Сумма продуктов: ");
                            List<Product> result = Product.Summa(ref find);     
                        }
                        break;
                    default:
                        Console.WriteLine("Число введено неверно");
                        break;
                }
            }
        }
        private static void AddName()
        {
            Product Product;
            string name, manufacter;

            Console.Write("\nввести краткую инфу о продукте");

            Console.Write("\nВведите наименование: ");
            name = Console.ReadLine();

            long upc, price;
            float storage_time;
            int number;

            Console.Write("\nВведите UPC: ");
            upc = Convert.ToInt64(Console.ReadLine());
            Console.Write("\nВведите проивзодителя: ");
            manufacter = Console.ReadLine();
            Console.Write("\nВведите цену:");
            price = Convert.ToInt64(Console.ReadLine());
            Console.Write("\nВведите срок хранения: ");
            storage_time = Convert.ToInt64(Console.ReadLine());
            Console.Write("Введите количество: ");
            number = Convert.ToInt32(Console.ReadLine());


            Product = new Product(name, upc, manufacter, price, storage_time, number);
            Product.Add(Product);
            Console.WriteLine("Продукт добавлен");
        }
    }
}
