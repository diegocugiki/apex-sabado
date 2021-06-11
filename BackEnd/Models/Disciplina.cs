using System.Collections.Generic;

namespace BackEnd.Models
{
    public class Disciplina
    {
        public int id { get; set; }
        public string nome { get; set; }
        public int professorId { get; set; }
        public Professor Professor { get; set; }
        public IEnumerable<AlunoDisciplina> AlunosDisciplinas { get; set; }

        public Disciplina() {}

        public Disciplina(int id, string nome, int professorId)
        {
            this.id = id;
            this.nome = nome;
            this.professorId = professorId;
        }
    }
}