using Application.Interfaces;
using Application.Models;
using Application.Result;
using Domain.Entities;
using Domain.IRepositories;

namespace Application.Applications
{
    public class CursoApplication : ICursoApplication
    {
        private readonly ICursoRepository _cursoRepository;
        public CursoApplication(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        public Result.Result AtualizarCurso(CursoModel curso)
        {
            var retorno = _cursoRepository.AtualizarCurso(curso.ToEntity());
            if (retorno)
                return Result.Result.Ok();
            return Result.Result.Error("Cursos", "Não foi possível Atualizar o curso");
        }

        public Result<CursoEntity> RetornaCursoPorId(int id)
        {
            var curso = _cursoRepository.RetornaCursoPorId(id);
            if (curso != null)
                return Result<CursoEntity>.Ok(curso);
            return Result<CursoEntity>.Error("Cursos","Não foi possível encotrar um curso com esse identificador");

        }

        public Result<CursoEntity> SalvarCurso(CursoModel curso)
        {
            var cursoSalvar = curso.ToEntity();
            int retorno = _cursoRepository.SalvarCurso(cursoSalvar);
            if (retorno > 0)
            {
                cursoSalvar.Id = retorno;
                return Result<CursoEntity>.Ok(cursoSalvar);
            }
            return Result<CursoEntity>.Error("Cursos", "Não foi possível salvar o curso");
        }
    }
}
