using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Sample.Repositories.DTO;
using Sample.Repositories.Interfaces;
using Sample.Services;
using Sample.Utilities.Enums;

namespace Tests.Unit.Sample.Services
{
    [TestClass]
    public class EmployeeServiceTest
    {
        [TestMethod]
        public void EmployeeService_Save()
        { 
            //Arrange

            var dto = new InsertEmployeeDTO()
            {
                FirstName = "John",
                LastName = "Smith",
                Age = 12,
                gender = Gender.Male
            };

            var dto2 = new UpdateEmployeeDTO()
            {
                Id = Guid.Empty,
                FirstName = "John",
                LastName = "Smith",
                Age = 12,
                gender = Gender.Male
            };

            var dto1 = new UpdateEmployeeDTO()
            {
                Id = Guid.NewGuid(),
                FirstName = "John",
                LastName = "Smith",
                Age = 12,
                gender = Gender.Male
            };

        var mockRepo = new Mock<IEmployeeRepository>();
            mockRepo.Setup(repo => repo.Insert(dto))
                    .Returns(Task.FromResult(Guid.NewGuid()));
            mockRepo.Setup(repo => repo.Update(dto1))
                    .Returns(Task.FromResult(true));
            //Act

            var result = new EmployeeService(mockRepo.Object).Save(dto1).Result;
            var result2 = new EmployeeService(mockRepo.Object).Save(dto2).Result;

            //Assert

            Assert.AreEqual(result, dto1.Id);
            Assert.AreNotEqual(result2, dto2.Id);
        }


        [TestMethod]
        public void EmployeeService_GetAll()
        { 
            //Arrange

            var employees = new List<GetEmployeeDTO>
            {
                new GetEmployeeDTO {
                    Id = Guid.NewGuid(),
                    FirstName = "John",
                    LastName = "John",
                    Age = 25,
                    gender = Gender.Male,
                    FullName = ""
                },
                new GetEmployeeDTO {
                    Id = Guid.NewGuid(),
                    FirstName = "Smith",
                    LastName = "Smith",
                    Age = 25,
                    gender = Gender.Male,
                    FullName = ""
                }

            };


            var mockRepo = new Mock<IEmployeeRepository>();
            mockRepo.Setup(repo => repo.GetAll())
                    .Returns(Task.FromResult(employees));
            //Act

            var result = new EmployeeService(mockRepo.Object).GetAll(string.Empty, string.Empty, null).Result;

            //Assert

            Assert.AreEqual(result.Count, 2);
        }
    }
}
