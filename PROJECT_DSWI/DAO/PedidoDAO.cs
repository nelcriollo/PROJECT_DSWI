using Microsoft.Data.SqlClient;
using System.Data;
using PROJECT_DSWI.Models;
using PROJECT_DSWI.DAO.DI;

namespace PROJECT_DSWI.DAO
{
    public class PedidoDAO : ConexionDAO, IPedido
    {
        public IEnumerable<Pedido> listado()
        {
            List<Pedido> temporal = new List<Pedido>();
            using (SqlCommand cmd = new SqlCommand())
            {
                using (cmd.Connection = getConexion())
                {
                    cmd.CommandText = "exec usp_Pedido_Listar";
                    cmd.CommandType = CommandType.Text;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            temporal.Add(new Pedido()
                            {
                                idPedido = dr.GetInt32(0),
                                idCliente = dr.GetInt32(1),
                                idTipoPedido = dr.GetInt32(2),
                                fechaHoraPedido = dr.GetDateTime(3),
                                totalPedido = dr.GetDecimal(4),
                                idMetodoPago = dr.GetInt32(5),
                                cod_Ubigeo = dr.GetString(6),
                                direccionPedido = dr.GetString(7),
                                estado = dr.GetInt32(8)
                            });
                        }
                    }
                    
                    
                }
            }
            
            return temporal;
        }
        public Pedido buscar(int codigo)
        {
            //retorna el registro por su codigo
            return listado().FirstOrDefault(pe => pe.idPedido == codigo);
        }
        public string agregar(Pedido reg)
        {
            string mensaje = "";
            using (SqlCommand cmd = new SqlCommand())
            {
                try
                {
                    using (cmd.Connection = getConexion())
                    {
                        cmd.CommandText = "usp_Pedido_Registrar";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@idCliente", reg.idCliente);
                        cmd.Parameters.AddWithValue("@idTipoPedido", reg.idTipoPedido);
                        cmd.Parameters.AddWithValue("@fechaHoraPedido", reg.fechaHoraPedido);
                        cmd.Parameters.AddWithValue("@totalPedido", reg.totalPedido);
                        cmd.Parameters.AddWithValue("@idMetodoPago", reg.idMetodoPago);
                        cmd.Parameters.AddWithValue("@cod_Ubigeo", reg.cod_Ubigeo);
                        cmd.Parameters.AddWithValue("@direccionPedido", reg.direccionPedido);
                        cmd.Parameters.AddWithValue("@estado", reg.estado);
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        mensaje = "Se ha agregado el pedido";
                    }
                }
                catch (SqlException ex) { mensaje = ex.Message; }
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

        public string actualizar(Pedido reg)
        {
            string mensaje = "";
            using (SqlCommand cmd = new SqlCommand())
            {
                try
                {
                    using (cmd.Connection = getConexion())
                    {
                        cmd.CommandText = "usp_Pedido_Actualizar";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@idCliente", reg.idCliente);
                        cmd.Parameters.AddWithValue("@idTipoPedido", reg.idTipoPedido);
                        cmd.Parameters.AddWithValue("@fechaHoraPedido", reg.fechaHoraPedido);
                        cmd.Parameters.AddWithValue("@totalPedido", reg.totalPedido);
                        cmd.Parameters.AddWithValue("@idMetodoPago", reg.idMetodoPago);
                        cmd.Parameters.AddWithValue("@cod_Ubigeo", reg.cod_Ubigeo);
                        cmd.Parameters.AddWithValue("@direccionPedido", reg.direccionPedido);
                        cmd.Parameters.AddWithValue("@estado", reg.estado);
                        cmd.ExecuteNonQuery();
                        mensaje = "Se ha actualizado el pedido";
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

        public string eliminar(Pedido reg)
        {
            throw new NotImplementedException();
        }
    }
}
