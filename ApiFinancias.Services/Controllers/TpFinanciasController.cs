using Api.TpFinanceiro.Data.Entities;
using Api.TpFinanceiro.Data.Repositories;
using ApiFinancias.Services.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiFinancias.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TpFinanciasController : ControllerBase
    {
          private readonly IMapper _mapper;

        //construtor para inicializar os atributos da classe
        public TpFinanciasController(IMapper mapper)
        {
            _mapper = mapper;
        }


        [HttpPost]
        public IActionResult Post(TpFinanciasPostmodel model)
        {
            try
            {
                var tpfinancias = _mapper.Map<TpFinancias>(model);

                var tpfinanciasRepository = new TpFinanciasRepository();
                tpfinanciasRepository.Add(tpfinancias);

                //HTTP 201 (CREATED)
                return StatusCode(201,new { mensagem = " cadastrado com sucesso.",
                    tpfinancias = _mapper.Map<TpFinanciasGetModel>(tpfinancias)
                });
            }
            catch (Exception e)
            {
                //HTTP 500 (INTERNAL SERVER ERROR)
                return StatusCode(500,new{ mensagem = "Falha ao cadastrar : "+ e.Message});
            }

        }

        [HttpGet]
        [ProducesResponseType(typeof(List<TpFinanciasGetModel>), 200)]
        public IActionResult GetAll()
        {
            try
            {
                var tpfinanciasRepository = new TpFinanciasRepository();
                var tpfinancias = tpfinanciasRepository.GetAll();


                return StatusCode(200, _mapper.Map<List<TpFinanciasGetModel>>(tpfinancias));
            }
            catch (Exception e)
            {
                return StatusCode(500,new{mensagem = "Erro ao consultar : "+ e.Message});
            }

        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(TpFinanciasGetModel), 200)]
        public IActionResult GetById(Guid? id)

        {
            try
            {
                var tpfinanciasRepository = new TpFinanciasRepository();
                var tpfinancias = tpfinanciasRepository.GetById(id);

                if (tpfinancias == null)
                    return StatusCode(404,new { mensagem = "Categoria não encontrada." });
                else
                    return StatusCode(200, _mapper.Map<TpFinanciasGetModel>(tpfinancias));
            }
            catch (Exception e)
            {
                return StatusCode(500,new{   mensagem = "Erro ao obter categoria: "+ e.Message});
            }

        }

        [HttpPut]
        public IActionResult Put(TpFinanciasPutModel model)
        {
            try
            {
                var tpfinanciasRepository = new TpFinanciasRepository();

                if (tpfinanciasRepository.GetById(model.IdTpFinancias) == null)
                    return StatusCode(404,new { mensagem = "não encontrada." });

                var tpFinancias = _mapper.Map<TpFinancias>(model);
                tpfinanciasRepository.Update(tpFinancias);

                //HTTP 200 (OK)
                return StatusCode(200, new
                {
                    mensagem = " atualizado com sucesso.",
                    categoria = _mapper.Map<TpFinanciasGetModel>(tpFinancias)
                });
            }



            catch (Exception e)
            {
                return StatusCode(500,new{mensagem = "Falha ao atualizar: "+ e.Message});
            }

        }
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid? id)
        {
            try
            {
                var tpfinanciasRepository = new TpFinanciasRepository();
                var tpfinancias = tpfinanciasRepository.GetById(id);

                if (tpfinancias == null)
                    return StatusCode(404,new { mensagem = " não encontrada." });

                tpfinanciasRepository.Delete(tpfinancias);

                //HTTP 200 (OK)
                return StatusCode(200, new
                {
                    mensagem = "Categoria excluída com sucesso.",
                    categoria = _mapper.Map<TpFinanciasGetModel>(tpfinancias)
                });
            }
            catch (Exception e)
            {
                return StatusCode(500,new{ mensagem = "Falha ao excluir : "+ e.Message});
            }

        }
    }
}
