using Microsoft.Data.SqlClient;
using System.Data;
using PROJECT_DSWI.Models;
using PROJECT_DSWI.DAO.DI;


namespace PROJECT_DSWI.DAO

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
        

    }
}
