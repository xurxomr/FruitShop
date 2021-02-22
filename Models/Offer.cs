using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitShop.Models
{
	class Offer
	{
		public int Id { get; set; }
		public int OffertTypeId { get; set; }
		public List<int> Params { get; set; }
	}
}
