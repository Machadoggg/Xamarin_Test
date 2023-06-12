using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xamarin_Test.Models
{
    public class Customer
    {
        [JsonProperty(PropertyName = "codigo")]
        public int Codigo { get; set; }


        [JsonProperty(PropertyName = "tipoDocumento")]
        public string TipoDocumento { get; set; }


        [JsonProperty(PropertyName = "numeroDocumento")]
        public long NumeroDocumento { get; set; }


        [JsonProperty(PropertyName = "nombres")]
        public string Nombres { get; set; }


        [JsonProperty(PropertyName = "apellido_1")]
        public string Apellido_1 { get; set; }


        [JsonProperty(PropertyName = "apellido_2")]
        public string Apellido_2 { get; set; }


        [JsonProperty(PropertyName = "genero")]
        public string Genero { get; set; }


        [JsonProperty(PropertyName = "fechaNacimiento")]
        public DateTime FechaNacimiento { get; set; }


        [JsonProperty(PropertyName = "direcciones")]
        public string Direcciones { get; set; }


        [JsonProperty(PropertyName = "telefonos")]
        public string Telefonos { get; set; }


        [JsonProperty(PropertyName = "emails")]
        public string Emails { get; set; }
    }
}
