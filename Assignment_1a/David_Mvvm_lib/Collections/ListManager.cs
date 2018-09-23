using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using David_Mvvm_lib.Serialization;

namespace David_Mvvm_lib.Collections
{
	/// <summary>
	/// extension of observable collection to also serialilze its items.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class ListManager<T> : ObservableCollection<T>
	{

		public ListManager() { }

		public bool BinaryDeSerialize(string fileName)
		{
			throw new NotImplementedException();
		}

		public bool BinarySerialize(string fileName)
		{
			foreach (T item in Items)
			{
				Serialization.Serialization.BinaryFileSerialize(item, fileName);
			}
			return true;
		}

		public string[] ToStringArray()
		{
			var array = new string[Items.Count];
			for (int i = 0; i < Items.Count; i++)
			{
				array[i] = Items[i].ToString();
			}
			return array;
		}

		public List<string> ToStringList()
		{
			var list = new List<string>();
			foreach (T item in Items)
			{
				list.Add(item.ToString());
			}
			return list;
		}

		/// <summary>
		/// Serializes the items in the collection and save them to speciefied path
		/// </summary>
		/// <param name="fileName">file path</param>
		/// <returns></returns>
		public virtual bool XMLSerialize(string fileName)
		{
			Serialization.Serialization.XMLSearializeCollection(fileName, this);

			return true;
		}


	}
}
