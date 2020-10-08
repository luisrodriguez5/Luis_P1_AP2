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
        public decimal Existencia { get; set; }

        [Required(ErrorMessage="El Costo requerido")]
        [Range(1, 1000000, ErrorMessage = "El rango es de 1 a 100000")]
        public decimal Costo { get; set; }

        [Required(ErrorMessage = "Este campo no puede estar vacio.")]
        public decimal valorInventario { get; set; }
        
    }
}