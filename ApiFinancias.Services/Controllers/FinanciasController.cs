using Api.TpFinanceiro.Data.Entities;
using Api.TpFinanceiro.Data.Repositories;
using ApiFinancias.Services.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace ApiFinancias.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinanciasController : ControllerBase
    {
        private readonly IMapper _mapper;

        //construtor para inicializar os atributos da classe
        public FinanciasController(IMapper mapper)
        {
            _mapper = mapper;
        }
        [HttpPost]
        public IActionResult Post(FinanciasPostModel model)
        {
            try
            {
                var financias = _mapper.Map<Financias>(model);

                var financiasRepository = new FinanciasRepository();
                financiasRepository.Add(financias);

                //HTTP 201 (CREATED)
                return StatusCode(201, new
                {
                    mensagem = " cadastrado com sucesso.",
                    tpfinancias = _mapper.Map<FinanciasGetModel>(financias)
                });
            }
            catch (Exception e)
            {
                //HTTP 500 (INTERNAL SERVER ERROR)
                return StatusCode(500, new { mensagem = "Falha ao cadastrar : " + e.Message });
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<FinanciasGetModel>), 200)]
        public IActionResult GetAll()
        {
            try
            {
                var financiasRepository = new FinanciasRepository();
                var financias = financiasRepository.GetAll();

                return StatusCode(200, _mapper.Map<List<FinanciasGetModel>>(financias));
            }
            catch (Exception e)
            {
                return StatusCode(500,new{    mensagem = "Falha ao consultar produtos: "+ e.Message});
            }

        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(FinanciasGetModel), 200)]
        public IActionResult GetById(Guid? id)
        {
            try
            {
                var financiasRepository = new FinanciasRepository();
                var financias = financiasRepository.GetById(id);

                if (financias == null)
                    return StatusCode(404,new { mensagem = "Produto não encontrado." });

                return StatusCode(200, _mapper.Map<FinanciasGetModel>(financias));
            }
            catch (Exception e)
            {
                return StatusCode(500,new{    mensagem = "Falha ao obter produto: "+ e.Message});
            }

        }
        //mecher no PUT
        [HttpPut]
        public IActionResult Put(FinanciasPutModel model)
        {
            try
            {
                var financiasRepository = new FinanciasRepository();
                if (financiasRepository.GetById(model.IdFinancias) == null)
                    return StatusCode(404, new { mensagem = "Aluno não encontrado." });


                var financias = _mapper.Map<Financias>(model);
                financiasRepository.Update(financias);

                return StatusCode(200, new
                {
                    mensagem = "Produto atualizado com sucesso.",
                    produto = _mapper.Map<FinanciasGetModel>(financiasRepository.GetById(financias.IdFinancias))
                });
            }
            catch (Exception e)
            {
                return StatusCode(500,new{mensagem = "Falha ao atualizar produto: "+ e.Message});
            }

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid? id)
        {
            try
            {
                var financiasRepository = new FinanciasRepository();
                var financias = financiasRepository.GetById(id);

                if (financias == null)
                    return StatusCode(404,new { mensagem = "Produto não encontrado." });

                financiasRepository.Delete(financias);

                return StatusCode(200, new
                {
                    mensagem = "Produto excluído com sucesso.",
                    produto = _mapper.Map<FinanciasGetModel>(financias)
                });
            }
            catch (Exception e)
            {
                return StatusCode(500,new{    mensagem = "Falha ao excluir produto: "+ e.Message});
            }

        }
    }
}
