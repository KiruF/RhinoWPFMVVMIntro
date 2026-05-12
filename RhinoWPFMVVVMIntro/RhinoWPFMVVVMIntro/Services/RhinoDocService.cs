using Rhino;
using Rhino.DocObjects;

namespace RhinoWPFMVVVMIntro.Services
{
    /// <summary>
    /// Handles interaction with Rhino documents and Rhino objects.
    /// </summary>
    public sealed class RhinoDocService : IRhinoDocService
    {
        ObjectEnumeratorSettings _settings = new ObjectEnumeratorSettings()
        {
            NormalObjects = true
        };

        public RhinoDocService()
        {
        }

        public void SelectAllRhinoObjects()
        {
            RhinoDoc doc = RhinoDoc.ActiveDoc;
            if (doc == null)
                return;

            foreach (RhinoObject rhinoObject in doc.Objects.GetObjectList(_settings))
                rhinoObject.Select(true);

            Redraw();
        }

        public void Redraw()
        {
            RhinoDoc doc = RhinoDoc.ActiveDoc;
            if (doc == null)
                return;

            doc.Views.Redraw();
        }
    }
}
