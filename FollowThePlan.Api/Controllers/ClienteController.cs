using AutoMapper;
using FollowThePlan.Api.DTO;
using FollowThePlan.Api.Model;
using FollowThePlan.Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static FollowThePlan.Api.Repositories.ClienteRepository;

namespace FollowThePlan.Api.Controllers
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IRepository _repo;
        private readonly IMapper _mapper;
        private readonly IClienteRepository _clienteRepo;

        public ClienteController(IRepository repo, IMapper mapper, IClienteRepository clientRepo)
        {
            _repo = repo;
            _mapper = mapper;
            _clienteRepo = clientRepo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var clientes = _clienteRepo.GetAll();

            return Ok(_mapper.Map<IEnumerable<ClienteDTO>>(clientes));
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var cliente = _clienteRepo.GetById(id);

            if (cliente == null) return BadRequest($"O cliente {id} não foi encontrado");

            var userDTO = _mapper.Map<ClienteDTO>(cliente);

            return Ok(userDTO);
        }

        [HttpPost]
        public IActionResult Post(ClienteRegisterDTO model)
        {
            var user = _mapper.Map<Cliente>(model);

            _repo.Add(user);

            if (_repo.SaveChanges())
            {
                return Created($"/api/cliente/{model.Id}", _mapper.Map<ClienteDTO>(user));
            }

            return BadRequest("Cliente não cadastrado");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, ClienteRegisterDTO model) // entidade aluno
        {
            var cliente = _clienteRepo.GetById(id);

            if (cliente == null) return BadRequest("Cliente não encontrado");

            _mapper.Map(model, cliente);


            _repo.Update(cliente);

            if (_repo.SaveChanges())
            {
                return Created($"/api/cliente/{model.Id}", _mapper.Map<ClienteDTO>(cliente));
            }

            return BadRequest("Cliente não atualizado");
        }


        [HttpPatch("{id}")]
        public IActionResult Patch(int id, ClienteRegisterDTO model)
        {
            var cliente = _clienteRepo.GetById(id);

            if (cliente == null) return BadRequest("Cliente não encontrado");

            _mapper.Map(model, cliente);

            _repo.Update(cliente);

            if (_repo.SaveChanges())
            {
                return Created($"/api/cliente/{model.Id}", _mapper.Map<ClienteDTO>(cliente));
            }

            return BadRequest("Cliente não atualizado");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var cliente = _clienteRepo.GetById(id);

            if (cliente == null) return BadRequest("Cliente não encontrado");

            _repo.Delete(cliente);

            if (_repo.SaveChanges())
            {
                return Ok("Cliente deletado");
            }

            return BadRequest("Cliente não deletado");
        }

    }
}
