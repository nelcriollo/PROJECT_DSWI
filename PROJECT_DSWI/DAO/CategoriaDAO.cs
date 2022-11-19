using Microsoft.Data.SqlClient;
using System.Data;
using PROJECT_DSWI.Models;
using PROJECT_DSWI.DAO.DI;

namespace PROJECT_DSWI.DAO
{
    public class CategoriaDAO : ConexionDAO, ICategoria
    {

        IEnumerable<Categoria> ICategoria.GetCategorias()
        {

            List<Categoria> listaCateg = new List<Categoria>();
            using (SqlCommand cmd = new SqlCommand())
            {
                try
                {
                    using (cmd.Connection = getConexion())
                    {
                    
                        cmd.CommandText = "SELECT idCategoria,nombre  FROM tb_Categoria";
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection.Open();

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                listaCateg.Add(new Categoria()
                                {
                                    idCategoria = dr.GetInt32(0),
                                    nombre = dr.GetString(1),
                                });

                            }
                        }

                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    if (cmd.Connection.State == ConnectionState.Open)
                    {
                        cmd.Connection.Close();
                    }
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
