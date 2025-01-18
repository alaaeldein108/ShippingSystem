using AutoMapper;
using Data.Entities.CustomerService.Ticket;
using Repositories.Interfaces;
using Repositories.Models;
using Services.CustomerServiceServices.TicketServices.TicketMainQuestionService.Dto;

namespace Services.CustomerServiceServices.TicketServices.TicketMainQuestionService
{
    public class TicketMainQuestionService : ITicketMainQuestionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TicketMainQuestionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task AddTicketMainQuestionAsync(TicketMainQuestionDto input)
        {
            var newMainQuestion = _mapper.Map<TicketMainQuestion>(input);
            newMainQuestion.CreatorId = input.CreatorId.Value;
            newMainQuestion.CreatedTime = DateTime.Now;
            newMainQuestion.Status = Data.Entities.Enums.StatusEnum.Active;
            await _unitOfWork.TicketMainQuestionRepository.AddTicketMainQuestionAsync(newMainQuestion);

            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteTicketMainQuestion(int id)
        {
            var existingTicket = await _unitOfWork.TicketMainQuestionRepository.FindTicketMainQuestionAsync(id);
            if (existingTicket == null)
            {
                throw new KeyNotFoundException($"Ticket Main Question with {id} Not Exist.");
            }
            existingTicket.Status = Data.Entities.Enums.StatusEnum.InActive;
            _unitOfWork.TicketMainQuestionRepository.UpdateTicketMainQuestion(existingTicket);

            await _unitOfWork.CompleteAsync();
        }

        public async Task<DataPage<TicketMainQuestionDto>> GetAllTicketMainQuestionAsync(SearchCriteria input)
        {
            var mainQuestions = await _unitOfWork.TicketMainQuestionRepository.GetAllTicketMainQuestionsAsync(input);
            var mainQuestionsDto = mainQuestions.Data
                .Select(mainQuestion => _mapper.Map<TicketMainQuestionDto>(mainQuestion))
                .AsQueryable();

            return new DataPage<TicketMainQuestionDto>(mainQuestions.PageIndex, mainQuestions.PageSize, mainQuestions.Count, mainQuestionsDto);
        }

        public async Task<TicketMainQuestionDto> GetTicketMainQuestionIdAsync(int id)
        {
            var existingTicket = await _unitOfWork.TicketMainQuestionRepository.FindTicketMainQuestionAsync(id);
            if (existingTicket == null)
            {
                throw new KeyNotFoundException($"Ticket Main Question with {id} Not Exist.");
            }
            var ticketMainQuestionDto = _mapper.Map<TicketMainQuestionDto>(existingTicket);
            return ticketMainQuestionDto;
        }

        public async Task UpdateTicketMainQuestion(TicketMainQuestionDto input)
        {
            var existingTicket = await _unitOfWork.TicketMainQuestionRepository.FindTicketMainQuestionAsync(input.Id.Value);
            if (existingTicket == null)
            {
                throw new KeyNotFoundException($"Ticket Main Question with {input.Id.Value} Not Exist.");
            }

            _mapper.Map(input, existingTicket);
            existingTicket.UpdatorId = input.UpdatorId;
            existingTicket.ModificationTime = input.ModificationTime;
            _unitOfWork.TicketMainQuestionRepository.UpdateTicketMainQuestion(existingTicket);

            await _unitOfWork.CompleteAsync();
        }
    }
}
