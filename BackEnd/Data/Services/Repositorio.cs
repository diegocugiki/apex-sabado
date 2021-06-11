using System.Threading.Tasks;
using BackEnd.Data.Interfaces;

namespace BackEnd.Data.Services
{
    public class Repositorio : IRepositorio
    {
        private readonly DataContext _contexto;

        public Repositorio(DataContext contexto)
        {
            _contexto = contexto;
        }

        public void Adicionar<T>(T entidade) where T : class
        {
            _contexto.Add(entidade);
        }

        public void Atualizar<T>(T entidade) where T : class
        {
            _contexto.Update(entidade);
        }

        public void Deletar<T>(T entidade) where T : class
        {
            _contexto.Remove(entidade);
        }

        public async Task<bool> EfetuouAlteracoes()
        {
            return (await _contexto.SaveChangesAsync()) > 0;
        }
        
    }
}