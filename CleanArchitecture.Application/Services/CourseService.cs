using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Models;
using CleanArchitecture.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository repository;

        public CourseService(ICourseRepository repository)
        {
            this.repository = repository;
        }
        public CourseModel GetCourses()
        {
            return new CourseModel { Courses = repository.GetCourses() };
        }
    }
}
