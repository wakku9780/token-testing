using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using WebApplication8.Controllers;

namespace WebApplication8.Controllers.Tests
{
    [TestClass()]
    public class StudentsControllerTests
    {
        private StudentsController _controller;

        [TestInitialize]
        public void Setup()
        {
            _controller = new StudentsController();
        }

        [TestMethod()]
        public void GetAllStudents_Returns_OkResult_With_All_Students()
        {
            // Arrange
            var expectedStudents = new List<Student>
            {
                new Student { Id = 1, Name = "John Doe", Email = "john@example.com" },
                new Student { Id = 2, Name = "Jane Smith", Email = "jane@example.com" }
            };
            _controller = new StudentsController();
            foreach (var student in expectedStudents)
            {
                _controller.CreateStudent(student);
            }

            // Act
            var result = _controller.GetAllStudents();

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
            var okResult = (OkObjectResult)result.Result;
            var students = (IEnumerable<Student>)okResult.Value;
            CollectionAssert.AreEquivalent(expectedStudents, students.ToList());
        }

        [TestMethod()]
        public void GetStudentById_Returns_OkResult_With_Correct_Student()
        {
            // Arrange
            var studentId = 1;
            var expectedStudent = new Student { Id = studentId, Name = "John Doe", Email = "john@example.com" };
            _controller.CreateStudent(expectedStudent);

            // Act
            var result = _controller.GetStudentById(studentId);

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
            var okResult = (OkObjectResult)result.Result;
            var student = (Student)okResult.Value;

            if (!expectedStudent.Equals(student))
            {
                Console.WriteLine($"Expected Student: {expectedStudent}");
                Console.WriteLine($"Actual Student: {student}");
            }

            Assert.AreEqual(expectedStudent, student);
        }

        // Add other test methods for other actions
    }
}
