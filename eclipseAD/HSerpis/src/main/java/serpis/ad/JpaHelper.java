package serpis.ad;

import java.util.function.Consumer;
import java.util.function.Function;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;


public class JpaHelper {
	public static void execute(Consumer<EntityManager> consumer) {
		App.getInstance();
		execute(App.getEntityManagerFactory(),consumer);
	}
	
	public static void execute(EntityManagerFactory entityManagerFactory, Consumer<EntityManager> consumer) {
		EntityManager entityManager = entityManagerFactory.createEntityManager();
		entityManager.getTransaction().begin();
		consumer.accept(entityManager);
		entityManager.getTransaction().commit();
		entityManager.close();
	}

	public static <R> R execute(EntityManagerFactory entityManagerFactory, Function<EntityManager, R> function) {
		EntityManager entityManager = entityManagerFactory.createEntityManager();
		entityManager.getTransaction().begin();

		R result = function.apply(entityManager);

		entityManager.getTransaction().commit();
		entityManager.close();
		return result;
	}
}
