using Rhino;

namespace RhinoWPFMVVVMIntro.Tests;

public abstract class RhinoIntegrationTestFixture
{
    protected RhinoDoc Doc { get; private set; } = null!;

    [SetUp]
    public void CreateHeadlessDocument()
    {
        Doc = RhinoDoc.ActiveDoc ?? RhinoDoc.CreateHeadless(null!);
    }

    [TearDown]
    public void DisposeHeadlessDocument()
    {
        Doc?.Dispose();
    }
}
