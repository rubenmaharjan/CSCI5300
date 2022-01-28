using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrchestraLib;

namespace Assignment01Testing
{
    [TestClass]
    public class AnOrchestraRepository
    {
        [TestMethod]
        public void CanReadAllOrchestrasFromTheDatabase()
        {
            IOrchestraRepository sut = new SqlOrchestraRepository();
            var result = sut.ReadAll();
            Assert.IsTrue(result.Count > 0, "We're not getting results");
        }
    }
}
