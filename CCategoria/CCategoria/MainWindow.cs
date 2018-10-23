using System;
using Gtk;
using System.Data;
using MySql.Data.MySqlClient;
using CCategoria;
using System.Reflection;
using Serpis.Ad;
public partial class MainWindow : Gtk.Window
{
	public MainWindow() : base(Gtk.WindowType.Toplevel)
	{
		Build();


		TreeViewHelper.Fill(treeView, new string[]{"Id","Nombre"},CategoriaDao.Categorias);

		newAction.Activated += delegate {
			new CategoriaWindow(new Categoria());

		};
		treeView.Selection.Changed += delegate{
			refreshUI();
		};
		editAction.Activated += delegate{
			treeView.Selection.GetSelected(out TreeIter treeIter);

			Categoria categoria = (Categoria)treeView.Model.GetValue(treeIter,0);
			Console.WriteLine("Categoria Id = " + GetId(treeView));
		};

		refreshUI();

    }
	private void refreshUI(){
		bool treeViewIsSelected = treeView.Selection.CountSelectedRows() > 0;
		editAction.Sensitive = treeViewIsSelected;
		deleteAction.Sensitive = treeViewIsSelected;

	}
	public static object GetId(TreeView treeView){
		return Get(treeView, "Id");
	}
	public static object Get(TreeView treeView,string propertyName){
		if (!treeView.Selection.GetSelected(out TreeIter treeIter))
			return null;
		object model = treeView.Model.GetValue(treeIter, 0);
		return model.GetType().GetProperty(propertyName).GetValue(model);
	}

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
		Application.Quit();
        a.RetVal = true;
    }
}
