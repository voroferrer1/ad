package serpis.ad;

import java.util.ArrayList;
import java.util.Hashtable;
import java.util.List;
import java.util.Map;
import java.util.Scanner;

public class Menu {
	private static Scanner scanner = new Scanner(System.in);

	@FunctionalInterface
	public interface Action {
		void execute();
	}

	public static Menu create(String labelMenu) {
		return new Menu(labelMenu);
	}

	private String labelMenu;

	private Menu(String labelMenu) {
		this.labelMenu = labelMenu;
	}

	List<String> options = new ArrayList<>();
	List<String> labels = new ArrayList<>();
	Map<String,Action> actions = new Hashtable<>();

	public Menu add(String label, Action action) {
		String option = label.trim().substring(0, 1).toUpperCase();
		labels.add(label);
		actions.put(option , action);
		return this;
	}

	private boolean exit = false;

	public Menu exitWhen(String label) {
		return add(label, () -> exit = true);
	}

	public void loop() {
		// TODO implementar
		while (!exit) {
			System.out.println(labelMenu);
			labels.forEach(label -> System.out.println(label));
			System.out.println("Elige una opción");
			String option = scanner.nextLine();
			
			actions.getOrDefault(option, Menu::invalidOption).execute();
			
		}
	}
	private static void invalidOption() {
		System.out.println("Valor erroneo, intentalo de nuevo.");
	}
	

}
