using Microsoft.VisualStudio.TestTools.UnitTesting;
using LolCLI_V2;

namespace LolCLI_V2.Tests
{
    [TestClass()]
    public class HosTests
    {
        private readonly Hos parzival = new Hos("Parzival;a mágányos Hős;Fighter;A cél a kulcs! A cél a tojás!;500;100");

        [DataTestMethod()]
        [DataRow(10, 1400)]
        [DataRow(1, 500)]
        [DataRow(5, 900)]
        [DataRow(18, 2200)]
        public void HpErtekTest_AdottSzint_ElvartHp(int szint, int elvartHp)
        {
            Assert.AreEqual(elvartHp, parzival.HpErtek(szint));
        }
    }
}