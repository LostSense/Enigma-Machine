using Microsoft.VisualStudio.TestTools.UnitTesting;
using Enigma_Machine;

namespace UnitTests
{
    [TestClass]
    public class EnigmaMachineUT
    {
        [TestMethod]
        public void CreateEnigma()
        {
            Enigma enim = new Enigma();
        }

        [TestMethod]
        public void GetCodeFromEnigma()
        {
            string text = "Hello world";
            string code = "";
            Enigma enim = new Enigma();
            code = enim.GetSignal(text);
        }
    }
}
