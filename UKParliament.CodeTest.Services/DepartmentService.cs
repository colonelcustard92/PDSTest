

using UKParliament.CodeTest.Data;

namespace UKParliament.CodeTest.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly PersonManagerContext _context;
        public DepartmentService(PersonManagerContext context)
        {
            _context = context;
        }
        public List<Department> GetAllDepartments()
        {
            return _context.Departments.ToList();            
        }
    }
}
