using System.Threading.Tasks;
using BackEnd.Models;
using System.Collections.Generic;

namespace BackEnd.Data.Interfaces
{
    public interface IProfessorRepositorio
    {
        Task<IEnumerable<Professor>> ObterTodos(bool incluirAluno);
        Task<IEnumerable<Professor>> ObterTodosPeloAlunoId(int alunoId, bool incluirDisciplina);
        Task<Professor> ObterPeloId(int professorId, bool incluirAluno);
    }
}