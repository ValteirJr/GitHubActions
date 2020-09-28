using Dapper;
using Domain.Entities;
using Domain.IRepositories;
using Infra.Factory;
using Infra.Scripts;
using System;
using System.Linq;

namespace Infra.Repositories
{
    public class CursoRepository : ICursoRepository
    {
        public bool AtualizarCurso(CursoEntity curso)
        {
            using (var connection = ConnectionFactory.RetornaConexao())
            {
                try
                {
                    connection.Execute(Cursos.AtualizarCursoPorId, curso, ConnectionFactory.RetornaTransacaoAtual());
                    ConnectionFactory.FinalizarTransacao();
                    return true;
                }

                catch (Exception ex)
                {
                    ConnectionFactory.CancelarTransacao();
                    throw ex;
                }
            }
        }

        public CursoEntity RetornaCursoPorId(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", id, System.Data.DbType.Int32);

            using (var connection = ConnectionFactory.RetornaConexao())
            {
                try
                {
                    var curso = connection.Query<CursoEntity>(Cursos.BuscarCursoPorId, parameters, ConnectionFactory.RetornaTransacaoAtual()).FirstOrDefault();
                    ConnectionFactory.FinalizarTransacao();
                    return curso;
                }

                catch (Exception ex)
                {
                    ConnectionFactory.CancelarTransacao();
                    throw ex;
                }
            }
        }

        public int SalvarCurso(CursoEntity cursoSalvar)
        {
            using (var connection = ConnectionFactory.RetornaConexao())
            {
                try
                {
                    var novoId = connection.Execute(Cursos.SalvarCurso + " Select @@Identity", cursoSalvar, ConnectionFactory.RetornaTransacaoAtual());
                    ConnectionFactory.FinalizarTransacao();
                    return novoId;
                }

                catch (Exception ex)
                {
                    ConnectionFactory.CancelarTransacao();
                    throw ex;
                }
            }
        }
    }
}
