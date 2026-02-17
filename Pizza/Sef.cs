using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pizza
{
	internal class Sef
	{

		private PizzaKemence kemence;
		private static Random r = new Random();
		private static string[] pizzak =
		{
			"Margherita",
			"Sonkás",
			"Hawaii",
			"Négysajtos"
		};

		public Sef(PizzaKemence kemence)
		{
			this.kemence = kemence;
		}

		public void Futtat()
		{
			while (true)
			{
				Thread.Sleep(r.Next(2000, 3000));

				string nev = pizzak[r.Next(pizzak.Length)];
				int meret = r.Next(20, 41);

				Pizza ujPizza = new Pizza(nev, meret);

				kemence.FeladPizza(ujPizza);
				Console.WriteLine($"Séf készítette: {ujPizza}");
			}
		}
	}
}
