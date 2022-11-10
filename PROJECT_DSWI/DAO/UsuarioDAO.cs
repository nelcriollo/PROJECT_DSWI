using Microsoft.Data.SqlClient;
using System.Data;
using PROJECT_DSWI.Models;
using PROJECT_DSWI.DAO.DI;


namespace PROJECT_DSWI.DAO

{
    public class UsuarioDAO : IUsuario
    {
        IEnumerable<Usuario> IUsuario.listarUsuarios()
        {

            List<Usuario> listaUsua = new List<Usuario>();

            ConexionDAO cn = new ConexionDAO();

            using (cn.getcn)
            {
                cn.getcn.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SELECT idProducto, nomPrducto,descripcion,idCategoria,stock FROM tb_Producto", cn.getcn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        listaUsua.Add(new Usuario()
                        {
                            idProducto = dr.GetInt32(0),
                            nomproducto = dr.GetString(1),
                            descripcion = dr.GetString(2),
                            idCategoria = dr.GetInt32(3),
                            stock = dr.GetInt32(4),

                        });

                    }

                }
                catch (Exception)
                {

                    throw;
                }
            }
            return listaUsua;
        }
        

    }
}
