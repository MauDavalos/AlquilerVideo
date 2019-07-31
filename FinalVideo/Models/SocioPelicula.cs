using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalVideo.Models
{
    public class SocioPelicula
    {
        public SOCIO Persona { get; set; }
        public PELICULA Pelicula { get; set; }
        public ALQUILER Alquiler { get; set; }
    }
}