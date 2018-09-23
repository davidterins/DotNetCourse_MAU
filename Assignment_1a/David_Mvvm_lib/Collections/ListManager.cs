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
	public class ListManager<T> : ObservableCollection<T>
	{


	  //int Count => m_List.Count;
		//private List<T> m_List;

		public ListManager()
		{
		//	m_List = new List<T>();
			
		}

		//public bool AddObject(T aType)
		//{
		//	m_List.Add(aType);
		//	return true;
		//}

		public bool BinaryDeSerialize(string fileName)
		{
			throw new NotImplementedException();
		}

		public bool BinarySerialize(string fileName)
		{
			foreach(T item in Items)
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
			foreach(T item in Items)
			{
				list.Add(item.ToString());
			}
			return list;
		}

		//public virtual bool XMLDeserialize(string fileName)
		//{
		//	ClearItems();
		//	//Items.Add(Serialization.Serialization.XmlFileDeserialize<T>(fileName));
		//	//var s = Serialization.Serialization.XmlFileDeserialize<T>(fileName);
		//	//Add(s);
			
		//	Serialization.Serialization.XMLDeserializeCollection(fileName, this);
		//	Console.WriteLine(Items.Count);
		//	return true;
		//}

		public virtual bool XMLSerialize(string fileName)
		{
			Serialization.Serialization.XMLSearializeCollection(fileName, this);
			//foreach (T item in Items)
			//{
			//	Serialization.Serialization.XmlFileSerialize<T>(fileName, item);
			//}
			return true;
		}

		
	}
}
