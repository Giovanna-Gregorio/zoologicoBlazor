using System.ComponentModel.DataAnnotations;

namespace zoologicoBlazor.Shared
{
    public class Cuidador
    {
        public int Id { get; set; }
    
        [Required(ErrorMessage = "Nome é obrigatório")] 
        public string Nome { get; set; }

        [Required(ErrorMessage = "Idade é obrigatório")] 
        public int Idade  { get; set; }

        [Required(ErrorMessage = "Especie é obrigatório")] 
        public string Funcao { get; set; }
    }
}