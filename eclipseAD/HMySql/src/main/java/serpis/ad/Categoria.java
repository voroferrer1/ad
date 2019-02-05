package serpis.ad;

import java.math.BigDecimal;

import javax.persistence.*;

@Entity
public class Categoria {
	@Id
	@GeneratedValue (strategy=GenerationType.IDENTITY)
	private Long id;
	private String nombre;
	
	private Categoria categoria;
	private BigDecimal precio;
	
	
	public Long getId() {
		return id;
	}

	public void setId(Long id) {
		this.id = id;
	}

	public String getNombre() {
		return nombre;
	}

	public void setNombre(String nombre) {
		this.nombre = nombre;
	}

	public Categoria getCategoria() {
		return categoria;
	}

	public void setCategoria(Categoria categoria) {
		this.categoria = categoria;
	}

	public BigDecimal getPrecio() {
		return precio;
	}

	public void setPrecio(BigDecimal precio) {
		this.precio = precio;
	}

}
