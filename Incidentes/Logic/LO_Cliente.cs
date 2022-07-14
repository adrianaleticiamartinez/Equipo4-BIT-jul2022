using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Incidentes.Models;
using System.Data.SqlClient;
using System.Data;

namespace Incidentes.Logic
{
    public class LO_Cliente
    {
        public Cliente ConsultaClienteManager(string Id)
        {
            Cliente obj = new Cliente();

            try
            {
                using (SqlConnection oconnection = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_manager", oconnection);
                    cmd.Parameters.AddWithValue("id", Id);
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconnection.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            obj.idCliente = Convert.ToString(dr["idCliente"]);
                            obj.nombre = Convert.ToString(dr["nombre"]);
                            obj.apellidoPaterno = Convert.ToString(dr["apellidoPaterno"]);
                            obj.apellidoMaterno = Convert.ToString(dr["apellidoMaterno"]);
                            obj.fechaNacimiento = Convert.ToDateTime(dr["fechaNacimiento"]);
                            obj.sexo = Convert.ToString(dr["sexo"]);
                            obj.segmento = Convert.ToString(dr["segmento"]);
                            obj.nacionalidad = Convert.ToString(dr["nacionalidad"]);
                            obj.rfc = Convert.ToString(dr["rfc"]);
                            obj.tipoID = Convert.ToString(dr["tipoID"]);
                            obj.numeroID = Convert.ToString(dr["numeroID"]);
                            obj.cuenta = Convert.ToString(dr["cuenta"]);
                            obj.email = Convert.ToString(dr["email"]);
                            //obj.TDD = Convert.ToString(dr["TDD"]);
                        }
                    }
                }
            }
            catch
            {
                obj = new Cliente();
            }

            return obj;
        }

        public Cliente ConsultaClienteValidador(string Id)
        {
            Cliente obj = new Cliente();

            try
            {
                using (SqlConnection oconnection = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_validador", oconnection);
                    cmd.Parameters.AddWithValue("id", Id);
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconnection.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            obj.idCliente = Convert.ToString(dr["idCliente"]);
                            obj.nombre = Convert.ToString(dr["nombre"]);
                            obj.apellidoPaterno = Convert.ToString(dr["apellidoPaterno"]);
                            obj.apellidoMaterno = Convert.ToString(dr["apellidoMaterno"]);
                            obj.fechaNacimiento = Convert.ToDateTime(dr["fechaNacimiento"]);
                            obj.sexo = Convert.ToString(dr["sexo"]);
                            obj.segmento = Convert.ToString(dr["segmento"]);
                            obj.nacionalidad = Convert.ToString(dr["nacionalidad"]);
                            obj.rfc = Convert.ToString(dr["rfc"]);
                            obj.tipoID = Convert.ToString(dr["tipoID"]);
                            obj.numeroID = Convert.ToString(dr["numeroID"]);
                            obj.cuenta = Convert.ToString(dr["cuenta"]);
                            obj.email = Convert.ToString(dr["email"]);
                            obj.TDD = Convert.ToString(dr["TDD"]);
                        }
                    }
                }
            }
            catch
            {
                obj = new Cliente();
            }

            return obj;
        }

        public Cliente ConsultaClienteRestringido(string Id)
        {
            Cliente obj = new Cliente();

            try
            {
                using (SqlConnection oconnection = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_restringido", oconnection);
                    cmd.Parameters.AddWithValue("id", Id);
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconnection.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            obj.idCliente = Convert.ToString(dr["idCliente"]);
                            obj.nombre = Convert.ToString(dr["nombre"]);
                            obj.sexo = Convert.ToString(dr["sexo"]);
                            obj.segmento = Convert.ToString(dr["segmento"]);
                            obj.cuenta = Convert.ToString(dr["cuenta"]);
                        }
                    }
                }
            }
            catch
            {
                obj = new Cliente();
            }

            return obj;
        }
    }
}