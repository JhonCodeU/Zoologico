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
    
    public partial class compra
    {
        public int codigoCompra { get; set; }
        public int numeroZonas { get; set; }
        public Nullable<int> precioTotal { get; set; }
        public int cantidadPersonas { get; set; }
        public int fk_idCliente { get; set; }
        public int fk_idPlan { get; set; }
    
        public virtual cliente cliente { get; set; }
        public virtual planTuristico planTuristico { get; set; }
    }
}
