using Microsoft.VisualStudio.TestTools.UnitTesting;
using TabGrabber;

namespace TabGrabberTests {
    [TestClass]
    public class WebQueryTest {
        [TestMethod]
        public void CheckForExistingTabTest() {
            var result = WebQuery.CheckForTab(new Song("Point Of No Return", "Havok", "Time Is Up"));
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckForExistingTabIncorrectCaseTest() {
            var result = WebQuery.CheckForTab(new Song("PoiNt of no retURn", "Havok", "Time Is Up"));
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckForNonExistingTabTest() {
            var result = WebQuery.CheckForTab(new Song("This Tab Doesn't Exist", "Havok", "Time Is Up"));
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckForNonExistingArtistTest() {
            var result = WebQuery.CheckForTab(new Song("This Tab Doesn't Exist", "Words Words Words Test Test Test", "Generic Album"));
            Assert.IsFalse(result);
        }
    }
}
