Base framework for creating Repository pattern and Unit of work - V1.0

============================
Assemblies:

	RepositoryPattern.UnitOfWork.Base

External Dependencies:

	EntityFramework >= 5.0.0

=============================
Usage:

Example of creating Repository over classes in Unit of work implementation. 

Step 1. Create a class e.g. UnitOfWork. Derive it from base class UnitOfWorkBase<Your EF context>. 

Step 2. Add your repository classes in UnitOfWork class definition as properties.

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
                return departmentRepository;
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


Note: In above sample CourseRespository is another class dervied from RepositoryBase class to add extra functionality. 
***********************************************************************************************************
Here's the sample definition of extended repository for course entity:

 public class CourseRepository : RepositoryBase<Course>
    {
        public CourseRepository(SchoolContext context)
            : base(context)
        {
        }

        public int UpdateCourseCredits(int multiplier)
        {
            return context.Database.ExecuteSqlCommand("UPDATE Course SET Credits = Credits * {0}", multiplier);
        }
    }


*****************************
Extending the framework-

The framework is extensible by deriving from the base classes and adding/overriding the defautl functions. 


*****************************
Open Items:

1. Create attribute class to mark models which needs to be included in the Unit of work as repository.
2. Create T4 template to generated the UnitOfWork class. The class will be responsible for finding all the attributed classes
	of Models and adding them as Properties in the generated UnitOfWork class. 
