using apiAlunes.models;
using Microsoft.AspNetCore.Mvc;

namespace apiAlunes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController : ControllerBase
    {


        [HttpGet]
        public IEnumerable<Aluno> GetAlunos()
        {
            return PegarDados();


        }

        [HttpPost]

        public IActionResult CadastrarAluno(Aluno aluno)
        {
            //criart uma list de aluns vazia 
            List<Aluno> ListaAlunos = PegarDados();

            // add o novo aluno da lista 
            ListaAlunos.Add(aluno);

            SalvarDados(ListaAlunos);

            return Ok();




        }

        private static void SalvarDados(List<Aluno> ListaAlunos)
        {
            //serealizar a lista de alunos e salvar no arquivo 
            var dadosSerealizados = System.Text.Json.JsonSerializer.Serialize<List<Aluno>>(ListaAlunos);

            System.IO.File.WriteAllText("c:\\temp\\alunos.json", dadosSerealizados);
        }

        private static List<Aluno> PegarDados()
        {
            List<Aluno> ListaAlunos = new();

            try
            {
                // pegar arquivo c:\\temp\\alunos.json e trazer a memoria 
                string dadosArquivo = System.IO.File.ReadAllText("c:\\temp\\alunos.json");
                ListaAlunos = System.Text.Json.JsonSerializer.Deserialize<List<Aluno>>(dadosArquivo);
            }
            catch { }

            return ListaAlunos;
        }
    }
}
