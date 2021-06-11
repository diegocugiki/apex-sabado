using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BackEnd.Data.Interfaces;
using BackEnd.Models;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DisciplinaController : ControllerBase
    {
        private readonly IDisciplinaRepositorio _disciplinaRepositorio;
        private readonly IRepositorio _repositorio;

        public DisciplinaController(IDisciplinaRepositorio disciplinaRepositorio,
                               IRepositorio repositorio)
        {
            _disciplinaRepositorio = disciplinaRepositorio;
            _repositorio = repositorio;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos() 
        {
            try
            {
                var listaDisciplinas = await _disciplinaRepositorio.ObterTodos(incluirProfessor: true);
                return Ok(listaDisciplinas);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ao obter todos as disciplinas, ocorreu o erro: {ex.Message}");
            }
        }

        [HttpGet("id={id}")]
        public async Task<IActionResult> ObterPeloId(int id) 
        {
            try
            {
                var disciplina = await _disciplinaRepositorio.ObterPeloId(id, incluirProfessor: true);
                return Ok(disciplina);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ao obter todos as disciplinas, ocorreu o erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Salvar(Disciplina disciplina) 
        {
            try
            {
                _repositorio.Adicionar(disciplina);

                if (await _repositorio.EfetuouAlteracoes()) 
                {
                    return Ok(disciplina);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Ao salvar a disciplina, ocorreu o erro: {ex.Message}");                
            }
            return BadRequest();
        }

        [HttpPut("id={id}")]
        public async Task<IActionResult> Editar(int id, Disciplina disciplina)
        {
            try
            {
                var disciplinaCadastrado = await _disciplinaRepositorio.ObterPeloId(id, incluirProfessor: false);
                if (disciplinaCadastrado == null)
                {
                    return NotFound("Disicplina não localizado!");
                }

                _repositorio.Atualizar(disciplina);

                if (await _repositorio.EfetuouAlteracoes())
                {
                    return Ok(disciplina);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Ao editar a disciplina, ocorreu o erro: {ex.Message}");
            }
            return BadRequest();
        }

        [HttpDelete("id={id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            try
            {
                var disciplinaCadastrado = await _disciplinaRepositorio.ObterPeloId(id, incluirProfessor: false);
                if (disciplinaCadastrado == null)
                {
                    return NotFound("Disciplina não localizado!");
                }

                _repositorio.Deletar(disciplinaCadastrado);

                if (await _repositorio.EfetuouAlteracoes())
                {
                    return Ok(
                        new {
                            message="Disicplina removida"
                        }
                    );
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Ao deletar a disciplina, ocorreu o erro: {ex.Message}");
            }
            return BadRequest();
        }
    }
}