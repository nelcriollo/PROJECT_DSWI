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
            throw new NotImplementedException();
        }

        string IDetallePedido.RegistrarDetallePedido(DetallePedido reg)
        {
            throw new NotImplementedException();
        }
    }
}
