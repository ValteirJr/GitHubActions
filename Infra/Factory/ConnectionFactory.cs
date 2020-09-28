
using System.Data.SqlClient;

namespace Infra.Factory
{
    /// <summary>
    /// Aplicando o padrão Factory para gerenciar conexões de banco de dados
    /// </summary>
    public static class ConnectionFactory
    {
        private static SqlTransaction transaction { get; set; }
        private static SqlConnection connection { get; set; }

        public static SqlConnection RetornaConexao()
        {
            return connection == null || connection.State == System.Data.ConnectionState.Closed ? new SqlConnection(Enviroment.StringDeConexao) : connection;
        }


        public static SqlTransaction RetornaTransacaoAtual()
        {
            if (connection == null || connection.State == System.Data.ConnectionState.Closed || transaction == null)
            {
                transaction = RetornaConexao().BeginTransaction();
            }
            return transaction;
        }

        public static void IniciarTransacao()
        {
            if (connection != null)
                FecharConexao();
            connection = RetornaConexao();
            connection.Open();
            transaction = connection.BeginTransaction();
        }

        public static void FinalizarTransacao()
        {
            try
            {
                transaction.Commit();
                FecharConexao();
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }
        public static void CancelarTransacao()
        {
            transaction.Rollback();
            FecharConexao();
        }
        private static void FecharConexao()
        {
            connection.Close();
            connection = null;
        }
    }
}
