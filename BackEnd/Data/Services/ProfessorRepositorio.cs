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
    }
}