using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Helpers
{
	public class Jwt
	{
		public string? ValidIssuer { get; set; }
		public string? ValidAudience { get; set; }
		public double DurtionInDays { get; set; }
		public string? Key { get; set; }
	}
}
