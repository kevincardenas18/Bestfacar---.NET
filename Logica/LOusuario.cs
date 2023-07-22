using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PruebaBestfacar.Models;
using System.Data.SqlClient;
using System.Data;


namespace PruebaBestfacar.Logica
{
    public class LOusuario
    {
        
        public Usuarios EncontrarUsuario(string email, string password)
        {
            Usuarios objeto = new Usuarios();
            using (SqlConnection conexion = new SqlConnection("Data Source = DESKTOP-UGKKR54\\SQLEXPRESS; initial catalog = PruebaBFC; integrated security = true"))
            {
                conexion.Open();
                string query = "select Nombre,Apellido,Email,Password,RolID From Usuarios where Email=@pemail and Password=@ppassword";
                
                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@pemail", email);
                    cmd.Parameters.AddWithValue("@ppassword", password);
                    cmd.CommandType = CommandType.Text;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            objeto = new Usuarios()
                            {
                                Nombre = dr["Nombre"].ToString(),
                                Apellido = dr["Apellido"].ToString(),
                                Email = dr["Email"].ToString(),
                                Password = dr["Password"].ToString(),
                                IdRol = (Rol)dr["RolID"],
                            };
                        }

                    }
                }
                
            }
                
            return objeto;
        }

    }
}
