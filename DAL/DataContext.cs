using FruitShop.Models;
using Newtonsoft.Json;
// using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace FruitShop.DAL
{
	static class DataContext
	{
		private const string _FILE_DATA_FRUITS = "fruits.json";
		private const string _FILE_DATA_OFFERS = "offers.json";
		private const string _FILE_DATA_OFFERTYPES = "offertypes.json";
		private const string _FILE_DATA_PURCHASE = "purchase.json";

		public static List<Fruit> Fruits { get; set; }
		public static List<Offer> Offers { get; set; }
		public static List<OfferType> OfferTypes { get; set; }
		public static List<PurchaseLine> Purchase { get; set; }

		public static void Initialize()
		{
			InitializeFruits();
			InitializeOfferTypes();
			InitializeOffers();
			InitializePurchase();
		}

		private static void InitializeFruits() => 
			Fruits = ReadFileData<List<Fruit>>(_FILE_DATA_FRUITS);

		private static void InitializeOfferTypes() =>
			OfferTypes = ReadFileData<List<OfferType>>(_FILE_DATA_OFFERTYPES);

		private static void InitializeOffers() =>
			Offers = ReadFileData<List<Offer>>(_FILE_DATA_OFFERS);
		
		private static void InitializePurchase() =>
			Purchase = ReadFileData<List<PurchaseLine>>(_FILE_DATA_PURCHASE);

		private static T ReadFileData<T>(string fileName)
		{
			string jsondata = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataFiles", fileName));
			return new JavaScriptSerializer().Deserialize<T>(jsondata);
		}
	}
}
