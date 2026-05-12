namespace RhinoWPFMVVVMIntro.Tests;

[SetUpFixture]
[Apartment(ApartmentState.STA)]
public sealed class RhinoGeometryTestSetupFixture : Rhino.Testing.Fixtures.RhinoSetupFixture
{
    public override void OneTimeSetup()
    {
        base.OneTimeSetup();

        // Any additional setup for Rhino.Geometry tests can be done here.
    }

    public override void OneTimeTearDown()
    {
        base.OneTimeTearDown();

        // Any additional cleanup for Rhino.Geometry tests can be done here.
    }
}
