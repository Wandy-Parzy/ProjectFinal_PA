using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable // Para quitar el aviso de nulls
 
namespace Models  
{
    public class Clientes // Entidad clientes
    {
        [Key]  
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "Ingrese un nombre.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Campo email es requerido.")]
        [RegularExpression("\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*",ErrorMessage = "Formato inválido. name@gmail.com")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Ingrese un numero teléfonico.")]
        [RegularExpression(@"^\d{3}[- ]?\d{3}[- ]?\d{4}$",ErrorMessage = "Formato inválido. 000-000-0000")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "Campo celular es requerido.")]
        [RegularExpression(@"^\d{3}[- ]?\d{3}[- ]?\d{4}$",ErrorMessage = "Formato inválido. 000-000-0000")]
        public string Celular { get; set; }

        [Required(ErrorMessage = "Ingrese una dirección.")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "Ingrese un numero de cédula.")]
        [RegularExpression(@"^\d{3}[- ]?\d{7}[- ]?\d{1}$",ErrorMessage = "Formato inválido 000-0000000-0")]
        public string Cedula { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }
        public int UsuarioId { get; set; }
        public bool Estado { get; set; } = true;

             

        //-------------------------------------------------------------------------------------

         public Clientes()
        {
            ClienteId = 0;  
            UsuarioId = 0;
            Nombre = string.Empty;
            Email = string.Empty;
            Telefono = string.Empty;
            Celular = string.Empty;
            Direccion = string.Empty;
            Cedula = string.Empty;
            FechaNacimiento = DateTime.Now;
        }  
    }
}