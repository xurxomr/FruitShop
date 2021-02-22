using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitShop
{
	class Program
	{
		static void Main(string[] args)
		{
			DAL.DataContext.Initialize();

			Services.RecipeGenerator.Generate(DAL.DataContext.Purchase);

			Console.ReadLine();
		}

	}
}
