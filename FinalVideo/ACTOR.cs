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

    public partial class ACTOR
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ACTOR()
        {
            this.ACTOR_PELICULA = new HashSet<ACTOR_PELICULA>();
        }
    
        public int ACT_ID { get; set; }
        [Display(Name = "Sexo")]
        public Nullable<int> SEX_ID { get; set; }
        [Display(Name = "Nombre")]
        public string ACT_NOMBRE { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ACTOR_PELICULA> ACTOR_PELICULA { get; set; }
        public virtual SEXO SEXO { get; set; }
    }
}
