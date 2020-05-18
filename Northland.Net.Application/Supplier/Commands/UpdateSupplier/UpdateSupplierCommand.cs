using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Northland.Net.Application.Common.Exceptions;
using Northland.Net.Application.Common.Interfaces;
using Northland.Net.Domain;

namespace Northland.Net.Application.Supplier.Commands.UpdateSupplier
{
    public class UpdateSupplierCommand : IRequest
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Phone { get; set; }
        public Status Status { get; set; }

        public class UpdateSupplierCommandHandler : IRequestHandler<UpdateSupplierCommand>
        {
            private readonly INorthlandDbContext _context;
            public UpdateSupplierCommandHandler(INorthlandDbContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(UpdateSupplierCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Suppliers.FindAsync(request.Id);
                if (entity == null) throw new NotFoundException(nameof(Supplier), request.Id);

                entity.CompanyName = request.CompanyName;
                entity.ContactName= request.ContactName;
                entity.ContactTitle= request.ContactTitle;
                entity.Phone = request.Phone;
                entity.LastModified = DateTime.Now;
                entity.Status = request.Status;
                await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}