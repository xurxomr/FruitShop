using FruitShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitShop.Services
{
	static class RecipeGenerator
	{
		public static void Generate(List<PurchaseLine> purchase)
		{
			Console.WriteLine("Products purchased:");
			purchase.ForEach(l => Console.WriteLine($"\t{DAL.DataContext.Fruits.FirstOrDefault(f => f.Id == l.FruidId).Description}\t\tx {l.Quantity}"));

			ApplyOffers(purchase);

			Console.WriteLine();
			Console.WriteLine($"Total: ");
		}

		private static void ApplyOffers(List<PurchaseLine> purchase)
		{
			Console.WriteLine($"Applied offers:");

			purchase.ForEach(l =>
			{
				List<Offer> offers = DAL.DataContext.Offers.Where(o => o.Params[0] == l.FruidId && o.Params[1] >= l.Quantity).ToList();

				offers.ForEach(o =>
				{
					string message = string.Format(DAL.DataContext.OfferTypes.Where(ot => ot.Id == o.OffertTypeId).FirstOrDefault().Description, o.Params);

					Console.WriteLine($"\t: {message}");
				});
			}
		}
	}
}
