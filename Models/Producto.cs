using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Luis_P1_AP2.Models
{
    public class Producto
    {
        [Key]
        public int ProductoId { get; set; }
        [Required(ErrorMessage="La Descripicion es requerida")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage="La Existencia es requerida")]
        public string Existencia { get; set; }
        [Required(ErrorMessage="El Costo requerido")]
        public int Costo { get; set; }
        
    }
}