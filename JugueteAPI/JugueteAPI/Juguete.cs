using System.ComponentModel.DataAnnotations;


namespace JugueteAPI
{
    public class Juguete
    {
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Nombre { get; set; } = string.Empty;
        [MaxLength(100)]
        public string Descripcion { get; set; } = string.Empty;
        [Range(0, 100)]
        public int RestriccionEdad { get; set; }
        [Required, MaxLength(50)]
        public string Compania { get; set; } = string.Empty;
        [Range(1, 1000)]
        public decimal Precio { get; set; }
    }
}
