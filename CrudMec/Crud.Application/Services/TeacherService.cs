using CrudMec.Application.Interfaces;
using CrudMec.Domain.Entities;
using CrudMec.Domain.Interfaces;

namespace CrudMec.Application.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;
        public TeacherService(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }
        public async Task Add(Teacher entity)
        {
            await _teacherRepository.AddAsync(entity);
        }

        public async Task Delete(int id)
        {
            var deleteTeacher = _teacherRepository.GetByIdAsync(id);
            if (deleteTeacher == null) throw new EntityNotFoundException(id);
            await _teacherRepository.DeleteAsync(id);
        }
     
        public async Task<IEnumerable<Teacher>> GetAll()
        {
            return await _teacherRepository.GetAllAsync();
             
        }

        public async Task<Teacher> GetById(int id)
        {
            var teacherByid = await _teacherRepository.GetByIdAsync(id);
            if (teacherByid == null) throw new EntityNotFoundException(id);

            return teacherByid;
        }

        public async Task Update(Teacher entity)
        {
            var updateTeacher = await _teacherRepository.GetByIdAsync(entity.Id);

            if (updateTeacher == null) throw new EntityNotFoundException(entity.Id);

            await _teacherRepository.UpdateAsync(updateTeacher);
        }
    }
}
