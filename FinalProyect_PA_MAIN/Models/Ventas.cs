using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

#nullable disable // Para quitar el aviso de nulls
 
namespace Models  
{
    public class Ventas // Entidad Ventas
    {
        [Key]
        public int VentaId { get; set; }   

        [DataType(DataType.Date)]  
        public DateTime Fecha { get; set; } 
        public decimal Total { get; set; }
        public decimal ITBIS { get; set; }
        public decimal SubTotal { get; set; }
        public double Existencia { get; set; }
        public double UnidadesVendidas { get; set;}

        [Required(ErrorMessage = "Ingrese el monto a pagar.")]
        public decimal PagoObtenido { get; set;}

        public decimal MontoRestante { get; set;}

        public decimal MetodoDePago { get; set;}

        public bool Estado { get; set; } = true;


        //-------------------------------------------------------------------------------------

        [ForeignKey("PagoId")]
        public virtual Pago Pago { get; set; } 

        
        [ForeignKey("VentaId")]
        public virtual List<VentasDetalle> ventasDetalle { get; set; } 

        public Ventas()
        {
            VentaId = 0;
            Fecha = DateTime.Now;
            ITBIS = 0;
            SubTotal = 0;
            Total = 0;
            Existencia = 0;

            ventasDetalle = new List<VentasDetalle>();
        }
    }
}