using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Scripts
{
    public static class Cursos
    {
        public static string AtualizarCursoPorId = "Update Cursos "
            + " set DescricaoAssunto = @DescricaoAssunto ,"
            + " DataInicio = @DataInicio ,"
            + " DataFim = @DataFim , "
            + " AlunosPorTurma = @AlunosPorTurma, "
            + " Categoria = @Categoria"
            + " where Id = @Id ";

        public static string SalvarCurso = "insert into Cursos "
                  + " DescricaoAssunto, DataInicio, DataFim , AlunosPorTurma,Categoria "
            + " values (@DescricaoAssunto,@DataInicio, @DataFim, @AlunosPorTurma, @Categoria ) ";

        public static string BuscarCursoPorId = "select Id, DescricaoAssunto, DataInicio, DataFim , AlunosPorTurma,Categoria "
                   + "from  Cursos "
                   + " where Id = @Id ";

        public static string ScriptCreate = "create table Cursos ( "
                            + " Id int NOT NULL PRIMARY KEY, "
                            + " DescricaoAssunto varchar(100) NOT NULL, "
                            + " DataInicio DateTime2(0) NOT NULL, "
                            + " DataFim DateTime2(0) NOT NULL, "
                            + " AlunosPorTurma int, "
                            + " Categoria int NOT NULL FOREIGN KEY REFERENCES Categoria(Codigo)) ";

    }
}
