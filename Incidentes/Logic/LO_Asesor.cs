using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Incidentes.Models;
using System.Data.SqlClient;
using System.Data;

namespace Incidentes.Logic
{
    public class LO_Asesor
    {
        public Asesor ConsultaAsesor(string usuario,string auth)
        {
            Asesor obj = new Asesor();

            try
            {
                using (SqlConnection oconnection = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_usuario",oconnection);
                    cmd.Parameters.AddWithValue("us", usuario);
                    cmd.Parameters.AddWithValue("pass", auth);
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconnection.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            obj.usuario = Convert.ToString(dr["usuario"]);
                            obj.auth = dr["auth"].ToString();
                            obj.nombreCompleto = dr["nombreCompleto"].ToString();
                            obj.area = dr["area"].ToString();
                            obj.ubicacion = Convert.ToString(dr["ubicacion"]);
                            obj.segmento = Convert.ToChar(dr["segmento"]);
                            obj.perfil = dr["perfil"].ToString();

                        }
                    }
                }
            }
            catch
            {
                obj = new Asesor();
            }

            return obj;
        } 
    }
}