using CrudMec.Domain.Entities;
using CrudMec.Domain.Interfaces;
using CrudMec.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
namespace CrudMec.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _appDbContext;
        public StudentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task AddAsync(Student entity)
        {
          await _appDbContext.AddAsync(entity);
          await _appDbContext.SaveChangesAsync();
        }

        public async Task<List<Student>> GetAllAsync()
        {
            var studentsAll = await _appDbContext.Students.Include(s => s.Matters).ToListAsync();
            return studentsAll;
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            var student = await _appDbContext.Students.FirstOrDefaultAsync(s => s.Id == id);
            if (student == null) throw new EntityNotFoundException(id);
            return student;
        }

        public async Task UpdateAsync(Student entity)
        {
            _appDbContext.Students.Update(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var student = await _appDbContext.Students.FindAsync(id);
            if (student == null) throw new EntityNotFoundException(id);

            _appDbContext.Students.Remove(student);
            await _appDbContext.SaveChangesAsync();

        }

        public async Task<Student> getStudentById(int studentId)
        {
            return await _appDbContext.Students.Include(e => e.Matters)
                                         .ThenInclude(m => m.Teacher)
                                         .FirstOrDefaultAsync(e => e.Id == studentId);
        }
    }
}
