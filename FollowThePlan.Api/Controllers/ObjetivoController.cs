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
    public class ObjetivoController : ControllerBase
    {
        private readonly IRepository _repo;
        private readonly IMapper _mapper;
        private readonly IObjetivoRepository _objetivoRepo;

        public ObjetivoController(IRepository repo, IMapper mapper, IObjetivoRepository objetivoRepo)
        {
            _repo = repo;
            _mapper = mapper;
            _objetivoRepo = objetivoRepo;
        }

        //  [HttpGet]
        //public IActionResult Get(int userId)
        //{
        //    var objetivos = _objetivoRepo.GetAll(userId);

        //    return Ok(_mapper.Map<IEnumerable<Objetivo>>(objetivos));
        //}


        [HttpGet("{id}")]
        public IActionResult GetObjetivoById(int id)
        {
            var objetivo = _objetivoRepo.GetObjetivoById(id);

            if (objetivo == null) return BadRequest($"O objetivo {id} não foi encontrado");

            var model = _mapper.Map<Objetivo>(objetivo);

            return Ok(model);
        }
        [HttpPost]
        public IActionResult Post(Objetivo model)
        {
            var objetivo = _mapper.Map<Objetivo>(model);

            _repo.Add(objetivo);

            if (_repo.SaveChanges())
            {
                return Created($"/api/objetivo/{model.Id}", _mapper.Map<Objetivo>(objetivo));
            }

            return BadRequest("Objetivo não cadastrado");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Objetivo model) // entidade aluno
        {
            var objetivo = _objetivoRepo.GetObjetivoById(id);

            if (objetivo == null) return BadRequest("Objetivo não encontrado");

            _mapper.Map(model, objetivo);

            _repo.Update(objetivo);

            if (_repo.SaveChanges())
            {
                return Created($"/api/objetivo/{model.Id}", _mapper.Map<Objetivo>(objetivo));
            }

            return BadRequest("Objetivo não atualizado");
        }


        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Objetivo model)
        {
            var objetivo = _objetivoRepo.GetObjetivoById(id);

            if (objetivo == null) return BadRequest("Objetivo não encontrado");

            _mapper.Map(model, objetivo);

            _repo.Update(objetivo);

            if (_repo.SaveChanges())
            {
                return Created($"/api/objetivo/{model.Id}", _mapper.Map<Objetivo>(objetivo));
            }

            return BadRequest("Objetivo não atualizado");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var objetivo = _objetivoRepo.GetObjetivoById(id);

            if (objetivo == null) return BadRequest("Objetivo não encontrado");

            _repo.Delete(objetivo);

            if (_repo.SaveChanges())
            {
                return Ok("Objetivo deletado");
            }

            return BadRequest("Objetivo não deletado");
        }

    }
}