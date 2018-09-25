
namespace David_Mvvm_lib.Helpers
{
	public class Wpf_StringHelper
	{
		public static string ConvertComobboxItemTotext(string rawValue)
		{
			int index = 0;
			if (rawValue != null)
			{
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
			return string.Empty;
		}

		public static bool IsMatch(string seachString, string searchedObject)
		{
			if(string.IsNullOrEmpty(searchedObject))
			{
				return false;
			}
			else if(seachString.ToUpper().Contains(searchedObject.ToUpper()))
			{
				return true;
			}
			return false;


		}
	}
}
