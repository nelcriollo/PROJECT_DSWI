using Microsoft.Data.SqlClient;
using System.Data;
using PROJECT_DSWI.Models;
namespace PROJECT_DSWI.DAO
{
    public class PedidoDAO
    {
        public IEnumerable<Pedido> pedidos()
        {
            List<Pedido> temporal = new List<Pedido>();
            ConexionDAO cn = new ConexionDAO();
            using (cn.getcn)
            {
                cn.getcn.Open();
                SqlCommand cmd = new SqlCommand();
                SqlDataReader dr = cmd.ExecuteReader();

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
                cn.getcn.Close();
            }
            return temporal;
        }
    }
}
