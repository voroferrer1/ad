﻿using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
namespace CMySQL
{
    class MainClass
    {
		private static string[] getFieldNames(IDataReader dataReader){
			int fieldCount = dataReader.FieldCount;
			string[] fieldNames = new string[fieldCount];
			for (int index = 0; index < fieldCount; index++){
				fieldNames[index] = dataReader.GetName(index);
			}

			return fieldNames;
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
				Console.WriteLine("Columna = "+fieldName);
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