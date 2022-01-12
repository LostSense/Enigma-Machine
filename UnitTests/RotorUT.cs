using Microsoft.VisualStudio.TestTools.UnitTesting;
using Enigma_Machine;

namespace UnitTests
{
    [TestClass]
    public class RotorUT
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestMethod]
        public void TryToAddNextRotor()
        {
            Rotor rot1 = new Rotor("QWERTYUIOPASDFGHJKLZXCVBNM", 'Q');
            Rotor rot2 = new Rotor("QWERTYUIOPASDFGHJKLZXCVBNM", 'Q');
            rot1.AddNextRotor(rot2);
        }

        [TestMethod]
        public void CheckRotorSignal()
        {
            //======================ABCDEFGHIJKLMNOPQRSTUVWXYZ============
            //======================01234567890123456789012345=============
            Rotor rot1 = new Rotor("QWERTYUIOPASDFGHJKLZXCVBNM", 'Q');
            rot1.SetRotorAsMain();
            rot1.SetRotorPosition(0);
            int v = rot1.PassSignalFromEnter(1);
            Assert.AreEqual(17, v);
        }

        [TestMethod]
        public void CheckMirrorRotorSignal()
        {
            //======================ABCDEFGHIJKLMNOPQRSTUVWXYZ============
            //======================01234567890123456789012345=============
            Rotor rot1 = new Rotor("ABCDEFGHIJKLMNOPQRSTUVWXYZ", 'Q');
            rot1.SetRotorAsMain();
            rot1.SetRotorPosition(0);
            int v = rot1.PassSignalFromEnter(1);
            Assert.AreEqual(1, v);
        }

        [TestMethod]
        public void GetReflectedSignal()
        {
            Rotor rot1 = new Rotor("QWERTYUIOPASDFGHJKLZXCVBNM", 'Q');
            rot1.SetRotorAsMain();
            rot1.SetRotorPosition(0);
            int signal = 25;
            int a = rot1.PassSignalFromEnter(signal);
            int b = rot1.PassSignalFromBackward(a);
            Assert.AreEqual(signal, b);
        }
    }
}
