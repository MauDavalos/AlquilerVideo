//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FinalVideo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class ALQUILER
    {
        public int ALQ_ID { get; set; }
        [Display(Name = "Socio")]
        public Nullable<int> SOC_ID { get; set; }
        [Display(Name = "Película")]
        public Nullable<int> PEL_ID { get; set; }
        [Display(Name = "Fecha Desde")]
        public System.DateTime ALQ_FECHA_DESDE { get; set; }
        [Display(Name = "Fecha Hasta")]
        public System.DateTime ALQ_FECHA_HASTA { get; set; }
        [Display(Name = "Costo")]
        public decimal ALQ_VALOR { get; set; }
        [Display(Name = "Fecha Entrega")]
        public Nullable<System.DateTime> ALQ_FECHA_ENTREGA { get; set; }
    
        public virtual PELICULA PELICULA { get; set; }
        public virtual SOCIO SOCIO { get; set; }
    }
}
