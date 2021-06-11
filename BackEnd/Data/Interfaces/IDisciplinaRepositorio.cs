using System.Threading.Tasks;
using BackEnd.Models;
using System.Collections.Generic;

namespace BackEnd.Data.Interfaces
{
    public interface IDisciplinaRepositorio
    {
        Task<IEnumerable<Disciplina>> ObterTodos(bool incluirProfessor);
        Task<Disciplina> ObterPeloId(int disciplinaId, bool incluirProfessor);
    }
}