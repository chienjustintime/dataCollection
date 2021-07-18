using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace SP.Application.CQRS.Commands
{
    public class DeleteStudentByIdCommand: IRequest<Guid>
    {
         public Guid Id { get; set; }
       
    }

    public class DeleteStudentByIdCommandHandler : IRequestHandler<DeleteStudentByIdCommand, Guid>
    {
        private readonly IAppDbContext context;
        public DeleteStudentByIdCommandHandler(IAppDbContext context)
        {
            this.context = context;
        }
        public async Task<Guid> Handle(DeleteStudentByIdCommand command, CancellationToken cancellationToken)
        {
            var student = await context.Students.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
            if (student == null) return default;
            context.Students.Remove(student);
            await context.SaveChangesAsync();
            return student.Id;
        }
    }
}