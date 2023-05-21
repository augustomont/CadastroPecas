using Microsoft.EntityFrameworkCore;

namespace CadastroPecas.Models
{
    //Esse é o contexto para os produtos
    public class Contexto : DbContext //Aqui eu baixei os pacortes core e sql
    {
        public Contexto (DbContextOptions<Contexto> options) : base(options)
        {

        }
        public DbSet<CadastroModel> CadastroModel { get; set; } //Aqui dentro das <model> voce deve por o nome da class model que vai gerar o contexto
    }
}
