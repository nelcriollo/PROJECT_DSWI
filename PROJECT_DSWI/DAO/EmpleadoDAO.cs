using Microsoft.Data.SqlClient;
using System.Data;
using PROJECT_DSWI.Models;
using PROJECT_DSWI.DAO.DI;
using PROJECT_DSWI.DAO;

namespace PROJECT_DSWI.DAO
{
    public class EmpleadoDAO : ConexionDAO, IEmpleado 
    { 
        IEnumerable<Empleado> IEmpleado.listarEmpleado()
        {

            List<Empleado> listaEmplea = new List<Empleado>();

            using (SqlCommand cmd = new SqlCommand())
            {
                try
                {
                    using (cmd.Connection = getConexion())
                    {
                        cmd.CommandText = "SELECT idEmpleado, nombre,apellido,correo,telefono,idTipoDocumento,documento,idCargo,cod_Ubigeo,direccion,idLocal FROM tb_Empleado";
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Clear();
                        cmd.Connection.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
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
                                    idLocal = dr.GetInt32(10),
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

            return listaEmplea;
        }

        string IEmpleado.ActualizarEmpleado(Empleado reg)
        {
            string mensaje = "";
            using (SqlCommand cmd = new SqlCommand())
            {
                try
                {
                    using (cmd.Connection = getConexion())
                    {
                        cmd.CommandText = "usp_Actualizar_Empleado";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
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
                        cmd.Connection.Open();
                        int resp = cmd.ExecuteNonQuery();
                        if (resp == -1)
                        {
                            mensaje = $"No se actualizaron los datos {reg.nombre}";
                        }
                        else {
                            mensaje = $"Se ha actualizar el Empleado {reg.nombre}";
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
            return mensaje;
        }

        string IEmpleado.RegistrarEmpleado(Empleado reg)
         {
            string mensaje = "";
            using (SqlCommand cmd = new SqlCommand())
            {
                try
                {
                    using (cmd.Connection = getConexion())
                    {
                        cmd.CommandText = "usp_Registrar_Empleado";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
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
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        mensaje = $"Se ha registrado el Empleado {reg.nombre}";
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
