using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WormGame;
using System.Windows.Input;
namespace WormGameTest
{
    [TestClass]
    public class PlayerTest
    {
        [TestMethod]
        public void PlayerMove_WhenKeyUpThenYDecremented()
        {
            //init test
            var g = new Game();
            g.Height = 100;
            var p = new Player(g);
            p.Y = 30;
            //run test
            p.Move(Key.Up);
            //assert test
            Assert.AreEqual(28, p.Y);
            

        }
    }
}
