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
    
    public partial class parqueadero
    {
        public int codigoParqueadero { get; set; }
        public Nullable<int> fk_codigoParqueo { get; set; }
    
        public virtual AtiendeParqueadero AtiendeParqueadero { get; set; }
    }
}
