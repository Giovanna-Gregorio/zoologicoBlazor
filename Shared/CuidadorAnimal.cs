using System.ComponentModel.DataAnnotations.Schema;

namespace zoologicoBlazor.Shared
{
    public class CuidadorAnimal
    {
        public int IdCuidador { get; set; }
        public Cuidador Cuidador { get; set; }

        public int IdAnimal { get; set; }
        public Animal Animal { get; set; }

        public string Observacoes { get; set; }
    }
}