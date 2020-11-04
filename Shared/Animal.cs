using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace zoologicoBlazor.Shared
{
    public class Animal
    {
        [Key]
        public int IdAnimal { get; set; }
    
        [Required(ErrorMessage = "Nome é obrigatório")] 
        public string Nome { get; set; }

        [Required(ErrorMessage = "Idade é obrigatório")] 
        public int Idade  { get; set; }

        [Required(ErrorMessage = "Especie é obrigatório")] 
        public int IdEspecie { get; set; }
        public Especie Especie { get; set; }

        [Required(ErrorMessage = "Peso é obrigatório")] 
        public decimal Peso { get; set; }
        public List<CuidadorAnimal> CuidadorAnimais { get; set; }

    
    }
}