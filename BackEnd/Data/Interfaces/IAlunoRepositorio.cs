using System.Threading.Tasks;
using BackEnd.Models;
using System.Collections.Generic;

namespace BackEnd.Data.Interfaces
{
    public interface IAlunoRepositorio
    {
        Task<IEnumerable<Aluno>> ObterTodos(bool incluirProfessor);
        Task<IEnumerable<Aluno>> ObterTodosPelaDisciplinaId(int disciplinaId, bool incluirDisciplina);
        Task<Aluno> ObterPeloId(int alunoId, bool incluirProfessor);
    }
}