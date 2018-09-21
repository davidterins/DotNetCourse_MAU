
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
	}
}
