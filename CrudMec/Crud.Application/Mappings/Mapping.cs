    using AutoMapper;
using CrudMec.Application.Dtos;
using CrudMec.Domain.Entities;

namespace CrudMec.Application.Mappings;

public class Mapping : Profile
{
    public Mapping()
    {
        CreateMap<Student, StudentDto>().ReverseMap();
        CreateMap<Teacher, TeacherDto>().ReverseMap();
        CreateMap<Registration, ResgistrationDto>().ReverseMap();
        CreateMap<Matter, MatterDto>().ReverseMap();
       
    }
}
