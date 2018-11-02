using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml.Serialization;
using David_Mvvm_lib.Models;

namespace David_Mvvm_lib.Serialization
{
	public static class Serialization
	{
		public static string BinaryFileSerialize(Object obj, string filePath)
		{
			FileStream fileStream = null; string errorMsg = null;
			try
			{
				fileStream = new FileStream(filePath, FileMode.Create);
				BinaryFormatter b = new BinaryFormatter(); b.Serialize(fileStream, obj);
			}
			catch (Exception e)
			{ errorMsg = e.Message; }
			finally
			{
				if (fileStream != null)
					fileStream.Close();
			}
			return errorMsg;
		}
		public static T BinaryFileDeSerialize<T>(string filePath, out string errorMessage)
		{
			FileStream fileStream = null; errorMessage = null;
			Object obj = null;
			try
			{
				if (!File.Exists(filePath))
				{
					errorMessage = $"The file {filePath}  was not found. ";
					throw (new FileNotFoundException(errorMessage));
				}
				fileStream = new FileStream(filePath, FileMode.Open);
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                obj = binaryFormatter.Deserialize(fileStream);
			}
			catch (Exception e)
			{
				if (errorMessage != null)
					//error msg already filled from above                 
					errorMessage = e.Message;
			}
			finally { if (fileStream != null) fileStream.Close(); }
			return (T)obj;
		}

		public static void XmlFileSerialize<T>(string filePath, T obj)
		{
			XmlSerializer s = new XmlSerializer(typeof(T), new Type[] {typeof(ResidentialRealEstateModel), typeof(ComercialRealEstateModel)});
			TextWriter w = new StreamWriter(filePath);
			try { s.Serialize(w, obj); }
			catch { throw; }
			finally { if (w != null) w.Close(); }
		}

		public static T XmlFileDeserialize<T>(string filePath)
		{
			XmlSerializer s = new XmlSerializer(typeof(T), new Type[] { typeof(ResidentialRealEstateModel), typeof(ComercialRealEstateModel) });
			TextReader r = new StreamReader(filePath);
			try
			{
				return (T)s.Deserialize(r);
			}
			catch
			{
				throw;
			}
			finally
			{
				if (r != null)
				{
					r.Close();
				}
			}
		}

		public static void XMLSearializeCollection<T>(string filePath, T collection)
		{
			using (Stream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
			{
				XmlSerializer xmlformat = new XmlSerializer(typeof(T), new Type[] { typeof(ResidentialRealEstateModel), typeof(ComercialRealEstateModel) });
				xmlformat.Serialize(stream, collection);
			}
		}

		public static T XMLDeserializeCollection<T>(string filePath)
		{
			using (Stream stream = File.Open(filePath, FileMode.Open))
			{
				XmlSerializer xmlformat = new XmlSerializer(typeof(T), new Type[] { typeof(ResidentialRealEstateModel), typeof(ComercialRealEstateModel) });
				return (T)xmlformat.Deserialize(stream);
			}
		}

		public static void XMLDeserializeCollection<T>(string filePath, ref T collection)
		{
			using (Stream stream = File.Open(filePath, FileMode.Open))
			{
				XmlSerializer xmlformat = new XmlSerializer(typeof(T), new Type[] { typeof(ResidentialRealEstateModel), typeof(ComercialRealEstateModel) });
				collection = (T)xmlformat.Deserialize(stream);
			}
		}

	}
}
