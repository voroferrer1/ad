
using System;
using Gtk;
using System.Data;
using MySql.Data.MySqlClient;
using CCategoria;
using System.Reflection;
namespace CCategoria
{
    public partial class CategoriaWindow : Gtk.Window
    {
        public CategoriaWindow() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
        }


		protected void OnButton2Clicked(object sender, EventArgs e)
		{
			button2.Clicked += delegate {
				IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand();
                dbCommand.CommandText = "insert into categoria (nombre) values (@nombre)";

                IDbDataParameter dbDataParameter = dbCommand.CreateParameter();
                dbDataParameter.ParameterName = "nombre";
                dbDataParameter.Value = entry1.Text;
                dbCommand.Parameters.Add(dbDataParameter);

                int filas = dbCommand.ExecuteNonQuery();
                
			};            
		}
	}
}
