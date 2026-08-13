using NUnit.Framework;
using CollectionsLib;
using System.Collections.Generic;
using System.Linq;

namespace CollectionsLib.Tests
{
    public class Tests
    {
        private EmployeeManager manager;

        [SetUp]
        public void Setup()
        {
            manager = new EmployeeManager();
        }

        [Test]
        public void GetEmployees_ShouldNotContainNull()
        {
            List<Employee> employees = manager.GetEmployees();

            CollectionAssert.AllItemsAreNotNull(employees);
        }

        [Test]
        public void GetEmployees_ShouldContainEmployeeWithId100()
        {
            List<Employee> employees = manager.GetEmployees();

            Assert.That(employees.Any(e => e.EmpId == 100), Is.True);
        }

        [Test]
        public void GetEmployees_AllEmployeeIdsShouldBeUnique()
        {
            List<Employee> employees = manager.GetEmployees();

            CollectionAssert.AllItemsAreUnique(employees.Select(e => e.EmpId));
        }

        [Test]
        public void GetEmployeesWhoJoinedInPreviousYears_ShouldReturnExpectedEmployees()
        {
            List<Employee> expected = manager.GetEmployees()
                                            .Where(e => e.DOJ < System.DateTime.Now)
                                            .ToList();

            List<Employee> actual = manager.GetEmployeesWhoJoinedInPreviousYears();

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
