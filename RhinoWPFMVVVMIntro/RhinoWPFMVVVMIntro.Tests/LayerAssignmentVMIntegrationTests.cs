using Rhino.Testing.Fixtures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhinoWPFMVVVMIntro.Tests
{
    [TestFixture]
    [Explicit("Integration test mockup requires Rhino test host setup.")]
    public class LayerAssignmentVMIntegrationTests : RhinoTestFixture
    {
        [Test]
        public void LayerAsiignmentVM_CanBeTestedInsideRhino()
        {
            Assert.Pass("Integration test mockup for HostVM.");
        }
    }
}
