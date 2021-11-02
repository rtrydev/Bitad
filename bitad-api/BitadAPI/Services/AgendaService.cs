using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BitadAPI.Dto;
using BitadAPI.Models;
using BitadAPI.Repositories;

namespace BitadAPI.Services
{
    public interface IAgendaService
    {
        public Task<ICollection<DtoAgenda>> GetAll();
    }

    public class AgendaService : IAgendaService
    {
        private IAgendaRepository _agendaRepository;
        private IMapper _mapper;

        public AgendaService(IAgendaRepository agendaRepository, IMapper mapper)
        {
            _agendaRepository = agendaRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<DtoAgenda>> GetAll()
        {
            var agendas = await _agendaRepository.GetAll();
            return _mapper.Map<ICollection<Agenda>, ICollection<DtoAgenda>>(agendas);
        }
    }
}
