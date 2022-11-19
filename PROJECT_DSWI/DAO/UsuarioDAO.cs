using Microsoft.Data.SqlClient;
using System.Data;
using PROJECT_DSWI.Models;
using PROJECT_DSWI.DAO.DI;
using Microsoft.AspNetCore.Mvc;

namespace PROJECT_DSWI.DAO
{
    public class UsuarioController: Controller
    {
        public class UsuarioDAO : IUsuario
        {
            IEnumerable<Usuario> IUsuario.listarUsuarios()
            {

                List<Usuario> listaUsua = new List<Usuario>();

                ConexionDAO cn = new ConexionDAO();

                using (cn.getcn)
                {
                    cn.getcn.Open();
                    try
                    {
                        SqlCommand cmd = new SqlCommand("SELECT idUsuario, nombre,apellido,telefono,idTipoDocumento,documento,correo,clave FROM tb_Usuario", cn.getcn);

                        SqlDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            listaUsua.Add(new Usuario()
                            {
                                idUsuario = dr.GetInt32(0),
                                nombre = dr.GetString(1),
                                apellido = dr.GetString(2),
                                telefono = dr.GetString(3),
                                idTipoDocumento = dr.GetInt32(4),
                                documento = dr.GetString(5),
                                correo = dr.GetString(6),
                                clave = dr.GetString(7),

                            });

                        }
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
                return listaUsua;
            }

            string IUsuario.ActualizarUsuario(Usuario reg)
            {
                string mensaje = "";
                ConexionDAO cn = new ConexionDAO();
                using (cn.getcn)
                {
                    cn.getcn.Open();
                    try
                    {
                        SqlCommand cmd = new SqlCommand(
                            "exec usp_Actualizar_Usuario @idUsuario, @nombre,@apellido,@telefono,@idTipoDocumento,@documento,@correo,@clave", cn.getcn);
                        cmd.Parameters.AddWithValue("@idUsuario", reg.idUsuario);
                        cmd.Parameters.AddWithValue("@nombre", reg.nombre);
                        cmd.Parameters.AddWithValue("@apellido", reg.apellido);
                        cmd.Parameters.AddWithValue("@telefono", reg.telefono);
                        cmd.Parameters.AddWithValue("@idTipoDocumento", reg.idTipoDocumento);
                        cmd.Parameters.AddWithValue("@documento", reg.documento);
                        cmd.Parameters.AddWithValue("@correo", reg.correo);
                        cmd.Parameters.AddWithValue("@clave", reg.clave);
                        cmd.ExecuteNonQuery();
                        mensaje = $"Se ha actualizar el Usuario {reg.nombre}";
                    }
                    catch (SqlException ex) { mensaje = ex.Message; }
                    finally { cn.getcn.Close(); }
                }
                return mensaje;
            }


            string IUsuario.RegistrarUsuario(Usuario reg)
            {

                string mensaje = "";
                ConexionDAO cn = new ConexionDAO();
                using (cn.getcn)
                {
                    cn.getcn.Open();
                    try
                    {
                        SqlCommand cmd = new SqlCommand(
                            "exec usp_Registrar_Usuario @idUsuario, @nombre,@apellido,@telefono,@idTipoDocumento,@documento,@correo,@clave", cn.getcn);
                        cmd.Parameters.AddWithValue("@idUsuario", reg.idUsuario);
                        cmd.Parameters.AddWithValue("@nombre", reg.nombre);
                        cmd.Parameters.AddWithValue("@apellido", reg.apellido);
                        cmd.Parameters.AddWithValue("@telefono", reg.telefono);
                        cmd.Parameters.AddWithValue("@idTipoDocumento", reg.idTipoDocumento);
                        cmd.Parameters.AddWithValue("@documento", reg.documento);
                        cmd.Parameters.AddWithValue("@correo", reg.correo);
                        cmd.Parameters.AddWithValue("@clave", reg.clave);
                        cmd.ExecuteNonQuery();
                        mensaje = $"Se ha registrado el Usuario {reg.nombre}";
                    }
                    catch (SqlException ex) { mensaje = ex.Message; }
                    finally { cn.getcn.Close(); }
                }
                return mensaje;
            }
        }

    }
    

}

