using Microsoft.Data.SqlClient;
using System.Data;
using PROJECT_DSWI.Models;
using PROJECT_DSWI.DAO.DI;

namespace PROJECT_DSWI.DAO
{
    public class ProductoDAO : IProducto

    {
        IEnumerable<Producto> IProducto.listarTodos()
        {

            List<Producto> listaProd = new List<Producto>();

            ConexionDAO cn = new ConexionDAO();

            using (cn.getcn)
            {
                cn.getcn.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SELECT idProducto, nomProducto,descripcion,idCategoria,stock FROM tb_Producto", cn.getcn);

                    SqlDataReader dr = cmd.ExecuteReader();

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
                catch (Exception)
                {

                    throw;
                }
            }
            return listaProd;
        }

        string IProducto.ActualizarProducto(Producto reg)
        {
            string mensaje = "";
            ConexionDAO cn = new ConexionDAO();
            using (cn.getcn)
            {
                cn.getcn.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand(
                        "exec usp_Actualizar_Producto @idProducto, @nomPrducto,@descripcion,@idCategoria,@stock", cn.getcn);
                    cmd.Parameters.AddWithValue("@idProducto", reg.idProducto);
                    cmd.Parameters.AddWithValue("@nomPrducto", reg.nomproducto);
                    cmd.Parameters.AddWithValue("@descripcion", reg.descripcion);
                    cmd.Parameters.AddWithValue("@idCategoria", reg.idCategoria);
                    cmd.Parameters.AddWithValue("@stock", reg.stock);
                    cmd.ExecuteNonQuery();
                    mensaje = $"Se ha actualizar el Usuario {reg.nomproducto}";
                }
                catch (SqlException ex) { mensaje = ex.Message; }
                finally { cn.getcn.Close(); }
            }
            return mensaje;
        }


        string IProducto.RegistrarProducto(Producto reg)
        {
            string mensaje = "";
            ConexionDAO cn = new ConexionDAO();
            using (cn.getcn)
            {
                cn.getcn.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand(
                        "exec usp_Registrar_Producto @idProducto, @nomPrducto,@descripcion,@idCategoria,@stock", cn.getcn);
                    cmd.Parameters.AddWithValue("@idProducto", reg.idProducto);
                    cmd.Parameters.AddWithValue("@nomPrducto", reg.nomproducto);
                    cmd.Parameters.AddWithValue("@descripcion", reg.descripcion);
                    cmd.Parameters.AddWithValue("@idCategoria", reg.idCategoria);
                    cmd.Parameters.AddWithValue("@stock", reg.stock);
                    cmd.ExecuteNonQuery();
                    mensaje = $"Se ha registrado el producto {reg.nomproducto}";
                }
                catch (SqlException ex) { mensaje = ex.Message; }
                finally { cn.getcn.Close(); }
            }
            return mensaje;
        }
    }
}

