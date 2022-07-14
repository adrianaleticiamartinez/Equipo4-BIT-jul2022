using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Incidentes.Models
{
    public class Cliente
    {
        public string idCliente
        {
            get; set;
        }
        public string nombre
        {
            get; set;
        }
        public string apellidoPaterno
        {
            get; set;
        }
        public string apellidoMaterno
        {
            get; set;
        }
        public DateTime fechaNacimiento
        {
            get; set; }
        public string sexo
        {
            get; set;
        }
        public string segmento
        {
            get; set; }
        public string nacionalidad
        {
            get; set;
        }
        public string rfc
        {
            get; set; }
        public string tipoID
        {
            get; set;
        }
        public string numeroID
        {
            get; set;
        }
        public string cuenta
        {
            get; set; }
        public string email
        {
            get; set;
        }
        public string TDD
        {
            get; set; }
        }
    }