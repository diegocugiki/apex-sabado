using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BackEnd.Data.Interfaces;
using BackEnd.Models;
using System.Collections.Generic;

namespace BackEnd.Data.Services
{
    public class DisciplinaRepositorio : IDisciplinaRepostorio
    {
        private readonly DataContext _contexto;

        public DisciplinaRepositorio(DataContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<IEnumerable<Disciplina>> ObterTodos(bool incluirProfessor)
        {
            IQueryable<Disciplina> consulta = _contexto.Disciplina;

            if (incluirProfessor) 
            {
                consulta = consulta.Include(d => d.Professor);
            }

            consulta = consulta.AsNoTracking().OrderBy(a => a.id);

            return await consulta.ToArrayAsync();
        }

        public async Task<Disciplina> ObterPeloId(int disciplinaId, bool incluirProfessor)
        {
            IQueryable<Disciplina> consulta = _contexto.Disciplina;

            if (incluirProfessor) 
            {
                consulta = consulta..Include(d => d.Professor);
            }

            consulta = consulta.AsNoTracking()
                               .OrderBy(a => a.id)
                               .Where(d => d.id == disciplinaId);

            return await consulta.FirstOrDefaultAsync();
        }

    }
}