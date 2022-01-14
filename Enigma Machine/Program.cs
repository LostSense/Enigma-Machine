using System;

namespace Enigma_Machine
{
    class Program
    {
        static void Main(string[] args)
        {
            Translator trs = new Translator();
            trs.Run("EGTDPCTAGJXLZXFNHYXPUFPHYSBYBINMCBNVSLCZFSSAUQCELUPIMENJBLYSQVKFIUXFFQMLUUIATAUXVUMCBGGPFCHUYHPEFWDAJSRQIPICEDSNPXEBRDBG");
        }
    }
}
