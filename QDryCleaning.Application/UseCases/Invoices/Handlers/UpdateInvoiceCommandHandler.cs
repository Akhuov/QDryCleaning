﻿using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QDryClean.Application.Absreactions;
using QDryClean.Application.Common.Interfaces.Services;
using QDryClean.Application.Dtos;
using QDryClean.Application.Exceptions;
using QDryClean.Application.UseCases.Invoices.Commands;

namespace QDryClean.Application.UseCases.Invoices.Handlers
{
    public class UpdateInvoiceCommandHandler : CommandHandlerBase, IRequestHandler<UpdateInvoiceCommand, InvoiceDto>
    {
        public UpdateInvoiceCommandHandler(
           IApplicationDbContext applicationDbContext,
           ICurrentUserService currentUserService,
           IMapper mapper) : base(applicationDbContext, currentUserService, mapper) { }

        public async Task<InvoiceDto> Handle(UpdateInvoiceCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var invoice = await _applicationDbContext.OrderInvoices.FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);
                if (invoice is not null)
                {
                    invoice.TotalCost = request.TotalCost;
                    invoice.PaymentStatus = request.PaymentStatus;
                    invoice.Notes = request.Notes;
                    invoice.Discount = request.Discount;
                    invoice.OrderId = request.OrderId;

                    _applicationDbContext.OrderInvoices.Update(invoice);
                    await _applicationDbContext.SaveChangesAsync(cancellationToken);
                    return _mapper.Map<InvoiceDto>(invoice);
                }
                throw new BadRequestExeption($"Invoice with ID {request.Id} not found.");
            }
            catch (Exception ex)
            {
                throw new InternalServerExeption(ex.Message);
            }
        }
    }
}
