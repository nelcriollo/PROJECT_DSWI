using Microsoft.Data.SqlClient;
using System.Data;
using PROJECT_DSWI.Models;
using PROJECT_DSWI.DAO.DI;

namespace PROJECT_DSWI.DAO
{
    public class ClienteDAO :ICliente
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


        string ICliente.ActualizarCliente(Cliente reg)
        {
            string mensaje = "";
            ConexionDAO cn = new ConexionDAO();
            using (cn.getcn)
            {
                cn.getcn.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand(
                        "exec usp_DetallePedido_Actualizar  @idCliente, @nombre,@apellido,@correo,@telefono,@idTipoDocumento,@documento,@cod_ubigeo,@direccion", cn.getcn);
                    cmd.Parameters.AddWithValue("@idCliente", reg.idCliente);
                    cmd.Parameters.AddWithValue("@nombre", reg.nombre);
                    cmd.Parameters.AddWithValue("@apellido", reg.apellido);
                    cmd.Parameters.AddWithValue("@correo", reg.correo);
                    cmd.Parameters.AddWithValue("@telefono", reg.telefono);
                    cmd.Parameters.AddWithValue("@idTipoDocumento", reg.idTipoDocumento);
                    cmd.Parameters.AddWithValue("@idTipoDocumento", reg.idTipoDocumento);
                    cmd.Parameters.AddWithValue("@documento", reg.documento);
                    cmd.Parameters.AddWithValue("@cod_ubigeo", reg.cod_ubigeo);
                    cmd.Parameters.AddWithValue("@direccion", reg.direccion);
                    cmd.ExecuteNonQuery();
                    mensaje = $"Se ha actualizar el Cliente {reg.nombre}";
                }
                catch (SqlException ex) { mensaje = ex.Message; }
                finally { cn.getcn.Close(); }
            }
            return mensaje;
        }

        string ICliente.RegistrarCliente(Cliente reg)
        {
            string mensaje = "";
            ConexionDAO cn = new ConexionDAO();
            using (cn.getcn)
            {
                cn.getcn.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand(
                        "exec usp_Registrar_Cliente  @idCliente, @nombre,@apellido,@correo,@telefono,@idTipoDocumento,@documento,@cod_ubigeo,@direccion", cn.getcn);
                    cmd.Parameters.AddWithValue("@idCliente", reg.idCliente);
                    cmd.Parameters.AddWithValue("@nombre", reg.nombre);
                    cmd.Parameters.AddWithValue("@apellido", reg.apellido);
                    cmd.Parameters.AddWithValue("@correo", reg.correo);
                    cmd.Parameters.AddWithValue("@telefono", reg.telefono);
                    cmd.Parameters.AddWithValue("@idTipoDocumento", reg.idTipoDocumento);
                    cmd.Parameters.AddWithValue("@idTipoDocumento", reg.idTipoDocumento);
                    cmd.Parameters.AddWithValue("@documento", reg.documento);
                    cmd.Parameters.AddWithValue("@cod_ubigeo", reg.cod_ubigeo);
                    cmd.Parameters.AddWithValue("@direccion", reg.direccion);
                    cmd.ExecuteNonQuery();
                    mensaje = $"Se ha registrado el Cliente {reg.nombre}";
                }
                catch (SqlException ex) { mensaje = ex.Message; }
                finally { cn.getcn.Close(); }
            }
            return mensaje;
        }
    }
}