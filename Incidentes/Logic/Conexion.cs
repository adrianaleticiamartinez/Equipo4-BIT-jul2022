using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace Incidentes.Logic
{
    public class Conexion
    {
            public static string cn = ConfigurationManager.ConnectionStrings["cadena"].ToString();
    }
}