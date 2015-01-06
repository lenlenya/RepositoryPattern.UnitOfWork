using System;
using System.Data.Entity;

using ContosoUniversity.Models;

using RepositoryPattern.UnitOfWork.Base;

namespace ContosoUniversity.DAL
{
    public class UnitOfWork : UnitOfWorkBase<SchoolContext>, IDisposable
    {
        private IRepositoryBase<Department> departmentRepository;
        private CourseRepository courseRepository;

        public IRepositoryBase<Department> DepartmentRepository
        {
            get
            {
                if (this.departmentRepository == null)
                {
                    this.departmentRepository = new RepositoryBase<Department>(context);
                }

                return this.departmentRepository;
            }
        }
        
        public CourseRepository CourseRepository
        {
            get
            {
                if (this.courseRepository == null)
                {
                    this.courseRepository = new CourseRepository(context);
                }

                return courseRepository;
            }
        }
    }
}
