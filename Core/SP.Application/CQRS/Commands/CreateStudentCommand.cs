using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SP.Domain.Entity;

namespace SP.Application.CQRS.Commands
{
    public class CreateStudentCommand : IRequest<Student>
    {
        public string Name { get; set; }
        public string Standard{ get; set;}


    }

    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, Student>
    {
        private readonly IAppDbContext context;
        public CreateStudentCommandHandler(IAppDbContext context){
            this.context =context;
        }

        public async Task<Student> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = new Student();
            student.Name = request.Name;
            student.Standard=request.Standard;
            
            context.Students.Add(student);
            await context.SaveChangesAsync();
            return student;
        }
    }

}