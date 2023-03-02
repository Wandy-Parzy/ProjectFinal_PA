using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

#nullable disable // Para quitar el aviso de nulls
 
namespace Models   
{
    public class Inventario // 
    {
        [Key]  
        public int InventarioId { get; set; }

        [Required(ErrorMessage = "Campo obligatorio. ")]
        public string NombreProducto { get; set; } //
        public string Descripcion { get; set; }    
        public int NuevaCantidad { get; set; }    
        public int Total { get; set; }   
        public bool Estado { get; set; } = true;


    }
}