using AutoMapper;
using CrudMec.Application.Interfaces;
using CrudMec.Domain.Entities;
using CrudMec.Domain.Interfaces;

namespace CrudMec.Application.Services
{
    public class MatterService : IMatterService
    {
        
        private readonly IMatterRepository _matterRepository;
        public MatterService(IMatterRepository matterRepository) 
        {
            _matterRepository = matterRepository;
        }

        public async Task Add(Matter entity)
        {
            var countMatterTeacher = await _matterRepository.CountMatterByTeacher(entity.TeacherId);
            if (countMatterTeacher >= 2)
            {
                throw new InvalidOperationException($"El profesor con ID {entity.TeacherId} no puede dictar más de 2 materias.");
            }
            await _matterRepository.AddAsync(entity);
        }


        public async Task Delete(int id)
        {
            var deleteMatter = await _matterRepository.UpdateMatterById(id);
            if (deleteMatter == null) throw new EntityNotFoundException(id);
            await _matterRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Matter>> GetAll()
        {
            return await _matterRepository.GetAllAsync();
        }

        public async Task<Matter> GetById(int id)
        {
            var matterByid = await _matterRepository.GetByIdAsync(id);
            if (matterByid == null) throw new EntityNotFoundException(id);

            return matterByid;
        }

        public async Task Update(Matter entity)
        {
            var existingMatter = await _matterRepository.UpdateMatterById(entity.MateriaId);
            if (existingMatter == null) throw new EntityNotFoundException(entity.MateriaId);

            await _matterRepository.UpdateAsync(entity);
        }

        public async Task<List<Student>> GetStudentsByMatters(List<int> matterIds)
        {
            return await _matterRepository.GetStudentsByMatters(matterIds);
             
        }
    }
}
