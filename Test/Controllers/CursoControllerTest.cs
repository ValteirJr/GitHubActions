using Application.Applications;
using Application.Models;
using Cursos.Controllers;
using Domain.Entities;
using Domain.IRepositories;
using Moq;
using Newtonsoft.Json;
using System;
using Xunit;

namespace Test.Controllers
{
    public class CursoControllerTest
    {
        private CursoController cursoController;
        public CursoControllerTest()
        {
            cursoController = instanciaController();
        }

        private CursoController instanciaController()
        {
            var mockCursoRepository = new Mock<ICursoRepository>();

            #region Setup de Mock de aplication

            mockCursoRepository.Setup
                            (x => x.RetornaCursoPorId(It.IsAny<int>()))
                            .Returns((int Id) => new Domain.Entities.CursoEntity() { Id = Id })
                            .Verifiable();

            mockCursoRepository.Setup
                          (x => x.SalvarCurso(It.IsAny<CursoEntity>()))
                          .Returns(1)
                          .Verifiable();

            mockCursoRepository.Setup
                           (x => x.AtualizarCurso(It.IsAny<CursoEntity>()))
                           .Returns(true)
                           .Verifiable();

            #endregion

            var cursoApplication = new CursoApplication(mockCursoRepository.Object);

            return new CursoController(cursoApplication);
        }


        [Fact]
        public void RetornaCursoPorIDTeste()
        {
            int valorConsulta = 1;

            var curso = cursoController.Get(valorConsulta);
            var cursoValido = JsonConvert.DeserializeObject<CursoModel>(curso.Value);

            Assert.True(cursoValido is CursoModel && cursoValido.Id == valorConsulta);

        }

        [Fact]
        public void SalvarCursoTeste()
        {
            var curso = new CursoModel()
            {
                AlunosPorTurma = 10,
                DataInicio = DateTime.Now,
                DataFim = DateTime.Now.AddDays(7),
                DescricaoAssunto = "Curso Teste",
                Categoria = Infra.Enums.Categoria.Programação
            };

            var retorno = cursoController.Post(curso);

            Assert.True(int.Parse(retorno.Value) > 0);

        }

        [Fact]
        public void AtualizarCursoTeste()
        {
            var curso = new CursoModel()
            {
                AlunosPorTurma = 15,
                DataInicio = DateTime.Now,
                DataFim = DateTime.Now.AddDays(7),
                DescricaoAssunto = "Curso Teste",
                Categoria = Infra.Enums.Categoria.Programação,
                Id = 1,
            };

            cursoController.Put(curso);
        }
    }
}
