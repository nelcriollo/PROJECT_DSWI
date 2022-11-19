using Microsoft.Data.SqlClient;
using System.Data;
using PROJECT_DSWI.Models;
using PROJECT_DSWI.DAO.DI;

namespace PROJECT_DSWI.DAO
{
    public class DetallePedidoDAO : ConexionDAO, IDetallePedido
    {
        IEnumerable<DetallePedido> IDetallePedido.listarDetallePedido()
        {
            List<DetallePedido> listaDetaPedido = new List<DetallePedido>();

            using (SqlCommand cmd = new SqlCommand())
            {
                try
                {
                    using (cmd.Connection = getConexion())
                    {
                        cmd.CommandText = "SELECT idDetallePedido, idPedido,idProducto,cantidad,idPrecio";
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                listaDetaPedido.Add(new DetallePedido()
                                {
                                    idDetallePedido = dr.GetInt32(0),
                                    idPedido = dr.GetInt32(1),
                                    idProducto = dr.GetInt32(2),
                                    cantidad = dr.GetInt32(3),
                                    idPrecio = dr.GetInt32(4),

                                });

                            }
                        }
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

            
            return listaDetaPedido;
        }

        string IDetallePedido.ActualizarDetallePedido(DetallePedido reg)
        {
            string mensaje = "";
            ConexionDAO cn = new ConexionDAO();
            using (SqlCommand cmd = new SqlCommand())
            {
                try
                {
                    using (cmd.Connection = getConexion())
                    {
                        cmd.CommandText = "usp_DetallePedido_Actualizar";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@idcliente", reg.idDetallePedido);
                        cmd.Parameters.AddWithValue("@idPedido", reg.idPedido);
                        cmd.Parameters.AddWithValue("@idProducto", reg.idProducto);
                        cmd.Parameters.AddWithValue("@cantidad", reg.cantidad);
                        cmd.Parameters.AddWithValue("@idPrecio", reg.idPrecio);
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        mensaje = $"Se ha actualizar el detalle Pedido {reg.idPedido}";
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

        string IDetallePedido.RegistrarDetallePedido(DetallePedido reg)
        {
            string mensaje = "";
            using (SqlCommand cmd = new SqlCommand())
            {
                try
                {
                    using (cmd.Connection = getConexion())
                    {
                        cmd.CommandText = "usp_DetallePedido_Registrar";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@idcliente", reg.idDetallePedido);
                        cmd.Parameters.AddWithValue("@idPedido", reg.idPedido);
                        cmd.Parameters.AddWithValue("@idProducto", reg.idProducto);
                        cmd.Parameters.AddWithValue("@cantidad", reg.cantidad);
                        cmd.Parameters.AddWithValue("@idPrecio", reg.idPrecio);
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        mensaje = $"Se ha registrado el detalle Pedido {reg.idPedido}";
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
