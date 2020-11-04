using System.ComponentModel.DataAnnotations;

namespace zoologicoBlazor.Shared
{
    public class Cuidador
    {
        public int IdCuidador { get; set; }
    
        [Required(ErrorMessage = "Nome é obrigatório")] 
        public string Nome { get; set; }

        [Required(ErrorMessage = "Idade é obrigatório")] 
        public int Idade  { get; set; }

        [Required(ErrorMessage = "Função é obrigatório")] 
        public string Funcao { get; set; }
    }
}