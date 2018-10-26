using System;
using System.Collections;
using System.Data;
using System.Collections.Generic;
using System.Reflection;
namespace Serpis.Ad
{
	public class EntityDao<TEntity>
	{
		protected string idPropertyName = "Id";
		protected Type entityType = typeof(TEntity);
		protected IList<string> entityPropertyNames = new List<string>();

		public EntityDao(){
			foreach (PropertyInfo propertyInfo in entityType.GetProperties()){
				if (propertyInfo.Name == idPropertyName)
					entityPropertyNames.Insert(0, idPropertyName);
				else
					entityPropertyNames.Add(propertyInfo.Name);
			}
		
		
		}
		public IEnumerable Enumerable
        {
			get{
				
				ArrayList list = new ArrayList();
				IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand();

				string tableName = entityType.Name.ToLower();
				string fieldNamesCsv = string.Join(",", entityPropertyNames).ToLower();
				string selectSQL = string.Format(
					"select {0} from {1} order by {2}",
					fieldNamesCsv, tableName, idPropertyName.ToLower()
				);                             

				dbCommand.CommandText = selectSQL ;
				IDataReader dataReader = dbCommand.ExecuteReader();
				while(dataReader.Read())
				{
					object model = Activator.CreateInstance<TEntity>();
					foreach(string propertyName in entityPropertyNames)
					{
						object value = dataReader[propertyName.ToLower()];						
						entityType.GetProperty(propertyName).SetValue(model,value);
					}
					list.Add(model);
				}
					
				return list;
			}
        }
		public TEntity Load(object id){
            //TO DO implementar
			return default(TEntity);
		}
		public void Save(TEntity entity){
			object id = entityType.GetProperty(idPropertyName).GetValue(entity);
			if (id.Equals(default())) 
				;
			//TO DO implementar
		}
		public void Delete(Object id){
			//TO DO implementar
		}
    }
}
