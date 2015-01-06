using System;
using ContosoUniversity.Models;

using RepositoryPattern.UnitOfWork.Base;

namespace ContosoUniversity.DAL
{
    public class CourseRepository : RepositoryBase<Course>
    {
        public CourseRepository(SchoolContext context)
            : base(context)
        {
        }

        public int UpdateCourseCredits(int multiplier)
        {
            return this.Context.Database.ExecuteSqlCommand("UPDATE Course SET Credits = Credits * {0}", multiplier);
        }
    }
}
