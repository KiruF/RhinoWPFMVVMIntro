using Rhino;
using Rhino.Testing.Fixtures;

namespace RhinoWPFMVVVMIntro.Tests;

[SetUpFixture]
public class GlobalSetup : RhinoSetupFixture
{
    public RhinoDoc Document { get; private set; }


    [OneTimeSetUp]
    public override void OneTimeSetup()
    {
        base.OneTimeSetup();
        Document = RhinoDoc.ActiveDoc ?? RhinoDoc.CreateHeadless(null);
    }

    [OneTimeTearDown]
    public override void OneTimeTearDown()
    {
        base.OneTimeTearDown();
        Document?.Dispose();
    }
}
