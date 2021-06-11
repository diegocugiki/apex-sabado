namespace BackEnd.Models
{
    public class AlunoDisciplina
    {
        public int alunoId { get; set; }
        public Aluno Aluno { get; set; }
        public int disciplinaId { get; set; }
        public Disciplina Disciplina { get; set; }

        public AlunoDisciplina() {}

        public AlunoDisciplina(int alunoId, int disciplinaId)
        {
            this.alunoId = alunoId;
            this.disciplinaId = disciplinaId;
        }
    }
}