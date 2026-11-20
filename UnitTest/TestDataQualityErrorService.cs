namespace UnitTest
{
    using AndelEnergiHovedopgave.Interfaces;
    using AndelEnergiHovedopgave.Models;
    using AndelEnergiHovedopgave.Services;
    using Microsoft.AspNetCore.Authentication.OAuth.Claims;

    [TestClass]
    public sealed class TestDataQualityErrorService
    {
        [TestMethod]
        public void TestDelete()
        {
            // Arrange
            IDataQualityErrorService _service = new DataQualityErrorService();
            List<DataQualityError> _allDataQualityErrors = _service.GetAll();
            DataQualityError _dataQualityError = new DataQualityError(1, DateTime.Today, 2, 1, "RuntimeError");

            // Act
            _service.Insert(_dataQualityError);
            int countBeforeDelete = _service.GetAll().Count;

            DataQualityError findId = _service.GetById(_dataQualityError.Id);
            _service.Delete(findId.Id);
            int countAfterDelete = _service.GetAll().Count;

            // Assert
            Assert.AreEqual(countBeforeDelete - 1, countAfterDelete);
        }

        [TestMethod]
        public void TestGetAllIsNotEmpty()
        {
            // Arrange
            IDataQualityErrorService _service = new DataQualityErrorService();
            List<DataQualityError> _allDataQualityErrors = _service.GetAll();

            // Act
            DataQualityError _error = new DataQualityError(1, DateTime.Today, 2, 1, "RuntimeError");
            _allDataQualityErrors.Add(_error);

            // Assert
            Assert.IsNotEmpty(_allDataQualityErrors);

            // Clean
            _allDataQualityErrors.Remove(_error);
        }

        [TestMethod]
        public void TestGetAllIsNotNull()
        {
            // Arrange
            IDataQualityErrorService _service = new DataQualityErrorService();
            List<DataQualityError> _allDataQualityErrors = _service.GetAll();

            // Assert
            Assert.IsNotNull(_allDataQualityErrors);
        }

        [TestMethod]
        public void TestGetByDate()
        {
            // Arrange
            IDataQualityErrorService _service = new DataQualityErrorService();
            List<DataQualityError> _allDates = _service.GetAll();
            DataQualityError _dateOne = new DataQualityError(1, new DateTime(2023, 1, 1), 2, 1, "RuntimeError");
            DataQualityError _dateTwo = new DataQualityError(2, new DateTime(2023, 1, 2), 3, 1, "RuntimeError");
            DataQualityError _dateThree = new DataQualityError(3, new DateTime(2023, 1, 1), 4, 1, "RuntimeError");
            
            // Clean
            _service.Delete(_dateOne.Id);
            _service.Delete(_dateTwo.Id);
            _service.Delete(_dateThree.Id);

            // Act
            _service.Insert(_dateOne);
            _service.Insert(_dateTwo);
            _service.Insert(_dateThree);

            List<DataQualityError> _foundByDate = _service.GetByDate(new DateTime(2023, 1, 1));
            List<DataQualityError> _filtered = _allDates.Where(d => d.RegistrationDate == new DateTime(2023, 1, 1)).ToList();

            // Assert
            Assert.AreEqual(_foundByDate[0].RegistrationDate, _filtered[0].RegistrationDate);
            Assert.AreEqual(_foundByDate[1].RegistrationDate, _filtered[1].RegistrationDate);
        }

        [TestMethod]
        public void TestGetById()
        {
            // Arrange


            // Act


            // Assert

        }

        [TestMethod]
        public void TestGetByType()
        {
            // Arrange


            // Act


            // Assert

        }

        [TestMethod]
        public void TestInsert()
        {
            // Arrange


            // Act


            // Assert

        }
    }
}