using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BackEnd.Data.Interfaces;
using BackEnd.Models;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoRepositorio _alunoRepositorio;
        private readonly IRepositorio _repositorio;

        public AlunoController(IAlunoRepositorio alunoRepositorio,
                               IRepositorio repositorio)
        {
            _alunoRepositorio = alunoRepositorio;
            _repositorio = repositorio;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos() 
        {
            try
            {
                var listaDeAlunos = await _alunoRepositorio.ObterTodos(incluirProfessor: true);
                return Ok(listaDeAlunos);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ao obter todos os alunos, ocorreu o erro: {ex.Message}");
            }
        }

        [HttpGet("id={id}")]
        public async Task<IActionResult> ObterPeloId(int id) 
        {
            try
            {
                var aluno = await _alunoRepositorio.ObterPeloId(id, incluirProfessor: true);
                return Ok(aluno);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ao obter todos os alunos, ocorreu o erro: {ex.Message}");
            }
        }

        [HttpGet("disciplinaId={disciplinaId}")]
        public async Task<IActionResult> ObterPelaDisciplinaId(int disciplinaId) 
        {
            try
            {
                var listaDeAlunos = await _alunoRepositorio.ObterTodosPelaDisciplinaId(disciplinaId, incluirDisciplina: true);
                return Ok(listaDeAlunos);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ao obter todos os alunos, ocorreu o erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Salvar(Aluno aluno) 
        {
            try
            {
                _repositorio.Adicionar(aluno);

                if (await _repositorio.EfetuouAlteracoes()) 
                {
                    return Ok(aluno);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Ao salvar o aluno, ocorreu o erro: {ex.Message}");                
            }
            return BadRequest();
        }

        [HttpPut("id={id}")]
        public async Task<IActionResult> Editar(int id, Aluno aluno)
        {
            try
            {
                var alunoCadastrado = await _alunoRepositorio.ObterPeloId(id, incluirProfessor: false);
                if (alunoCadastrado == null)
                {
                    return NotFound("Aluno não localizado!");
                }

                _repositorio.Atualizar(aluno);

                if (await _repositorio.EfetuouAlteracoes())
                {
                    return Ok(aluno);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Ao editar o aluno, ocorreu o erro: {ex.Message}");
            }
            return BadRequest();
        }

        [HttpDelete("id={id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            try
            {
                var alunoCadastrado = await _alunoRepositorio.ObterPeloId(id, incluirProfessor: false);
                if (alunoCadastrado == null)
                {
                    return NotFound("Aluno não localizado!");
                }

                _repositorio.Deletar(alunoCadastrado);

                if (await _repositorio.EfetuouAlteracoes())
                {
                    return Ok(
                        new {
                            message="Aluno removido"
                        }
                    );
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Ao deletar o aluno, ocorreu o erro: {ex.Message}");
            }
            return BadRequest();
        }
        

    }
}