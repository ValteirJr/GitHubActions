using Domain.Entities;

namespace Domain.IRepositories
{
    public interface ICursoRepository
    {
        CursoEntity RetornaCursoPorId(int id);
        bool AtualizarCurso(CursoEntity curso);
        int SalvarCurso(CursoEntity cursoSalvar);
    }
}
