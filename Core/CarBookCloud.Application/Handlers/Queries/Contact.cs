using CarBookCloud.Contracts.DTOs;
using CarBookCloud.Contracts.Queries;
using CarBookCloud.Contracts.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Application.Handlers.Queries
{
    public class GetContactByIdQueryHandler : IRequestHandler<GetContactByIdQuery, ContactResultDto?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetContactByIdQueryHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<ContactResultDto?> Handle(GetContactByIdQuery request, CancellationToken cancellationToken)
        {
            var contact = await _unitOfWork.Contacts.GetByIdAsync(request.ContactID);
            if (contact == null) return null;

            return new ContactResultDto
            {
                ContactID = contact.ContactID,
                Name = contact.Name,
                Email = contact.Email,
                Subcect = contact.Subject,
                Message = contact.Message,
                SendDate = contact.SendDate
            };
        }
    }

    public class GetAllContactsQueryHandler : IRequestHandler<GetAllContactsQuery, List<ContactResultDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllContactsQueryHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<List<ContactResultDto>> Handle(GetAllContactsQuery request, CancellationToken cancellationToken)
        {
            var contacts = await _unitOfWork.Contacts.GetAllAsync();
            return contacts.Select(c => new ContactResultDto
            {
                ContactID = c.ContactID,
                Name = c.Name,
                Email = c.Email,
                Subcect = c.Subject,
                Message = c.Message,
                SendDate = c.SendDate
            }).ToList();
        }
    }
}
