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
        public void CanCreateOrchestra()
        {
            IOrchestraRepository sut = new SqlOrchestraRepository();
            var result = sut.ReadAll();
            Orchestra orchestra = new Orchestra();
            orchestra.Name = "TestTest";
            sut.Create(orchestra);
            var result2 = sut.ReadAll();
            Assert.IsTrue(result.Count < result2.Count, "Count did not increase");
        }

        [TestMethod]
        public void CanUpdateOrchestra()
        {
            IOrchestraRepository sut = new SqlOrchestraRepository();
            Orchestra result = sut.Read(1002);
            Orchestra orchestra = new Orchestra();
            orchestra.Id = result.Id;
            orchestra.Name = "Test" + result.GetHashCode();
            sut.Update(orchestra);
            Orchestra result2 = sut.Read(1002);
            Assert.AreNotEqual(result, result2);
            Assert.AreEqual(orchestra.Name, result2.Name);
        }

        [TestMethod]
        public void CanDeleteOrchestra()
        {
            IOrchestraRepository sut = new SqlOrchestraRepository();
            Orchestra orchestra = new Orchestra();
            orchestra.Name = "DeleteTest";
            int id = sut.CreateAndGetId(orchestra);
            var result = sut.ReadAll();
            sut.Delete(id);
            var result2 = sut.ReadAll();
            Assert.IsTrue(result.Count > result2.Count, "Count did not decrease");
        }
    }

}
