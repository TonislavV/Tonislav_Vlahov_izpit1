using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataLayer;
using BussinesLayer;

namespace Testing
{
    [TestClass]
    public class PlayersUnitTest
    {
        PlayerContext context;
        Player player;

        [TestInitialize]
        public void Setup()
        {
            var context = new PlayersDBContext();
            var _context = new PlayerContext(context);
            this.context = _context;

            Player user = new Player("Tonislav", "Vlahov", 18, "Toni", "Toni123", "tonislav@gmail.com");
            player = user;
        }
        [TestCleanup]
        public void CleanUp()
        {
            context.Delete(player);
            context.Create(player);
        }


        [TestMethod]
        public void CreateTest()
        {
            Assert.IsNotNull(context.Read(0));
        }
        [TestMethod]
        public void ReadTest()
        {
            var data = context.Read(0);

            Assert.AreEqual(21, data.Age);
        }
        [TestMethod]
        public void UpdateTest()
        {
            var newplayer = new Player("Tonislav", "Vlahov", 18, "Toni", "Toni123", "tonivlahov@gmail.com");
            context.Update(newplayer);

            Assert.AreEqual("Tonislav", context.Read(0).First_name);
        }
        [TestMethod]
        public void DeleteTest()
        {
            context.Delete(0);

            Assert.IsNull(context.Read(0));
        }
        [TestMethod]
        public void ReadAllTest()
        {
            Assert.IsNotNull(context.ReadAll());
        }
    }
}
