using System.Collections.Generic;

namespace BackEnd.Models
{
    public class Professor
    {
        public int id { get; set; }
        public string nome { get; set; }
        public IEnumerable<Disciplina> Disciplinas { get; set; }

        public Professor() {}

        public Professor(int id, string nome)
        {
            this.id = id;
            this.nome = nome;
        }
    }
}