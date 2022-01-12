using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Enigma_Machine
{
    [TestClass]
    class RotorUT
    {
        [TestMethod]
        public void CreateRotor()
        {
            Rotor rot = new Rotor("QWERTYUIOPASDFGHJKLZXCVBNM", 'Q'); ;
        }
    }
}
