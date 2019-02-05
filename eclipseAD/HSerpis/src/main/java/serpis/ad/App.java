package serpis.ad;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;

public class App {
	private static App app;
	public static synchronized App getInstance() {
		if(app == null) {
			app = new App();
		}
		return app;
	}
	public static void App() {
		entityManagerFactory = Persistence.createEntityManagerFactory("serpis.ad.hpedido");
		
		EntityManager entityManager = entityManagerFactory.createEntityManager();
		entityManager.getTransaction().begin();
	}
	public static EntityManagerFactory entityManagerFactory;
	
	public static EntityManagerFactory getEntityManagerFactory() {
		return entityManagerFactory;
	}
}
