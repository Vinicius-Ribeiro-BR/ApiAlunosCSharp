namespace apiAlunes.models
{
    public class Aluno
    {
        public int id {  get; set; }
        public string nome { get; set; }

        public string? Celular { get; set; }

        public string Email { get; set; }

        public DateTime DataNascimento { get; set; }
    }
}
