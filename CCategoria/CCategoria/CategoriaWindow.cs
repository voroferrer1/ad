using System;
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
			Console.WriteLine("Nombre = " + entry1.Text);
		}
	}
}
