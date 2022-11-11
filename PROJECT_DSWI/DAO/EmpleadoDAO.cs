using Microsoft.Data.SqlClient;
using System.Data;
using PROJECT_DSWI.Models;
using PROJECT_DSWI.DAO.DI;
using PROJECT_DSWI.DAO;

namespace PROJECT_DSWI.DAO
{
    public class EmpleadoDAO : IEmpleado 
    { 
        IEnumerable<Empleado> IEmpleado.listarEmpleado()
        {

            List<Empleado> listaEmplea = new List<Empleado>();

            ConexionDAO cn = new ConexionDAO();

                using (cn.getcn)
                {
                    cn.getcn.Open();
                    try
                    {
                        SqlCommand cmd = new SqlCommand("SELECT idEmpleado, nombre,apellido,correo,telefono,idTipoDocumento,documento,idCargo,cod_Ubigeo,direccion,idLocal FROM tb_Empleado", cn.getcn);

                        SqlDataReader dr = cmd.ExecuteReader();

                            while (dr.Read())
                            {
                                listaEmplea.Add(new Empleado()
                                {
                                    idEmpleado = dr.GetInt32(0),
                                    nombre = dr.GetString(1),
                                    apellido = dr.GetString(2),
                                    correo = dr.GetString(3),
                                    telefono = dr.GetString(4),
                                    idTipoDocumento = dr.GetInt32(5),
                                    documento = dr.GetString(6),
                                    idCargo = dr.GetInt32(7),
                                    cod_Ubigeo = dr.GetString(8),
                                    direccion = dr.GetString(9),
                                    idLocal= dr.GetInt32(10),
                                });

                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return listaEmplea;
        }

        string IEmpleado.ActualizarEmpleado(Empleado reg)
                {
                    string mensaje = "";
                    ConexionDAO cn = new ConexionDAO();
                    using (cn.getcn)
                    {
                        cn.getcn.Open();
                        try
                        {
                            SqlCommand cmd = new SqlCommand(
                                "exec usp_Actualizar_Empleado @idEmpleado, @nombre,@apellido,@correo,@telefono,@idTipoDocumento,@documento,@idCargo,@cod_Ubigeo,@direccion,@idLocal", cn.getcn);
                            cmd.Parameters.AddWithValue("@idEmpleado", reg.idEmpleado);
                            cmd.Parameters.AddWithValue("@nombre", reg.nombre);
                            cmd.Parameters.AddWithValue("@apellido", reg.apellido);
                            cmd.Parameters.AddWithValue("@correo", reg.correo);
                            cmd.Parameters.AddWithValue("@telefono", reg.telefono);
                            cmd.Parameters.AddWithValue("@idTipoDocumento", reg.idTipoDocumento);
                            cmd.Parameters.AddWithValue("@documento", reg.documento);
                            cmd.Parameters.AddWithValue("@idCargo", reg.idCargo);
                            cmd.Parameters.AddWithValue("@cod_Ubigeo", reg.cod_Ubigeo);
                            cmd.Parameters.AddWithValue("@direccion", reg.direccion);
                            cmd.Parameters.AddWithValue("@idLocal", reg.idLocal);

                            cmd.ExecuteNonQuery();
                            mensaje = $"Se ha actualizar el Empleado {reg.nombre}";
                        }
                        catch (SqlException ex) { mensaje = ex.Message; }
                        finally { cn.getcn.Close(); }
                    }
                    return mensaje;
                }


        string IEmpleado.RegistrarEmpleado(Empleado reg)
         {
            string mensaje = "";
            ConexionDAO cn = new ConexionDAO();
            using (cn.getcn)
         {
                cn.getcn.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand(
                        "exec usp_Registrar_Empleado @idEmpleado, @nombre,@apellido,@correo,@telefono,@idTipoDocumento,@documento,@idCargo,@cod_Ubigeo,@direccion,@idLocal", cn.getcn);
                    cmd.Parameters.AddWithValue("@idEmpleado", reg.idEmpleado);
                    cmd.Parameters.AddWithValue("@nombre", reg.nombre);
                    cmd.Parameters.AddWithValue("@apellido", reg.apellido);
                    cmd.Parameters.AddWithValue("@correo", reg.correo);
                    cmd.Parameters.AddWithValue("@telefono", reg.telefono);
                    cmd.Parameters.AddWithValue("@idTipoDocumento", reg.idTipoDocumento);
                    cmd.Parameters.AddWithValue("@documento", reg.documento);
                    cmd.Parameters.AddWithValue("@idCargo", reg.idCargo);
                    cmd.Parameters.AddWithValue("@cod_Ubigeo", reg.cod_Ubigeo);
                    cmd.Parameters.AddWithValue("@direccion", reg.direccion);
                    cmd.Parameters.AddWithValue("@idLocal", reg.idLocal);

                    cmd.ExecuteNonQuery();
                    mensaje = $"Se ha registrado el Empleado {reg.nombre}";
                }
                catch (SqlException ex) { mensaje = ex.Message; }
                finally { cn.getcn.Close(); }
            }
            return mensaje;
        }
    }
}
