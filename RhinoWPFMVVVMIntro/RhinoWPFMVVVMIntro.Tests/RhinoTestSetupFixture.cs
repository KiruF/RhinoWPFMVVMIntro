namespace RhinoWPFMVVVMIntro.Tests;

[SetUpFixture]
[Apartment(ApartmentState.STA)]
public sealed class RhinoTestSetupFixture : Rhino.Testing.Fixtures.RhinoSetupFixture
{
    public override void OneTimeSetup()
    {
        base.OneTimeSetup();

        // Any additional setup for Rhino tests can be done here.
    }

    public override void OneTimeTearDown()
    {
        base.OneTimeTearDown();

        // Any additional cleanup for Rhino tests can be done here.
    }
}
