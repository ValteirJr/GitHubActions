using Domain.Entities;
using Infra.Enums;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Application.Models
{
    public class CursoModel
    {
        public string DescricaoAssunto { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public int AlunosPorTurma { get; set; }
        public Categoria Categoria { get; set; }
        public int Id { get; set; }
    }

    public static class CursoModelExtensions
    {
        public static CursoEntity ToEntity(this CursoModel curso)
        {
            return new CursoEntity()
            {
                Categoria = (int)curso.Categoria,
                AlunosPorTurma = curso.AlunosPorTurma,
                DataFim = curso.DataFim,
                DataInicio = curso.DataInicio,
                DescricaoAssunto = curso.DescricaoAssunto,
                Id = curso.Id
            };
        }
    }
}
