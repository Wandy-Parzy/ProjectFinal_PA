using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

#nullable disable // Para quitar el aviso de nulls
 
namespace Models   
{
    public class Pago // Entidad Pago
    {
        [Key]  
        public int PagoId { get; set; }

        [Required(ErrorMessage = "Campo obligatorio. Seleccione un metodo de pago")]
        public string Metodo { get; set; } // Metodo de pago 
        public bool Estado { get; set; } = true;     

    }
}