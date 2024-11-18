using CrudMec.Domain.Entities;
using CrudMec.Domain.Interfaces;
using CrudMec.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CrudMec.Infrastructure.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly AppDbContext _appDbContext;
        public TeacherRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task AddAsync(Teacher entity)
        {
            await _appDbContext.AddAsync(entity);
            await _appDbContext.SaveChangesAsync();
        }

        
        public async Task<List<Teacher>> GetAllAsync()
        {
            var teacherAll = await _appDbContext.Teachers.ToListAsync();
            return teacherAll;
        }

        public async Task<Teacher> GetByIdAsync(int id)
        {
            var teacher = await _appDbContext.Teachers.FirstOrDefaultAsync(s => s.Id == id);
            if (teacher == null) throw new EntityNotFoundException(id);
            return teacher;
        }

        public async Task UpdateAsync(Teacher entity)
        {
            _appDbContext.Teachers.Update(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var teacher = await GetByIdAsync(id);
            if (teacher == null) throw new EntityNotFoundException(id);

            _appDbContext.Teachers.Remove(teacher);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
