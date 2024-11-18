using CrudMec.Application.Interfaces;
using CrudMec.Domain.Entities;
using CrudMec.Domain.Interfaces;

namespace CrudMec.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMatterRepository _matterRepository;
        public StudentService(IStudentRepository studentRepository, IMatterRepository matterRepository)
        {
            _studentRepository = studentRepository;
            _matterRepository = matterRepository;
        }

        public async Task<IEnumerable<Student>> GetAll()
        {
            return await _studentRepository.GetAllAsync();

        }

        public async Task<Student> GetById(int id)
        {
            var studentByid = await _studentRepository.GetByIdAsync(id);
            if (studentByid == null) throw new EntityNotFoundException(id);

            return studentByid;

        }
        public async Task Add(Student entity)
        {
            if (entity.Matters.Count > 3)
            {
                throw new InvalidOperationException("Un estudiante no puede tener más de 3 materias.");
            }

            var profesores = entity.Matters.Select(m => m.TeacherId).Distinct();
            if (profesores.Count() != entity.Matters.Count)
            {
                throw new InvalidOperationException("El estudiante no puede seleccionar materias con el mismo profesor en más de ua materia.");
            }

            foreach (var matter in entity.Matters)
            {
                var profesorMaterias = await _matterRepository.CountMatterByTeacher(matter.TeacherId); 
                   
                if (profesorMaterias > 2)
                {
                    throw new InvalidOperationException($"El profesor con ID {matter.TeacherId} no puede dictar más de 2 materias.");
                }
            }
            await _studentRepository.AddAsync(entity);

        }
        public async Task Update(Student entity)
        {
            var updateStudent = _studentRepository.getStudentById(entity.Id);

            if (updateStudent == null) throw new EntityNotFoundException(entity.Id);

            await _studentRepository.UpdateAsync(entity);
        }
        public async Task Delete(int id)
        {
            var deleteStudent = await _studentRepository.getStudentById(id);
            if (deleteStudent == null) throw new EntityNotFoundException(id);
            await _studentRepository.DeleteAsync(id);
        }

    }
}
