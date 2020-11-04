namespace zoologicoBlazor.Shared
{
    public class CuidadorDetails
    {
        public int IdCuidadorDetails { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }
        public string Telefone { get; set; }
        public int IdCuidador { get; set; }
        public Cuidador Cuidador { get; set; }
    }
}