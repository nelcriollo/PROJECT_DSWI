using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PROJECT_DSWI.Models;
using System.Data.SqlClient;
using System.Configuration;

using PROJECT_DSWI.DAO;
using PROJECT_DSWI.DAO.DI;
using ConfigurationManager = Microsoft.Extensions.Configuration.ConfigurationManager;

namespace PROJECT_DSWI.Controllers
{
    public class UsuarioController : Controller

    {
        /*string cadena = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;

        // GET: Acceso
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registrar(Usuario oUsuario)
        {
            bool registrado;
            string mensaje;

            if (oUsuario.clave != oUsuario.ConfirmarClave)
            {
                ViewData["Mensaje"] = "Contraseña no coinciden";
                return View();
            }

            using (SqlConnection cn = new SqlConnection(cadena))
            {

                SqlCommand cmd = new SqlCommand("usp_insertar_usuario", cn);
                cmd.Parameters.AddWithValue("Correo", oUsuario.correo);
                cmd.Parameters.AddWithValue("Clave", oUsuario.clave);
                cmd.Parameters.Add("Registro", SqlDbType.Bit).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                cmd.ExecuteNonQuery();

                registrado = Convert.ToBoolean(cmd.Parameters["Registro"].Value);
                mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }

            ViewData["Mensaje"] = mensaje;

            if (registrado)
            {
                return RedirectToAction("Login", "Acceso");
            }
            else
            {
                return View();
            }


        }
        [HttpPost]
        public ActionResult Login(Usuario oUsuario)
        {
            oUsuario.clave = oUsuario.clave;

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand("usp_validar_usuario", cn);
                cmd.Parameters.AddWithValue("Correo", oUsuario.correo);
                cmd.Parameters.AddWithValue("Clave", oUsuario.clave);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                oUsuario.idUsuario = Convert.ToInt32(cmd.ExecuteScalar().ToString());

            }
            if (oUsuario.idUsuario != 0)
            {
                Session["usuario"] = oUsuario;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewData["Mensaje"] = "Usuario no encontrado";

                return View();
            }


        }




      
   
        IUsuario _iusuarios;

        public UsuarioController()
        {
            _iusuarios = new UsuarioDAO();
        }


        public IActionResult ListarUsuarios()
        {

            IEnumerable<Usuario> listUsu = _iusuarios.listarUsuarios();
            return View(listUsu);
        }*/

    }
}
