<<<<<<< HEAD
using System.ComponentModel.DataAnnotations.Schema;
=======
>>>>>>> a747dbca3a23abc2c9f85d0226815a06f4db5cc0
using System.ComponentModel.DataAnnotations;

namespace zoologicoBlazor.Shared
{
    public class CuidadorDetails
    {
        [Key]
        public int IdCuidadorDetails { get; set; }
        [Required(ErrorMessage = "Logradouro é obrigatório")]
        public string Logradouro { get; set; }
        [Required(ErrorMessage = "Número é obrigatório")]
        public int Numero { get; set; }
        [Required(ErrorMessage = "Bairro é obrigatório")]
        public string Bairro { get; set; }
        [Required(ErrorMessage = "Cidade é obrigatório")]
        public string Cidade { get; set; }
        [Required(ErrorMessage = "Estado é obrigatório")]
        public string Estado { get; set; }
        [Required(ErrorMessage = "CEP é obrigatório")]
        public string CEP { get; set; }
        [Required(ErrorMessage = "Telefone é obrigatório")]
        public string Telefone { get; set; }
        public int IdCuidador { get; set; }
        [ForeignKey("IdCuidador")]
        public Cuidador Cuidador { get; set; }
    }
}