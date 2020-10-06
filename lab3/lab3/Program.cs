using System;
using System.Collections.Generic;

namespace Lab3 {
	class Program {
		static void Main() {
			while (true) {
				Console.WriteLine(
					"1 - добавление нового продукта" +
					"\n2 - вывод всех продуктов в консоль" +
					"\n3 - поиск продуктов по наименованию и цене меньшей заданной" +
					"\n4 - сумма продуктов в данном наименовании" +
					"\nВыберите действие: ");
				int choice = Convert.ToInt32(Console.ReadLine());
				switch (choice) {
					case 1:
						AddName();
						break;
					case 2:
						foreach (var product in Product.Data) {
							Console.Write($"\nName: {product.Name}" + $"\nUPC :{ product.UPC}" +
								$"\nManufacter:{ product.Manufacter}" + $"\nPrice: { product.Price}" +
								$"\nStorage time: { product.StorageTime}" + $"\nNumber: { product.Number}\n");
						}
						break;
					case 3: {
						Console.Write("Введите наименование: ");
						string name = Console.ReadLine();
						Console.Write("Введите цену: ");
						int price = Convert.ToInt32(Console.ReadLine());
						List<Product> result = Product.GetUPC(ref name, ref price);
						if (result.Count == 0)
							Console.WriteLine("UPC товаров не найдено");
						else
							foreach (var Product in result) {
								Console.Write($"\nName: { Product.Name}" +
								$"\nUPC: {Product.UPC}" +
								$"\nManufacter: {Product.Manufacter}" +
								$"\nPrice: {Product.Price}" +
								$"\nStorage time: {Product.StorageTime}" +
								$"\nNumber: {Product.Number}" +
								$"\n");
							}
					}
					break;
					case 4: {
						Console.Write("Введите наименование: ");
						string find = Console.ReadLine();
						Console.Write($"Сумма продуктов: {Product.Sum(ref find)}");
					}
					break;
					default:
						Console.WriteLine("Число введено неверно");
						break;
				}
				Console.ReadLine();
				Console.Clear();
			}
		}
		private static void AddName() {
			string name, manufacter;
			int upc, price;
			float storageTime;
			int number;

			Console.Write("\nввести краткую инфу о продукте");

			Console.Write("\nВведите наименование: ");
			name = Console.ReadLine();
			Console.Write("Введите UPC: ");
			upc = Convert.ToInt32(Console.ReadLine());
			Console.Write("Введите проивзодителя: ");
			manufacter = Console.ReadLine();
			Console.Write("Введите цену: ");
			price = Convert.ToInt32(Console.ReadLine());
			Console.Write("Введите срок хранения: ");
			storageTime = Convert.ToInt32(Console.ReadLine());
			Console.Write("Введите количество: ");
			number = Convert.ToInt32(Console.ReadLine());

			Product product = new Product(name, upc, manufacter, price, storageTime, number);
			Product.Add(product);
			Console.WriteLine("Продукт добавлен");
		}
	}
}
