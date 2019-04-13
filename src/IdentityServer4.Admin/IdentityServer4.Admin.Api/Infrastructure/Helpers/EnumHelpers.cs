using System;
using System.Collections.Generic;
using System.Linq;
using IdentityServer4.Admin.Api.Infrastructure.UI;

namespace IdentityServer4.Admin.Api.Helpers
{
	public class EnumHelpers
	{
		public static List<SelectItem> ToSelectList<T>() where T : struct, IComparable
		{
			var selectItems = Enum.GetValues(typeof(T))
				.Cast<T>()
				.Select(x => new SelectItem(Convert.ToInt16(x), x.ToString())).ToList();

			return selectItems;
		}
	}
}