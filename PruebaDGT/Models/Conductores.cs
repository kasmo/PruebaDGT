//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PruebaDGT.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Conductores
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Conductores()
        {
            this.ConductorVehiculo = new HashSet<ConductorVehiculo>();
            this.InfraccionVehiculo = new HashSet<InfraccionVehiculo>();
        }
    
        public string dni { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public Nullable<int> puntos { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ConductorVehiculo> ConductorVehiculo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InfraccionVehiculo> InfraccionVehiculo { get; set; }
    }
}
