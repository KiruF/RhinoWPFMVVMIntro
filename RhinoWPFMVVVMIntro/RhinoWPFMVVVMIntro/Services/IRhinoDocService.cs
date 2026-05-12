namespace RhinoWPFMVVVMIntro.Services
{
    /// <summary>
    /// Exposes document operations used by view models.
    /// </summary>
    public interface IRhinoDocService
    {
        void SelectAllRhinoObjects();

        void Redraw();
    }
}
