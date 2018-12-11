package serpis.ad;

import java.sql.Connection;

public class App {
	private static App instance = new App();
	private Connection connection;
	
	private App() { }
	
	public static App getInstance() {
		return instance;
	}

	

	public Connection getConnection() {
		return connection;
	}

	public void setConnection(Connection connection) {
		this.connection = connection;
	}
}
