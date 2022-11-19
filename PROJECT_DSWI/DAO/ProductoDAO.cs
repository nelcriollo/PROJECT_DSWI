using Microsoft.Data.SqlClient;
using System.Data;
using PROJECT_DSWI.Models;
using PROJECT_DSWI.DAO.DI;

namespace PROJECT_DSWI.DAO
{
    public class ProductoDAO : ConexionDAO, IProducto

    {
        IEnumerable<Producto> IProducto.listarTodos()
        {

            List<Producto> listaProd = new List<Producto>();

            using (SqlCommand cmd = new SqlCommand())
            {
                try
                {
                    using (cmd.Connection = getConexion())
                    {
                        cmd.CommandText = "SELECT idProducto, nomProducto,descripcion,idCategoria,stock FROM tb_Producto";
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Clear();
                        cmd.Connection.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {

                            while (dr.Read())
                            {
                                listaProd.Add(new Producto()
                                {
                                    idProducto = dr.GetInt32(0),
                                    nomproducto = dr.GetString(1),
                                    descripcion = dr.GetString(2),
                                    idCategoria = dr.GetInt32(3),
                                    stock = dr.GetInt32(4),

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
            return listaProd;
        }

        string IProducto.ActualizarProducto(Producto reg)
        {
            string mensaje = "";

            using (SqlCommand cmd = new SqlCommand())
            {
                try
                {
                    using (cmd.Connection = getConexion())
                    {
                        cmd.CommandText = "usp_Actualizar_Producto";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@idProducto", reg.idProducto);
                        cmd.Parameters.AddWithValue("@nomPrducto", reg.nomproducto);
                        cmd.Parameters.AddWithValue("@descripcion", reg.descripcion);
                        cmd.Parameters.AddWithValue("@idCategoria", reg.idCategoria);
                        cmd.Parameters.AddWithValue("@stock", reg.stock);
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        mensaje = $"Se ha actualizar el Usuario {reg.nomproducto}";
                    }
                }
                catch (Exception Ex)
                {
                    throw Ex;
                }
                finally
                {
                    if (cmd.Connection.State == ConnectionState.Open)
                    {
                        cmd.Connection.Close();
                    }
                }
            }


            return mensaje;
        }


        string IProducto.RegistrarProducto(Producto reg)
        {
            string mensaje = "";
            using (SqlCommand cmd = new SqlCommand())
            {
                try
                {
                    using (cmd.Connection = getConexion())
                    {
                        cmd.CommandText = "usp_Registrar_Producto";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@idProducto", reg.idProducto);
                        cmd.Parameters.AddWithValue("@nomPrducto", reg.nomproducto);
                        cmd.Parameters.AddWithValue("@descripcion", reg.descripcion);
                        cmd.Parameters.AddWithValue("@idCategoria", reg.idCategoria);
                        cmd.Parameters.AddWithValue("@stock", reg.stock);
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        mensaje = $"Se ha registrado el producto {reg.nomproducto}";
                    }
                }
                catch (Exception Ex)
                {
                    throw Ex;
                }
                finally
                {
                    if (cmd.Connection.State == ConnectionState.Open)
                    {
                        cmd.Connection.Close();
                    }
                }
            }
            return mensaje;
        }
    }
}

