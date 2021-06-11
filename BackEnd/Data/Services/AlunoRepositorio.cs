using BackEnd.Data.Interfaces;
using BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BackEnd.Data.Services
{
    public class AlunoRepositorio : IAlunoRepositorio
    {
        private readonly DataContext _contexto;

        public AlunoRepositorio(DataContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<IEnumerable<Aluno>> ObterTodos(bool incluirProfessor)
        {
            IQueryable<Aluno> consulta = _contexto.Aluno;

            if (incluirProfessor) 
            {
                consulta = consulta.Include(a => a.AlunosDisciplinas)
                                   .ThenInclude(ad => ad.Disciplina)
                                   .ThenInclude(d => d.Professor);
            }

            consulta = consulta.AsNoTracking().OrderBy(a => a.id);

            return await consulta.ToArrayAsync();
        }

        public async Task<IEnumerable<Aluno>> ObterTodosPelaDisciplinaId(int disciplinaId, bool incluirDisciplina)
        {
            IQueryable<Aluno> consulta = _contexto.Aluno;

            if (incluirDisciplina) 
            {
                consulta = consulta.Include(a => a.AlunosDisciplinas)
                                   .ThenInclude(ad => ad.Disciplina);
            }

            consulta = consulta.AsNoTracking()
                               .OrderBy(a => a.id)
                               .Where(
                                   a => a.AlunosDisciplinas.Any(
                                       ad => ad.disciplinaId == disciplinaId
                                   )
                               );

            return await consulta.ToArrayAsync();
        }

        public async Task<Aluno> ObterPeloId(int alunoId, bool incluirProfessor)
        {
            IQueryable<Aluno> consulta = _contexto.Aluno;

            if (incluirProfessor) 
            {
                consulta = consulta.Include(a => a.AlunosDisciplinas)
                                   .ThenInclude(ad => ad.Disciplina)
                                   .ThenInclude(d => d.Professor);
            }

            consulta = consulta.AsNoTracking()
                               .OrderBy(a => a.id)
                               .Where(a => a.id == alunoId);

            return await consulta.FirstOrDefaultAsync();
        }
    }
}