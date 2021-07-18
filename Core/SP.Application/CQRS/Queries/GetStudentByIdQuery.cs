using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SP.Domain.Entity;

namespace SP.Application.CQRS.Queries
{
    public class GetStudentByIdQuery : IRequest<Student>
    {
        public Guid Id { get; set; }
       
    }

    public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, Student>
    {
        private readonly IAppDbContext context;
        public GetStudentByIdQueryHandler(IAppDbContext context)
        {
            this.context = context;
        }
        public async Task<Student> Handle(GetStudentByIdQuery query, CancellationToken cancellationToken)
        {
            //do repository pattern here?
            var student = await context.Students.Where(a => a.Id == query.Id).FirstOrDefaultAsync();
            if (student == null)
                return null;
            return student;
        }
    }
}