using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
namespace CMySQL
{
    class MainClass
    {
		private static string[] getFieldNames(IDataReader dataReader){
			List<string> fieldList = new List<string>();
			fields.Add(dataReader.FieldCount.ToString());
			for (int index = 0; index < dataReader.FieldCount; index++)
			{
				fields.Add("Columna = " + dataReader.GetName(index)); 
			}
			return fieldList.ToArray();
		}
        public static void Main(string[] args)
        {
			IDbConnection dbConnection = new MySqlConnection(
				"server=localhost;database=dbprueba;user=root;password=sistemas; ssl-mode=none;");
			dbConnection.Open();

			IDbCommand dbCommand = dbConnection.CreateCommand();
			dbCommand.CommandText = "select * from categoria order by id";
			IDataReader dataReader = dbCommand.ExecuteReader();

			string[] fieldNames = getFieldNames(dataReader);
			foreach (string fieldName in fieldNames)
				Console.WriteLine(fieldName);
			/*Console.WriteLine("Numero de Columnas="+dataReader.FieldCount);
			for (int index = 0; index < dataReader.FieldCount;index++){
				Console.WriteLine("Columna{0}={1}", index, dataReader.GetName(index));
			}*/

			/*while (dataReader.Read()){
				Console.WriteLine("id={0} nombre{1}",dataReader["id"],dataReader["nombre"]);
			}*/
			dataReader.Close();
			dbConnection.Close();
        }
    }
}
