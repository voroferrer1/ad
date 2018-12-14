package serpis.ad;

import java.util.List;
import java.util.Scanner;

public class CategoriaConsole {
	
	public static long getId() {
		Scanner sc = new Scanner(System.in);
		Long i;
		while(true) {
			System.out.println("Introduce la id a consultar:");
			i = sc.nextLong();
			return (long)i;		
		}
	}
	
	public static void newCategoria(Categoria categoria) {
		
		
	}
	
	
	public static void editCategoria(Categoria categoria) {
		
	}

	public static void idNotExists() {
		
	}
	
	public static boolean deleteConfirm() {
		return false; 
	}
	
	public static void show(Categoria categoria) {
		System.out.printf("%4s %-20s %n", categoria.getId(), categoria.getNombre());
	}
	
	public static void showList(List<Categoria> categorias) {
		for (Categoria categoria : categorias) {
			System.out.printf("%4s %-20s %n", categoria.getId(), categoria.getNombre());
		}
		
	}
	
}

