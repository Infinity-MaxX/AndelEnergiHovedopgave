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
            ICustomerEventService ce = new CustomerEventService(Secret.TestConnectionString);

            CustomerEvent customerEvent = ce.GetById(1);
            List<DataQualityError> allDataQualityErrors = _service.GetAll();
            DataQualityError _dataQualityError = new DataQualityError(DateTime.Today, customerEvent.Id, 1, "RuntimeError");

            // Act
            // Du 'opsamler' objektet som er oprettet, med det autogenererede Id
            // needs to be attached to a variable for proper cleanup
            DataQualityError insertedError = _service.Insert(_dataQualityError);
            int countBefore = allDataQualityErrors.Count();

            DataQualityError findId = _service.GetById(insertedError.Id);
            _service.Delete(insertedError.Id);
            int countAfter = _service.GetAll().Count();

            // Assert
            //Assert.AreEqual(countAfter, countBefore);
            Assert.IsNull(findId);
        }

        [TestMethod]
        public void TestGetAllIsNotEmpty()
        {
            // Arrange
            IDataQualityErrorService _service = new DataQualityErrorService(Secret.TestConnectionString);
            List<DataQualityError> _allDataQualityErrors = _service.GetAll();

            // Act
            DataQualityError _error = new DataQualityError(DateTime.Today, 1, 1, "RuntimeError");
            // needs to be attached to a variable for proper cleanup
            DataQualityError insertedError = _service.Insert(_error);

            // Assert
            Assert.IsNotEmpty(_allDataQualityErrors);

            // Clean
            _service.Delete(insertedError.Id);
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
            DataQualityError _dateOne = new DataQualityError(new DateTime(2023, 1, 1), 2, 1, "RuntimeError");
            DataQualityError _dateTwo = new DataQualityError(new DateTime(2023, 1, 2), 3, 1, "RuntimeError");
            DataQualityError _dateThree = new DataQualityError(new DateTime(2023, 1, 1), 4, 1, "RuntimeError");

            // Act
            // needs to be attached to a variable for proper cleanup
            DataQualityError insertedErrorOne = _service.Insert(_dateOne);
            DataQualityError insertedErrorTwo = _service.Insert(_dateTwo);
            DataQualityError insertedErrorThree = _service.Insert(_dateThree);

            List<DataQualityError> _foundByDate = _service.GetByDate(new DateTime(2023, 1, 1));
            List<DataQualityError> _allDates = _service.GetAll();
            List<DataQualityError> _filtered = _allDates.Where(d => d.RegistrationDate == new DateTime(2023, 1, 1)).ToList();

            // Clean
            _service.Delete(insertedErrorOne.Id);
            _service.Delete(insertedErrorTwo.Id);
            _service.Delete(insertedErrorThree.Id);

            // Assert
            Assert.AreEqual(_foundByDate[0].RegistrationDate, _filtered[0].RegistrationDate);
            Assert.AreEqual(_foundByDate[1].RegistrationDate, _filtered[1].RegistrationDate);
        }

        [TestMethod]
        public void TestGetById()
        {
            // Arrange
            IDataQualityErrorService _service = new DataQualityErrorService(Secret.TestConnectionString);
            DataQualityError _errorOne = new DataQualityError(DateTime.Today, 2, 1, "RuntimeError");
            DataQualityError _errorTwo = new DataQualityError(DateTime.Today, 3, 1, "RuntimeError");

            // Act
            // needs to be attached to a variable for proper cleanup
            DataQualityError insertedErrorOne = _service.Insert(_errorOne);
            DataQualityError insertedErrorTwo = _service.Insert(_errorTwo);
            DataQualityError _foundById = _service.GetById(1);

            // Assert
            Assert.AreEqual(_errorOne.Id, _foundById.Id);

            // Clean
            _service.Delete(insertedErrorOne.Id);
            _service.Delete(insertedErrorTwo.Id);
        }

        [TestMethod]
        public void TestGetByType()
        {
            // Arrange
            IDataQualityErrorService _service = new DataQualityErrorService(Secret.TestConnectionString);
            DataQualityError _typeOne = new DataQualityError(DateTime.Today, 2, 1, "IndexOutOfRangeError");
            DataQualityError _typeTwo = new DataQualityError(DateTime.Today, 3, 1, "SyntaxError");
            DataQualityError _typeThree = new DataQualityError(DateTime.Today, 4, 1, "IndexOutOfRangeError");

            // Act
            // needs to be attached to a variable for proper cleanup
            DataQualityError insertedErrorOne = _service.Insert(_typeOne);
            DataQualityError insertedErrorTwo = _service.Insert(_typeTwo);
            DataQualityError insertedErrorThree = _service.Insert(_typeThree);

            List<DataQualityError> _foundByType = _service.GetByType("IndexOutOfRangeError");
            List<DataQualityError> _allTypes = _service.GetAll();
            List<DataQualityError> _filtered = _allTypes.Where(t => t.ErrorType == "IndexOutOfRangeError").ToList();

            // Clean
            _service.Delete(insertedErrorOne.Id);
            _service.Delete(insertedErrorTwo.Id);
            _service.Delete(insertedErrorTwo.Id);

            // Assert
            Assert.AreEqual(_foundByType[0].ErrorType, _filtered[0].ErrorType);
            Assert.AreEqual(_foundByType[1].ErrorType, _filtered[1].ErrorType);
        }

        [TestMethod]
        public void TestInsert()
        {
            // Arrange
            IDataQualityErrorService _service = new DataQualityErrorService(Secret.TestConnectionString);
            DataQualityError _error = new DataQualityError(DateTime.Today, 2, 1, "RuntimeError");

            // Act
            // needs to be attached to a variable for proper cleanup
            DataQualityError insertedError = _service.Insert(_error);

            // Assert
            Assert.IsNotNull(_service.GetById(_error.Id));

            // Clean
            _service.Delete(insertedError.Id);
        }
    }
}