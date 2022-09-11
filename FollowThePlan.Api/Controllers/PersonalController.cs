using AutoMapper;
using FollowThePlan.Api.DTO;
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
    public class PersonalController : ControllerBase
    {
        private readonly IRepository _repo;
        private readonly IMapper _mapper;
        private readonly IPersonalRepository _personalRepository;

        public PersonalController(IRepository repo, IMapper mapper, IPersonalRepository personalRepository)
        {
            _repo = repo;
            _mapper = mapper;
            _personalRepository = personalRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var personal = _personalRepository.GetAll();

            return Ok(_mapper.Map<IEnumerable<PersonalDTO>>(personal));
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var personal = _personalRepository.GetById(id);

            if (personal == null) return BadRequest($"O personal {id} não foi encontrado");

            var userDTO = _mapper.Map<PersonalDTO>(personal);

            return Ok(userDTO);
        }


        [HttpPost]
        public IActionResult Post(PersonalRegisterDTO model)
        {
            var personal = _mapper.Map<Personal>(model);

            _repo.Add(personal);

            if (_repo.SaveChanges())
            {
                return Created($"/api/personal/{model.Id}", _mapper.Map<PersonalDTO>(personal));
            }

            return BadRequest("Personal não cadastrado");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, PersonalDTO model) // entidade aluno
        {
            var personal = _personalRepository.GetById(id);

            if (personal == null) return BadRequest("Personal não encontrado");

            _mapper.Map(model, personal);


            _repo.Update(personal);

            if (_repo.SaveChanges())
            {
                return Created($"/api/personal/{model.Id}", _mapper.Map<PersonalDTO>(personal));
            }

            return BadRequest("Personal não atualizado");
        }


        [HttpPatch("{id}")]
        public IActionResult Patch(int id, PersonalRegisterDTO model)
        {
            var personal = _personalRepository.GetById(id);

            if (personal == null) return BadRequest("Personal não encontrado");

            _mapper.Map(model, personal);

            _repo.Update(personal);

            if (_repo.SaveChanges())
            {
                return Created($"/api/personal/{model.Id}", _mapper.Map<PersonalDTO>(personal));
            }

            return BadRequest("Personal não atualizado");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var personal = _personalRepository.GetById(id);

            if (personal == null) return BadRequest("Personal não encontrado");

            _repo.Delete(personal);

            if (_repo.SaveChanges())
            {
                return Ok("Personal deletado");
            }

            return BadRequest("Personal não deletado");
        }

    }
}
