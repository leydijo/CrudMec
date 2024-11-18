using CrudMec.Domain.Entities;
using CrudMec.Domain.Interfaces;
using CrudMec.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Drawing2D;

namespace CrudMec.Infrastructure.Repositories;

public class MatterRepository : IMatterRepository
{
    private readonly AppDbContext _appDbContext;

    public MatterRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    public async Task AddAsync(Matter entity)
    {
        await _appDbContext.AddAsync(entity);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var matter = await _appDbContext.Matters.FindAsync(id);
        if (matter == null) throw new EntityNotFoundException(id);

        _appDbContext.Matters.Remove(matter);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task<List<Matter>> GetAllAsync()
    {
        return await _appDbContext.Matters
             .Select(m => new Matter
             {
                 MateriaId = m.MateriaId,
                 Name = m.Name
             })
             .ToListAsync();
    }

    public async Task<Matter> GetByIdAsync(int id)
    {
        var matterAll = await _appDbContext.Matters.Include(m => m.Teacher).FirstOrDefaultAsync(m => m.MateriaId == id);
        if (matterAll == null) throw new EntityNotFoundException(id);
        return matterAll;
    }

    public async Task UpdateAsync(Matter entity)
    {
        _appDbContext.Matters.Update(entity);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task<int> CountMatterByTeacher(int teacherId)
    {
        return await _appDbContext.Matters.CountAsync(m => m.TeacherId == teacherId);
    }

    public async Task<Matter> UpdateMatterById(int matterId)
    {
        return await _appDbContext.Matters.Include(m => m.Teacher).FirstOrDefaultAsync(m => m.MateriaId == matterId);
    }

    public async Task<List<Student>> GetStudentsByMatters(List<int> matterIds)
    {
        var matter = await _appDbContext.Students.Where(e => e.Matters.All(m =>matterIds.Contains(m.MateriaId))).ToListAsync(); 
        return matter;
    }
}
