//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BusinessProject.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Animal
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Animal()
        {
            this.citas = new HashSet<cita>();
        }
    
        public int codigoAnimal { get; set; }
        public string nombreAnimal { get; set; }
        public Nullable<int> fk_codigo_tipoAnimal { get; set; }
        public Nullable<int> fk_codigo_zona { get; set; }
        public string ImgAnimal { get; set; }
    
        public virtual TipoAnimal TipoAnimal { get; set; }
        public virtual ZonaGeografica ZonaGeografica { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cita> citas { get; set; }
    }
}
