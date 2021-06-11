using System.Threading.Tasks;

namespace BackEnd.Data.Interfaces
{
    public interface IRepositorio
    {
        void Adicionar<T>(T entidade) where T : class;
        void Atualizar<T>(T entidade) where T : class;
        void Deletar<T>(T entidade) where T : class;
        Task<bool> EfetuouAlteracoes();
    }
}