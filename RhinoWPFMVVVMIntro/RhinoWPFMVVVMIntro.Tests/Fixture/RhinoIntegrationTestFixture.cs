using Rhino;

namespace RhinoWPFMVVVMIntro.Tests.Fixture;

public abstract class RhinoIntegrationTestFixture
{
    protected RhinoDoc Document { get; private set; } = null!;

    [SetUp]
    public void CreateHeadlessDocument()
    {
        Document = RhinoDoc.ActiveDoc ?? RhinoDoc.CreateHeadless(null!);
    }

    [TearDown]
    public void DisposeHeadlessDocument()
    {
        Document?.Dispose();
    }
}
