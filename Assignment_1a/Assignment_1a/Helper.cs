using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1a
{
		public class Helper
    {
		 public static string ConvertComobboxItemTotext(string rawValue)
		{
			int index = 0;
			
			for (int i = 0; i < rawValue.Length; i++)
			{
				if (rawValue[i] == ':')
				{
					index = i + 2;
					break;
				}
				
			}
		  return rawValue.Substring(index);
		}

    }
}
