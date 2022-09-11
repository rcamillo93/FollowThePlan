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
    public class RefeicaoController : ControllerBase
    {
        private readonly IRepository _repo;
        private readonly IMapper _mapper;
        private readonly IRefeicaoRepository _refeicaoRepo;

        public RefeicaoController(IRepository repo, IMapper mapper, IRefeicaoRepository refeicaoRepo)
        {
            _repo = repo;
            _mapper = mapper;
            _refeicaoRepo = refeicaoRepo;
        }

        [HttpGet("{id}")]
        public IActionResult GetObjetivoById(int id)
        {
            var refeicao = _refeicaoRepo.GetRefeicaoById(id);

            if (refeicao == null) return BadRequest($"O refeição {id} não foi encontrada");

            var model = _mapper.Map<Refeicao>(refeicao);

            return Ok(model);
        }
        [HttpPost]
        public IActionResult Post(Refeicao model)
        {
            var refeicao = _mapper.Map<Refeicao>(model);

            _repo.Add(refeicao);

            if (_repo.SaveChanges())
            {
                return Created($"/api/refeicao/{model.Id}", _mapper.Map<Refeicao>(refeicao));
            }

            return BadRequest("Refeição não cadastrada");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Refeicao model) // entidade aluno
        {
            var refeicao = _refeicaoRepo.GetRefeicaoById(id);

            if (refeicao == null) return BadRequest("Refeição não encontrado");

            _mapper.Map(model, refeicao);

            _repo.Update(refeicao);

            if (_repo.SaveChanges())
            {
                return Created($"/api/refeicao/{model.Id}", _mapper.Map<Refeicao>(refeicao));
            }

            return BadRequest("Refeição não atualizada");
        }


        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Refeicao model)
        {
            var refeicao = _refeicaoRepo.GetRefeicaoById(id);

            if (refeicao == null) return BadRequest("Refeição não encontrado");

            _mapper.Map(model, refeicao);

            _repo.Update(refeicao);

            if (_repo.SaveChanges())
            {
                return Created($"/api/refeicao/{model.Id}", _mapper.Map<Refeicao>(refeicao));
            }

            return BadRequest("Refeição não atualizado");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var refeicao = _refeicaoRepo.GetRefeicaoById(id);

            if (refeicao == null) return BadRequest("Refeição não encontrado");

            _repo.Delete(refeicao);

            if (_repo.SaveChanges())
            {
                return Ok("Refeição deletado");
            }

            return BadRequest("Refeição não deletado");
        }

    }
}