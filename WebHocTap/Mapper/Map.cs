using AutoMapper;
using WebHocTap.DTO;
using WebHocTap.Entity;
namespace WebHocTap.Mapper
    {
        public class Map : Profile
        {
            public Map()
            {
                this.CreateMap<AdminDTO, Admin>();
                this.CreateMap<Admin, AdminDTO>();
                this.CreateMap<CourseDTO, Course>();
                this.CreateMap<Course, CourseDTO>();
                this.CreateMap<DocumentDTO, Document>();
                this.CreateMap<Document, DocumentDTO>();
                this.CreateMap<AdminAccountDTO, AdminAccount>();
                this.CreateMap<AdminAccount, AdminAccountDTO>();
                this.CreateMap<ClassDTO, Class>();
                this.CreateMap<Class, ClassDTO>();
                this.CreateMap<GradeDTO, Grade>();
                this.CreateMap<Grade, GradeDTO>();
                this.CreateMap<Class_CourseDTO, Class_Course>();
                this.CreateMap<Class_Course, Class_CourseDTO>();
                this.CreateMap<PositionDTO, Position>();
                this.CreateMap<Position, PositionDTO>();
                this.CreateMap<StudentDTO, Student>();
                this.CreateMap<Student, StudentDTO>();
                this.CreateMap<StudentAccountDTO, StudentAccount>();
                this.CreateMap<StudentAccount, StudentAccountDTO>();
                this.CreateMap<TestCateDTO, TestCategory>();
                this.CreateMap<TestCategory, TestCateDTO>();
                this.CreateMap<TestDTO, Test>();
                this.CreateMap<Test, TestDTO>();
                this.CreateMap<ClassTestDTO, Class_Test>();
                this.CreateMap<Class_Test, ClassTestDTO>();
                this.CreateMap<SubjectDTO, Subject>();
                this.CreateMap<Subject, SubjectDTO>();
                this.CreateMap<StudentTestDTO, Student_Test>();
                this.CreateMap<Student_Test, StudentTestDTO>();
                this.CreateMap<LearningOutcomeDTO, LearningOutcome>();
                this.CreateMap<LearningOutcome, LearningOutcomeDTO>();
            }

        }
    }

