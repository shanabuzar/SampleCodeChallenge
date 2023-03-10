using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Sample.Domains.Entities;
using Sample.Repositories;
using Sample.Utilities.Enums;

namespace Tests.Unit.Sample.Repositories
{
    [TestClass]
    public class EmployeeRepositoryTest
    {
        [TestMethod]
        public void EmployerDelete_Test()
        {
            //Arrange
            var employees = new List<Employee>
            {
                new Employee {
                    FirstName = "John",
                    LastName = "John",
                    Age = 25,
                    Gender = Gender.Male,
                },
                new Employee {
                    FirstName = "Smith",
                    LastName = "Smith",
                    Age = 25,
                    Gender = Gender.Male,
                }

            };

            var mockDbSet = new Mock<DbSet<Employee>>();
            var context = new Mock<SampleDbContext>();

            mockDbSet.As<IQueryable<Employee>>()
                     .Setup(x => x.Provider)
                     .Returns(employees.AsQueryable().Provider);
            mockDbSet.As<IQueryable<Employee>>()
                     .Setup(x => x.ElementType)
                     .Returns(employees.AsQueryable().ElementType);
            mockDbSet.As<IQueryable<Employee>>()
                     .Setup(x => x.Expression)
                     .Returns(employees.AsQueryable().Expression);
            mockDbSet.As<IQueryable<Employee>>()
                     .Setup(x => x.GetEnumerator())
                     .Returns(employees.GetEnumerator());

            context.Setup(x => x.employees).Returns(mockDbSet.Object);
            //Act
            var result = new EmployeeRepository(context.Object).Delete(employees[0].Id).Result;

            // Assert            
            Assert.AreEqual(result, true);
            Assert.AreNotEqual(employees[0].DeletedDate, null);
        }
    }
}
