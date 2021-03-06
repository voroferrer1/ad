package serpis.ad;

//import java.math.BigInteger;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.List;

public class CategoriaDao {
	
	private static String insertSql = "insert into categoria (nombre) values (?)";
	private static int insert(Categoria categoria) throws SQLException {
		PreparedStatement preparedStatement = App.getInstance().getConnection().prepareStatement(insertSql);
		preparedStatement.setObject(1, categoria.getNombre());
		return preparedStatement.executeUpdate();
	}
	
	//private static String updateSql = "update categoria set nombre=? where id=?";
	private static int update(Categoria categoria) throws SQLException {
		return -1; //TODO implementar
	}

	public static int save(Categoria categoria) throws SQLException {
		if (categoria.getId() == 0)
			return insert(categoria);
		else
			return update(categoria);
	}
	
	private static final String select = "select id, nombre from categoria where id =(?)"; 
	public static Categoria load(long id) throws SQLException {
		PreparedStatement preparedStatement = App.getInstance().getConnection().prepareStatement(select);
		preparedStatement.setObject(1, id);
		ResultSet result = preparedStatement.executeQuery();
		if(result.next()) {
			Categoria categoria = new Categoria();
			categoria.setId(result.getLong("id"));
			categoria.setNombre((String)result.getObject("nombre"));
			return categoria;
		}
		return null;
	}
	//private static final String delete = "delete from categoria where id =(?)"; 
	public static int delete(long id) throws SQLException {
		return -1;
	}

	private static final String selectAll = "select id, nombre from categoria"; 
	public static List<Categoria> getAll() throws SQLException {
		List<Categoria> categorias = new ArrayList<>();
		Statement statement = App.getInstance().getConnection().createStatement();
		ResultSet resultSet = statement.executeQuery(selectAll);
		while (resultSet.next()) {
			Categoria categoria = new Categoria();
			//categoria.setId( ((BigInteger)resultSet.getObject("id")).longValue() );
			categoria.setId( resultSet.getLong("id") );
			categoria.setNombre((String)resultSet.getObject("nombre"));
			categorias.add(categoria);
		}
		return categorias;
	}
}
