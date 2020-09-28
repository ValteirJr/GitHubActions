using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Cursos.Controllers.BaseApi;
using Application.Models;
using Application.Interfaces;

namespace Cursos.Controllers
{
    [Route("api/cursos")]
    [ApiController]
    public class CursoController : BaseController
    {
        private readonly ICursoApplication _cursoApplication;

        public CursoController(ICursoApplication cursoApplication)
        {
            _cursoApplication = cursoApplication;
        }

        [Route("{id}")]
        [HttpGet]
        public ActionResult<string> Get(int id)
        {
            var retorno = _cursoApplication.RetornaCursoPorId(id);
            if (retorno.Valid)
                return Ok(JsonConvert.SerializeObject(retorno.Object, Formatting.Indented));
       
            return BadRequest(JsonConvert.SerializeObject(retorno.Notifications, Formatting.Indented));
        }

        [HttpPost]
        public ActionResult<string>Post(CursoModel curso)
        {
            var retorno = _cursoApplication.SalvarCurso(curso);
            if (retorno.Valid)
                return Ok(JsonConvert.SerializeObject(retorno.Object, Formatting.Indented));

            return BadRequest(JsonConvert.SerializeObject(retorno.Notifications, Formatting.Indented));
        }

        // PUT api/values/5
        [HttpPut]
        public ActionResult Put(CursoModel curso)
        {
            var retorno = _cursoApplication.AtualizarCurso(curso);
            if (retorno.Valid)
                return Ok(JsonConvert.SerializeObject("Curso Atualizado com sucesso", Formatting.Indented));

            return BadRequest(JsonConvert.SerializeObject(retorno.Notifications, Formatting.Indented));

        }
    }
}
