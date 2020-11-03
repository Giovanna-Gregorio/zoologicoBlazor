using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace zoologicoBlazor.Shared
{
    public class Especie
    {
        public int IdEspecie { get; set; }
        [Required(ErrorMessage = "Descrição é obrigatório")]
        public string Descricao { get; set; }

        public ICollection<Animal> Animais { get; set; }
    }
}