using Application.Models;
using Application.Result;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface ICursoApplication
    {
        Result<CursoEntity> RetornaCursoPorId(int id);
        Result<CursoEntity> SalvarCurso(CursoModel curso);
        Result.Result AtualizarCurso(CursoModel curso);
    }
}
