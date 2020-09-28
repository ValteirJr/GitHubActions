using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class CursoEntity
    {
        
        public string DescricaoAssunto { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public int AlunosPorTurma { get; set; }
        public int Categoria { get; set; }
        public int Id { get; set; }
    }
}
