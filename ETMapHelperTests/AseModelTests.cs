using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ETMapHelper.Objects;

namespace ETMapHelperTests
{
    [TestClass]
    public class AseModelTests
    {
        [TestMethod]
        public void GetMaterialTest()
        {
            var model = new AseModel();
            var line = "		*MATERIAL_NAME	\"textures/medieval_soc/woodplank_2\"";

            var result = model.GetMaterial(line);
            var expected = "textures/medieval_soc/woodplank_2";

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ReplaceBitmapTest()
        {
            var model = new AseModel();
            var material = "textures/medieval_soc/woodplank_2";
            var line = "			*BITMAP	\"..\\textures\\medieval_soc\\woodplank_2.tga\"";

            var result = model.ReplaceBitmap(material, line);
            var expected = $"			*BITMAP	\"{material}\"";

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ReplaceBitmapTest2()
        {
            var model = new AseModel();
            var line = "			*BITMAP	\"textures/medieval_soc/woodplank_2\"";

            var result = model.ReplaceBitmap("", line);
            var expected = line;

            Assert.AreEqual(expected, result);
        }
    }
}
