namespace UnitTest
{
    using AndelEnergiHovedopgave;
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
            IDataQualityErrorService _service = new DataQualityErrorService(Secret.TestConnectionString);
            DataQualityError _dataQualityError = new DataQualityError(1, DateTime.Today, 5, 1, "RuntimeError");

            // Act
            _service.Insert(_dataQualityError);
            DataQualityError findId = _service.GetById(_dataQualityError.Id);
            _service.Delete(findId.Id);

            // Assert
            Assert.IsNull(_service.GetById(_dataQualityError.Id));
        }

        [TestMethod]
        public void TestGetAllIsNotEmpty()
        {
            // Arrange
            IDataQualityErrorService _service = new DataQualityErrorService(Secret.TestConnectionString);
            List<DataQualityError> _allDataQualityErrors = _service.GetAll();

            // Act
            DataQualityError _error = new DataQualityError(1, DateTime.Today, 10, 1, "RuntimeError");
            _allDataQualityErrors.Add(_error);
            _service.Insert(_error);

            // Assert
            Assert.IsNotEmpty(_allDataQualityErrors);

            // Clean
            _allDataQualityErrors.Remove(_error);
            _service.Delete(_error.Id);
        }

        [TestMethod]
        public void TestGetAllIsNotNull()
        {
            // Arrange
            IDataQualityErrorService _service = new DataQualityErrorService(Secret.TestConnectionString);
            List<DataQualityError> _allDataQualityErrors = _service.GetAll();

            // Assert
            Assert.IsNotNull(_allDataQualityErrors);
        }

        [TestMethod]
        public void TestGetByDate()
        {
            // Arrange
            IDataQualityErrorService _service = new DataQualityErrorService(Secret.TestConnectionString);
            DataQualityError _dateOne = new DataQualityError(1, new DateTime(2023, 1, 1), 12, 1, "RuntimeError");
            DataQualityError _dateTwo = new DataQualityError(2, new DateTime(2023, 1, 2), 13, 1, "RuntimeError");
            DataQualityError _dateThree = new DataQualityError(3, new DateTime(2023, 1, 1), 14, 1, "RuntimeError");

            // Act
            _service.Insert(_dateOne);
            _service.Insert(_dateTwo);
            _service.Insert(_dateThree);

            List<DataQualityError> _foundByDate = _service.GetByDate(new DateTime(2023, 1, 1));
            List<DataQualityError> _allDates = _service.GetAll();
            List<DataQualityError> _filtered = _allDates.Where(d => d.RegistrationDate == new DateTime(2023, 1, 1)).ToList();

            // Clean
            _service.Delete(_dateOne.Id);
            _service.Delete(_dateTwo.Id);
            _service.Delete(_dateThree.Id);

            // Assert
            Assert.AreEqual(_foundByDate[0].RegistrationDate, _filtered[0].RegistrationDate);
            Assert.AreEqual(_foundByDate[1].RegistrationDate, _filtered[1].RegistrationDate);
        }

        [TestMethod]
        public void TestGetById()
        {
            // Arrange
            IDataQualityErrorService _service = new DataQualityErrorService(Secret.TestConnectionString);
            DataQualityError _errorOne = new DataQualityError(1, DateTime.Today, 12, 1, "RuntimeError");
            DataQualityError _errorTwo = new DataQualityError(2, DateTime.Today, 13, 1, "RuntimeError");

            // Act
            _service.Insert(_errorOne);
            _service.Insert(_errorTwo);
            DataQualityError _foundById = _service.GetById(1);

            // Assert
            Assert.AreEqual(_errorOne.Id, _foundById.Id);

            // Clean
            _service.Delete(_errorOne.Id);
            _service.Delete(_errorTwo.Id);
        }

        [TestMethod]
        public void TestGetByType()
        {
            // Arrange
            IDataQualityErrorService _service = new DataQualityErrorService(Secret.TestConnectionString);
            DataQualityError _typeOne = new DataQualityError(1, DateTime.Today, 12, 1, "IndexOutOfRangeError");
            DataQualityError _typeTwo = new DataQualityError(2, DateTime.Today, 13, 1, "SyntaxError");
            DataQualityError _typeThree = new DataQualityError(3, DateTime.Today, 14, 1, "IndexOutOfRangeError");

            // Act
            _service.Insert(_typeOne);
            _service.Insert(_typeTwo);
            _service.Insert(_typeThree);

            List<DataQualityError> _foundByType = _service.GetByType("IndexOutOfRangeError");
            List<DataQualityError> _allTypes = _service.GetAll();
            List<DataQualityError> _filtered = _allTypes.Where(t => t.ErrorType == "IndexOutOfRangeError").ToList();

            // Clean
            _service.Delete(_typeOne.Id);
            _service.Delete(_typeTwo.Id);
            _service.Delete(_typeThree.Id);

            // Assert
            Assert.AreEqual(_foundByType[0].ErrorType, _filtered[0].ErrorType);
            Assert.AreEqual(_foundByType[1].ErrorType, _filtered[1].ErrorType);
        }

        [TestMethod]
        public void TestInsert()
        {
            // Arrange
            IDataQualityErrorService _service = new DataQualityErrorService(Secret.TestConnectionString);
            DataQualityError _error = new DataQualityError(1, DateTime.Today, 12, 1, "RuntimeError");

            // Act
            _service.Insert(_error);

            // Assert
            Assert.IsNotNull(_service.GetById(1));

            // Clean
            _service.Delete(_error.Id);
        }
    }
}