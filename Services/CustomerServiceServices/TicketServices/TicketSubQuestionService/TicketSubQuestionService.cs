using AutoMapper;
using Data.Entities.CustomerService.Ticket;
using Repositories.Interfaces;
using Repositories.Models;
using Services.CustomerServiceServices.TicketServices.TicketSubQuestionService.Dto;

namespace Services.CustomerServiceServices.TicketServices.TicketSubQuestionService
{
    public class TicketSubQuestionService : ITicketSubQuestionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TicketSubQuestionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task AddTicketSubQuestionAsync(TicketSubQuestionDto input)
        {
            var existingMainQuestion = await _unitOfWork.TicketMainQuestionRepository.FindTicketMainQuestionAsync(input.MainQuestionId);
            if (existingMainQuestion == null)
            {
                throw new KeyNotFoundException($"Ticket Main Question with {input.MainQuestionId} Not Exist.");
            }

            var newSubQuestion = _mapper.Map<TicketSubQuestion>(input);
            newSubQuestion.CreatorId = input.CreatorId.Value;
            newSubQuestion.CreatedTime = DateTime.Now;
            newSubQuestion.Status = Data.Entities.Enums.StatusEnum.Active;
            await _unitOfWork.TicketSubQuestionRepository.AddTicketSubQuestionAsync(newSubQuestion);

            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteTicketSubQuestion(int id)
        {
            var existingTicket = await _unitOfWork.TicketSubQuestionRepository.FindTicketSubQuestionAsync(id);
            if (existingTicket == null)
            {
                throw new KeyNotFoundException($"Ticket Sub Question with {id} Not Exist.");
            }
            existingTicket.Status = Data.Entities.Enums.StatusEnum.InActive;
            _unitOfWork.TicketSubQuestionRepository.UpdateTicketSubQuestion(existingTicket);

            await _unitOfWork.CompleteAsync();
        }

        public async Task<DataPage<TicketSubQuestionDto>> GetAllTicketSubQuestionAsync(SearchCriteria input)
        {
            var subQuestions = await _unitOfWork.TicketSubQuestionRepository.GetAllTicketSubQuestionsAsync(input);

            var subQuestionsDto = subQuestions.Data
                .Select(subQuestion => _mapper.Map<TicketSubQuestionDto>(subQuestion))
                .AsQueryable();

            return new DataPage<TicketSubQuestionDto>(subQuestions.PageIndex, subQuestions.PageSize, subQuestions.Count, subQuestionsDto);
        }

        public async Task<TicketSubQuestionDto> GetTicketSubQuestionIdAsync(int id)
        {
            var existingTicket = await _unitOfWork.TicketSubQuestionRepository.FindTicketSubQuestionAsync(id);
            if (existingTicket == null)
            {
                throw new KeyNotFoundException($"Ticket Sub Question with {id} Not Exist.");
            }
            var ticketSubQuestionDto = _mapper.Map<TicketSubQuestionDto>(existingTicket);
            return ticketSubQuestionDto;
        }

        public async Task UpdateTicketSubQuestion(TicketSubQuestionDto input)
        {
            var existingTicket = await _unitOfWork.TicketSubQuestionRepository.FindTicketSubQuestionAsync(input.Id.Value);
            if (existingTicket == null)
            {
                throw new KeyNotFoundException($"Ticket Sub Question with {input.Id.Value} Not Exist.");
            }
            var existingTicketMainQuestion = await _unitOfWork.TicketMainQuestionRepository.FindTicketMainQuestionAsync(input.MainQuestionId);
            if (existingTicketMainQuestion == null)
            {
                throw new KeyNotFoundException($"Ticket Main Question with {input.MainQuestionId} Not Exist.");
            }
            _mapper.Map(input, existingTicket);
            existingTicket.UpdatorId = input.UpdatorId;
            existingTicket.ModificationTime = input.ModificationTime;
            _unitOfWork.TicketSubQuestionRepository.UpdateTicketSubQuestion(existingTicket);

            await _unitOfWork.CompleteAsync();
        }
    }
}
