using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;

namespace EvernoteClone.WEB.Helpers
{
	public static class EnumHelper
	{
		public static string DisplayName(this Enum enumType)
		{
			return
				enumType
				.GetType()
				.GetMember(enumType.ToString())
			.First()
			.GetCustomAttribute<DisplayAttribute>()
			.Name;
		}
	}
}