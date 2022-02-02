using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrchestraLib;

namespace Assignment02Testing
{
    [TestClass]
    public class AnOrchestraRepository
    {
        [TestMethod]
        public void CanFetchOrchestraById()
        {
            IOrchestraRepository sut = new SqlOrchestraRepository();
            Orchestra result = sut.Read(1);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CanHandleNull()
        {
            IOrchestraRepository sut = new SqlOrchestraRepository();
            Orchestra result = sut.Read(0);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void IsAnInstanceOfOrchestra()
        {
            IOrchestraRepository sut = new SqlOrchestraRepository();
        }
    }

}
