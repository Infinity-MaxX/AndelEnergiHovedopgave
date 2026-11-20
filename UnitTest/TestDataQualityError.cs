using AndelEnergiHovedopgave.Models;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.ConstrainedExecution;

namespace UnitTest;

[TestClass]
public sealed class TestDataQualityError
{
    [TestMethod]
    public void TestDateTimeArgumentException()
    {
        // Arrange
        DateTime date = new DateTime(2023, 1, 1); // Set a specific date for testing
        DataQualityError dataQualityError = new DataQualityError(1, date, 12, 1, "RuntimeError");

        // Assert
        Assert.ThrowsExactly<ArgumentException>(() => dataQualityError.RegistrationDate = date);
    }
}
