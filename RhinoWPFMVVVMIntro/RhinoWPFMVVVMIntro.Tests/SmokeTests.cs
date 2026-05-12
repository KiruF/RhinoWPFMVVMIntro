namespace RhinoWPFMVVVMIntro.Tests;

[TestFixture]
public sealed class SmokeTests
{
    [Test]
    [Category("Smoke")]
    public void TestAssemblyLoads()
    {
        Assert.That(typeof(GlobalSetup).Assembly, Is.Not.Null);
    }
}
