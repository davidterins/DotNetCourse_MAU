using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using David_Mvvm_lib.Serialization;

namespace David_Mvvm_lib.Collections
{
	public class ListManager<T> : ObservableCollection<T>, IListManager<T>
	{
	
		private List<T> m_List;

		public ListManager()
		{
			m_List = new List<T>();
		}

		public bool Add(T aType)
		{
			m_List.Add(aType);
			return true;
		}

		public bool BinaryDeSerialize(string fileName)
		{
			throw new NotImplementedException();
		}

		public bool BinarySerialize(string fileName)
		{
			foreach(T item in m_List)
			{
				Serialization.Serialization.BinaryFileSerialize(item, fileName);
			}
			return true;
		}

		public bool ChangeAt(T aType, int anIndex)
		{
			if (CheckIndex(anIndex))
			{
				m_List[anIndex] = aType;
				return true;
			}
			else return false;
		
		}

		public bool CheckIndex(int index)
		{
			if(m_List.Count > index)
			{
				return true;
			}
			return false;
		}

		public void DeleteAll()
		{
			m_List.Clear();
		}

		public bool DeleteAt(int anIndex)
		{
			m_List.RemoveAt(anIndex);
			return true;
		}

		public T GetAt(int anIndex)
		{
			return m_List[anIndex];
		}

		public string[] ToStringArray()
		{
			var array = new string[m_List.Count];
		  for (int i = 0; i < m_List.Count; i++)
			{
				array[i] = m_List[i].ToString();
			}
			return array;
		}

		public List<string> ToStringList()
		{
			var list = new List<string>();
			foreach(T item in m_List)
			{
				list.Add(item.ToString());
			}
			return list;
		}

		public bool XMLSerialize(string fileName)
		{
			foreach (T item in m_List)
			{
				Serialization.Serialization.XmlFileSerialize<T>(fileName, item);
			}
			return true;
		}

	}
}
