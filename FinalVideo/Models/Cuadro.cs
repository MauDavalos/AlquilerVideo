using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalVideo.Models
{
    public class Cuadro
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public ALQUILER Alquiler { get; set; }
    }
}