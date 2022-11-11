using Microsoft.Data.SqlClient;
using System.Data;
using PROJECT_DSWI.Models;
using PROJECT_DSWI.DAO.DI;

namespace PROJECT_DSWI.DAO
{
    public class DetallePedidoDAO : IDetallePedido
    {
        IEnumerable<DetallePedido> IDetallePedido.listarDetallePedido()
        {
            List<DetallePedido> listaDetaPedido = new List<DetallePedido>();

            ConexionDAO cn = new ConexionDAO();

            using (cn.getcn)
            {
                cn.getcn.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SELECT idDetallePedido, idPedido,idProducto,cantidad,idPrecio", cn.getcn);

                    SqlDataReader dr = cmd.ExecuteReader();

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
                catch (Exception)
                {

                    throw;
                }
            }
            return listaDetaPedido;
        }

        string IDetallePedido.ActualizarDetallePedido(DetallePedido reg)
        {
            string mensaje = "";
            ConexionDAO cn = new ConexionDAO();
            using (cn.getcn)
            {
                cn.getcn.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand(
                        "exec usp_DetallePedido_Actualizar  @idDetallePedido, @idPedido,@idProducto,@cantidad,@idPrecio", cn.getcn);
                    cmd.Parameters.AddWithValue("@idcliente", reg.idDetallePedido);
                    cmd.Parameters.AddWithValue("@idPedido", reg.idPedido);
                    cmd.Parameters.AddWithValue("@idProducto", reg.idProducto);
                    cmd.Parameters.AddWithValue("@cantidad", reg.cantidad);
                    cmd.Parameters.AddWithValue("@idPrecio", reg.idPrecio);
                    cmd.ExecuteNonQuery();
                    mensaje = $"Se ha actualizar el detalle Pedido {reg.idPedido}";
                }
                catch (SqlException ex) { mensaje = ex.Message; }
                finally { cn.getcn.Close(); }
            }
            return mensaje;
        }

        string IDetallePedido.RegistrarDetallePedido(DetallePedido reg)
        {
            string mensaje = "";
            ConexionDAO cn = new ConexionDAO();
            using(cn.getcn)
            {
                cn.getcn.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand(
                        "exec usp_DetallePedido_Registrar  @idDetallePedido, @idPedido,@idProducto,@cantidad,@idPrecio", cn.getcn);
                    cmd.Parameters.AddWithValue("@idcliente", reg.idDetallePedido);
                    cmd.Parameters.AddWithValue("@idPedido", reg.idPedido);
                    cmd.Parameters.AddWithValue("@idProducto", reg.idProducto);
                    cmd.Parameters.AddWithValue("@cantidad", reg.cantidad);
                    cmd.Parameters.AddWithValue("@idPrecio", reg.idPrecio);
                    cmd.ExecuteNonQuery();
                    mensaje = $"Se ha registrado el detalle Pedido {reg.idPedido}";
                }
                catch(SqlException ex) { mensaje = ex.Message; }
                finally { cn.getcn.Close(); }
            }
            return mensaje;
        }
    }
}
