using Microsoft.Data.SqlClient;
using System.Data;
using PROJECT_DSWI.Models;
using PROJECT_DSWI.DAO.DI;

namespace PROJECT_DSWI.DAO
{
    public class CategoriaDAO :ICategoria
    {

        IEnumerable<Categoria> ICategoria.GetCategorias()
        {

            List<Categoria> listaCateg = new List<Categoria>();

            ConexionDAO cn = new ConexionDAO();

            using (cn.getcn)
            {
                cn.getcn.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SELECT idCategoria,nombre  FROM tb_Categoria", cn.getcn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        listaCateg.Add(new Categoria()
                        {
                            idCategoria = dr.GetInt32(0),
                            nombre = dr.GetString(1),

                        });

                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return listaCateg;
        }

        string ICategoria.ActualizarCategoria(Categoria reg)
        {
            throw new NotImplementedException();
        }

        string ICategoria.insertCategoria(Categoria reg)
        {
            throw new NotImplementedException();
        }

    }
}
