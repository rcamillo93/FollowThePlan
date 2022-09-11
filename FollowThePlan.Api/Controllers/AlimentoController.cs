using AutoMapper;
using FollowThePlan.Api.Model;
using FollowThePlan.Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FollowThePlan.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AlimentoController : ControllerBase
    {
        private readonly IRepository _repo;
        private readonly IMapper _mapper;
        private readonly IAlimentoRepository _alimentoRepo;

        public AlimentoController(IRepository repo, IMapper mapper, IAlimentoRepository alimentoRepo)
        {
            _repo = repo;
            _mapper = mapper;
            _alimentoRepo = alimentoRepo;
        }

        [HttpGet("{id}")]
        public IActionResult GetObjetivoById(int id)
        {
            var alimento = _alimentoRepo.GetAlimentoById(id);

            if (alimento == null) return BadRequest($"O alimento {id} não foi encontrado");

            var model = _mapper.Map<Alimento>(alimento);

            return Ok(model);
        }
        [HttpPost]
        public IActionResult Post(Alimento model)
        {
            var alimento = _mapper.Map<Alimento>(model);

            _repo.Add(alimento);

            if (_repo.SaveChanges())
            {
                return Created($"/api/alimento/{model.Id}", _mapper.Map<Alimento>(alimento));
            }

            return BadRequest("Alimento não cadastrado");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Alimento model) // entidade aluno
        {
            var alimento = _alimentoRepo.GetAlimentoById(id);

            if (alimento == null) return BadRequest("Alimento não encontrado");

            _mapper.Map(model, alimento);

            _repo.Update(alimento);

            if (_repo.SaveChanges())
            {
                return Created($"/api/alimento/{model.Id}", _mapper.Map<Alimento>(alimento));
            }

            return BadRequest("Plano não atualizado");
        }


        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Alimento model)
        {
            var alimento = _alimentoRepo.GetAlimentoById(id);

            if (alimento == null) return BadRequest("Alimento não encontrado");

            _mapper.Map(model, alimento);

            _repo.Update(alimento);

            if (_repo.SaveChanges())
            {
                return Created($"/api/alimento/{model.Id}", _mapper.Map<Alimento>(alimento));
            }

            return BadRequest("Alimento não atualizado");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var alimento = _alimentoRepo.GetAlimentoById(id);

            if (alimento == null) return BadRequest("Alimento não encontrado");

            _repo.Delete(alimento);

            if (_repo.SaveChanges())
            {
                return Ok("Alimento deletado");
            }

            return BadRequest("Alimento não deletado");
        }

    }
}