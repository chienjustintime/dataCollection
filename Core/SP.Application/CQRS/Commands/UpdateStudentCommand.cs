using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SP.Domain.Entity;

namespace SP.Application.CQRS.Commands
{
    public class UpdateStudentCommand : IRequest<Student>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Standard { get; set; }
    }

    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, Student>
    {
        private readonly IAppDbContext context;
        public UpdateStudentCommandHandler(IAppDbContext context)
        {
            this.context = context;
        }
        public async Task<Student> Handle(UpdateStudentCommand command, CancellationToken cancellationToken)
        {
            var student = context.Students.Where(a => a.Id == command.Id).FirstOrDefault();

            if (student == null)
                return default;

            student.Name = command.Name;
            student.Standard = command.Standard;
        
            await context.SaveChangesAsync();
            return student;
        }
    }
    
}