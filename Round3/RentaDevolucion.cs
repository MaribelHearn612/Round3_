//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Round3
{
    using System;
    using System.Collections.Generic;
    
    public partial class RentaDevolucion
    {
        public int noPrestamo { get; set; }
        public int idEmpleado { get; set; }
        public int idEquipo { get; set; }
        public int idUsuadio { get; set; }
        public System.DateTime fechaP { get; set; }
        public System.DateTime fechaD { get; set; }
        public string comentario { get; set; }
        public bool estadoPrestamo { get; set; }
    
        public virtual Empleado Empleado { get; set; }
        public virtual Equipo Equipo { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}