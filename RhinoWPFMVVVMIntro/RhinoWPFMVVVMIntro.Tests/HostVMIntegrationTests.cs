using Rhino.Testing.Fixtures;

namespace RhinoWPFMVVVMIntro.Tests;

[TestFixture]
[Explicit("Integration test mockup requires Rhino test host setup.")]
public sealed class HostVMIntegrationTests : RhinoTestFixture
{
    [Test]
    public void HostVM_CanBeTestedInsideRhino()
    {
        Assert.Pass("Integration test mockup for HostVM.");
    }
}
