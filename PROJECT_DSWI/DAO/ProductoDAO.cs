using Microsoft.Data.SqlClient;
using System.Data;
using PROJECT_DSWI.Models;
using PROJECT_DSWI.DAO.DI;

namespace PROJECT_DSWI.DAO
{
    public class ProductoDAO : IProducto

    {
        IEnumerable<Producto> IProducto.listarTodos()
        {
            
            List<Producto> listaProd = new List<Producto>();

            ConexionDAO cn =new ConexionDAO();

            using (cn.getcn)
            {
                cn.getcn.Open();
                try
                {
                    SqlCommand cmd=new SqlCommand("SELECT idProducto, nomPrducto,descripcion,idCategoria,stock FROM tb_Producto", cn.getcn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        listaProd.Add(new Producto()
                        {
                            idProducto = dr.GetInt32(0),
                            nomproducto=dr.GetString(1),
                            descripcion=dr.GetString(2),
                            idCategoria=dr.GetInt32(3),
                            stock=dr.GetInt32(4),

                        }) ;

                    }

                }
                catch (Exception)
                {

                    throw;
                }
            }
            return listaProd;
        }

        string IProducto.ActualizarProducto(Producto reg)
        {
            throw new NotImplementedException();
        }

      

        string IProducto.RegistrarProducto(Producto reg)
        {
            throw new NotImplementedException();
        }
    }
}
