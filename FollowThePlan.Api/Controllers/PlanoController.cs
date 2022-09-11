using AutoMapper;
using FollowThePlan.Api.Model;
using FollowThePlan.Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FollowThePlan.Api.DTO
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PlanoController : ControllerBase
    {
        private readonly IRepository _repo;
        private readonly IMapper _mapper;
        private readonly IPlanoRepository _planoRepo;

        public PlanoController(IRepository repo, IMapper mapper, IPlanoRepository planoRepo)
        {
            _repo = repo;
            _mapper = mapper;
            _planoRepo = planoRepo;
        }

        [HttpGet("{id}")]
        public IActionResult GetObjetivoById(int id)
        {
            var plano = _planoRepo.GetPlanoById(id);

            if (plano == null) return BadRequest($"O plano {id} não foi encontrado");

            var model = _mapper.Map<Plano>(plano);

            return Ok(model);
        }
        [HttpPost]
        public IActionResult Post(Plano model)
        {
            var plano = _mapper.Map<Plano>(model);

            _repo.Add(plano);

            if (_repo.SaveChanges())
            {
                return Created($"/api/plano/{model.Id}", _mapper.Map<Plano>(plano));
            }

            return BadRequest("Plano não cadastrado");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Plano model) // entidade aluno
        {
            var plano = _planoRepo.GetPlanoById(id);

            if (plano == null) return BadRequest("Plano não encontrado");

            _mapper.Map(model, plano);

            _repo.Update(plano);

            if (_repo.SaveChanges())
            {
                return Created($"/api/plano/{model.Id}", _mapper.Map<Plano>(plano));
            }

            return BadRequest("Plano não atualizado");
        }


        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Plano model)
        {
            var plano = _planoRepo.GetPlanoById(id);

            if (plano == null) return BadRequest("Plano não encontrado");

            _mapper.Map(model, plano);

            _repo.Update(plano);

            if (_repo.SaveChanges())
            {
                return Created($"/api/plano/{model.Id}", _mapper.Map<Plano>(plano));
            }

            return BadRequest("Plano não atualizado");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var plano = _planoRepo.GetPlanoById(id);

            if (plano == null) return BadRequest("Plano não encontrado");

            _repo.Delete(plano);

            if (_repo.SaveChanges())
            {
                return Ok("Plano deletado");
            }

            return BadRequest("Plano não deletado");
        }

    }
}