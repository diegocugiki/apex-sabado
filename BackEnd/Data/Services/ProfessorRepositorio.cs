using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BackEnd.Data.Interfaces;
using BackEnd.Models;
using System.Collections.Generic;

namespace BackEnd.Data.Services
{
    public class ProfessorRepositorio : IProfessorRepositorio
    {
        private readonly DataContext _contexto;

        public ProfessorRepositorio(DataContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<IEnumerable<Professor>> ObterTodos(bool incluirAluno)
        {
            IQueryable<Professor> consulta = _contexto.Professor;

            if (incluirAluno) 
            {
                consulta = consulta.Include(p => p.Disciplinas)
                                   .ThenInclude(d => d.AlunosDisciplinas)
                                   .ThenInclude(ad => ad.Aluno);
            }

            consulta = consulta.AsNoTracking().OrderBy(a => a.id);

            return await consulta.ToArrayAsync();
        }

        public async Task<IEnumerable<Professor>> ObterTodosPeloAlunoId(int alunoId, bool incluirDisciplina)
        {
            IQueryable<Professor> consulta = _contexto.Professor;

            if (incluirAluno) 
            {
                consulta = consulta.Include(p => p.Disciplinas);
            }

            consulta = consulta.AsNoTracking()
                               .OrderBy(a => a.id)
                               .Where(p.Disciplinas.any(
                                   d => d.AlunosDisciplinas.any(
                                      ad => ad.alunoId == alunoId
                                   )
                               ));

            return await consulta.ToArrayAsync();
        }

        public async Task<Professor> ObterPeloId(int professorId, bool incluirAluno)
        {
            IQueryable<Professor> consulta = _contexto.Professor;

            if (incluirAluno) 
            {
                consulta = consulta.Include(p => p.Disciplinas)
                                   .ThenInclude(d => d.AlunosDisciplinas)
                                   .ThenInclude(ad => ad.Aluno);
            }

            consulta = consulta.AsNoTracking().OrderBy(a => a.id).Where(p => p.id == professorId);

            return await consulta.FirstOrDefaultAsync();
        }
    }
}