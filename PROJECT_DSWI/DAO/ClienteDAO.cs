using Microsoft.Data.SqlClient;
using System.Data;
using PROJECT_DSWI.Models;
namespace PROJECT_DSWI.DAO
{
    public class ClienteDAO
    {
        public IEnumerable<Cliente> clientes()
        {
            List<Cliente> temporal = new List<Cliente>();
            ConexionDAO cn = new ConexionDAO();
            using (cn.getcn)
            {
                cn.getcn.Open();
                SqlCommand cmd = new SqlCommand();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    temporal.Add(new Cliente()
                    {
                        idCliente = dr.GetInt32(0),
                        nombre = dr.GetString(1),
                        apellido = dr.GetString(2),
                        correo = dr.GetString(3),
                        telefono = dr.GetString(4),
                        idTipoDocumento = dr.GetInt32(5),
                        documento = dr.GetString(6),
                        cod_ubigeo = dr.GetString(7),
                        direccion = dr.GetString(8)
                    });
                }
                cn.getcn.Close();
            }
            return temporal;
        }
    }
}
