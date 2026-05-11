using Rhino;
using Rhino.DocObjects;
using System;

namespace RhinoWPFMVVVMIntro.Services
{
    /// <summary>
    /// Handles interaction with Rhino documents and Rhino objects.
    /// </summary>
    public sealed class RhinoDocService
    {
        public readonly RhinoDoc Doc;

        ObjectEnumeratorSettings _settings = new ObjectEnumeratorSettings()
        {
            NormalObjects = true
        };

        public RhinoDocService(RhinoDoc activeDocument)
        {
            Doc = activeDocument
                ?? throw new ArgumentNullException(nameof(activeDocument));
        }

        public void SelectAllRhinoObjects()
        {
            foreach (RhinoObject rhinoObject in Doc.Objects.GetObjectList(_settings))
                rhinoObject.Select(true);

            Redraw();
        }

        public void Redraw()
            => Doc.Views.Redraw();
    }
}
