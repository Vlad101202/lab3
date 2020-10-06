using System.Collections.Generic;

namespace Lab3 {
	partial class Product {
		public static List<Product> Data { get; private set; }

		public string Name { get; private set; }
		public int UPC { get; private set; }
		public string Manufacter { get; private set; }
		public int Price { get; private set; }
		public float StorageTime { get; private set; }
		public int Number { get; private set; }
		public static int Counter { get; private set; }

		static Product() {
			Counter = 0;
			Data = new List<Product>
			{
				new Product("aaa", 123456, "aaaaa", 100, 30, 10),
				new Product("bbb", 234567, "bbbbb", 200, 30, 20),
				new Product("ccc", 345678, "ccccc", 300, 30, 30),
				new Product("ddd", 456789, "ddddd", 400, 30, 40),
				new Product("eee", 567890, "eeeee", 500, 30, 50),
				new Product("fff", 678901, "fffff", 600, 30, 60),
			};
			wtf2 = 123;
		}

		public Product() {
			Name = "-";
			UPC = 0;
			Manufacter = "-";
			Price = 0;
			StorageTime = 0;
			Number = 0;
			Counter++;
		}

		public Product(string name, int upc, string manufacter, int price, float storageTime, int number) {
			Name = name;
			UPC = upc;
			Manufacter = manufacter;
			Price = price;
			StorageTime = storageTime;
			Number = number;
			Counter++;
		}

		// Добавляет кол-во элементов к продукту
		public void Add(int amt) {
			Number += amt;
		}

		// Добавляет продукт в список продуктов
		public static void Add(Product product) {
			Data.Add(product);
			Counter++;
		}

		public static List<Product> GetUPC(ref string name, ref int price) {
			var list = new List<Product>();
			foreach (var Product in Data) {
				if (Product.Name == name && Product.Price < price)
					list.Add(Product);
			}
			return list;
		}

		public static int Sum(ref string name) {
			int sumProd = 0;
			foreach (var Product in Data) {
				if (Product.Name == name)
					sumProd += Product.Price * Product.Number;
			}
			return sumProd;
		}
	}
}