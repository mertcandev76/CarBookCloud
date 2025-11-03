using CarBookCloud.Application.Extensions;
using CarBookCloud.Contracts.Commands;
using CarBookCloud.Contracts.DTOs;
using CarBookCloud.Contracts.UnitOfWork;
using CarBookCloud.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Application.Handlers.Commands
{
    public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, ContactResultDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateContactCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<ContactResultDto> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            var contact = Domain.Entities.Contact.Create(
                request.Dto.Name,
                request.Dto.Email,
                request.Dto.Subcect,
                request.Dto.Message
            );

            await _unitOfWork.Contacts.AddAsync(contact);
            await _unitOfWork.SaveEntitiesAsync();

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

    public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand, ContactResultDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateContactCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<ContactResultDto> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            var contact = await _unitOfWork.Contacts.GetByIdAsync(request.Dto.ContactID);
            if (contact == null)
                throw new NotFoundException(nameof(Domain.Entities.Contact), request.Dto.ContactID);

            contact.Update(
                request.Dto.Name,
                request.Dto.Email,
                request.Dto.Subcect,
                request.Dto.Message
            );

            await _unitOfWork.Contacts.UpdateAsync(contact);
            await _unitOfWork.SaveEntitiesAsync();

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

    public class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteContactCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<Unit> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            var contact = await _unitOfWork.Contacts.GetByIdAsync(request.ContactID);
            if (contact == null)
                throw new NotFoundException(nameof(Domain.Entities.Contact), request.ContactID);

            await _unitOfWork.Contacts.DeleteAsync(contact);
            await _unitOfWork.SaveEntitiesAsync();

            return Unit.Value;
        }
    }
}
