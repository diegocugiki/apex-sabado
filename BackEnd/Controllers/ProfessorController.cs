using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BackEnd.Data.Interfaces;
using BackEnd.Models;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfessorController : ControllerBase
    {
        private readonly IProfessorRepositorio _professorRepositorio;
        private readonly IRepositorio _repositorio;

        public ProfessorController(IProfessorRepositorio professorRepositorio,
                               IRepositorio repositorio)
        {
            _professorRepositorio = professorRepositorio;
            _repositorio = repositorio;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos() 
        {
            try
            {
                var listaDeProfessores = await _professorRepositorio.ObterTodos(incluirAluno: true);
                return Ok(listaDeProfessores);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ao obter todos os professores, ocorreu o erro: {ex.Message}");
            }
        }

        [HttpGet("id={id}")]
        public async Task<IActionResult> ObterPeloId(int id) 
        {
            try
            {
                var professor = await _professorRepositorio.ObterPeloId(id, incluirAluno: true);
                return Ok(professor);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ao obter todos os professores, ocorreu o erro: {ex.Message}");
            }
        }

        [HttpGet("alunoId={alunoId}")]
        public async Task<IActionResult> ObterTodosPeloAlunoId(int alunoId) 
        {
            try
            {
                var listaDeProfessores = await _professorRepositorio.ObterTodosPeloAlunoId(alunoId, incluirDisciplina: true);
                return Ok(listaDeProfessores);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ao obter todos os professores, ocorreu o erro: {ex.Message}");
            }
        }


        [HttpPost]
        public async Task<IActionResult> Salvar(Professor professor) 
        {
            try
            {
                _repositorio.Adicionar(professor);

                if (await _repositorio.EfetuouAlteracoes()) 
                {
                    return Ok(professor);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Ao salvar o professor, ocorreu o erro: {ex.Message}");                
            }
            return BadRequest();
        }

        [HttpPut("id={id}")]
        public async Task<IActionResult> Editar(int id, Professor professor)
        {
            try
            {
                var professorCadastrado = await _professorRepositorio.ObterPeloId(id, incluirAluno: false);
                if (professorCadastrado == null)
                {
                    return NotFound("Professor não localizado!");
                }

                _repositorio.Atualizar(professor);

                if (await _repositorio.EfetuouAlteracoes())
                {
                    return Ok(professor);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Ao editar o professor, ocorreu o erro: {ex.Message}");
            }
            return BadRequest();
        }

        [HttpDelete("id={id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            try
            {
                var professorCadastrado = await _professorRepositorio.ObterPeloId(id, incluirAluno: false);
                if (professorCadastrado == null)
                {
                    return NotFound("Professor não localizado!");
                }

                _repositorio.Deletar(professorCadastrado);

                if (await _repositorio.EfetuouAlteracoes())
                {
                    return Ok(
                        new {
                            message="Professor removido"
                        }
                    );
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Ao deletar o professor, ocorreu o erro: {ex.Message}");
            }
            return BadRequest();
        }
    }
}