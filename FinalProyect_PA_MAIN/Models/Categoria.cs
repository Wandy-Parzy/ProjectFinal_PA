using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

#nullable disable // Para quitar el aviso de nulls
 
namespace Models
{  
    public class Categoria // Entidad Categoria
    {
        [Key]  
        public int CategoriaId { get; set; }

        [Required(ErrorMessage = "Campo obligatorio. Seleccione una categoria")]
        public string Descripcion{ get; set; } // Nombre de la categoria
        public bool Estado { get; set; } = true;             

    }
}