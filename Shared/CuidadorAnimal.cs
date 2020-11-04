using System.ComponentModel.DataAnnotations.Schema;

namespace zoologicoBlazor.Shared
{
    public class CuidadorAnimal
    {
        public int IdCuidador { get; set; }
        [ForeignKey("IdCuidador")]
        public Cuidador Cuidador { get; set; }

        public int IdAnimal { get; set; }
        [ForeignKey("IdAnimal")]
        public Animal Animal { get; set; }

        public string Observacoes { get; set; }
    }
}