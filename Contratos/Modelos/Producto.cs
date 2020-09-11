using System.ComponentModel.DataAnnotations;

namespace Contratos.Modelos
{
    public class Producto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
        [StringLength(100)]
        public string Descripcion { get; set; }
        [Range(0, 100)]
        public int RestriccionEdad { get; set; }
        [Required]
        [StringLength(50)]
        public string Compania { get; set; }
        [Required]
        [Range(0, 1000)]
        public decimal Precio { get; set; }
    }
}
