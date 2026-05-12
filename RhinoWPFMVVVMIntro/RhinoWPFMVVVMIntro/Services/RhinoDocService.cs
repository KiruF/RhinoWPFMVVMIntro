using Rhino;
using Rhino.Commands;
using Rhino.DocObjects;
using Rhino.Geometry;
using Rhino.Input.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

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

        public void CrazyRotate()
        {
            RhinoDoc doc = GetDocOrThrow();
            var selectedObjects = doc.Objects.GetSelectedObjects(false, false);
            Random random = new();

            foreach (RhinoObject rhinoObject in selectedObjects)
            {
                double angle = RhinoMath.ToRadians(random.NextDouble() * 360.0);
                Transform rotation = Transform.Rotation(
                    angle,
                    Vector3d.ZAxis,
                    Point3d.Origin);

                GeometryBase geometryCopy = rhinoObject.DuplicateGeometry();
                geometryCopy.Transform(rotation);
                doc.Objects.Add(geometryCopy);
            }

            Redraw();
        }

        public IReadOnlyList<Guid> GetSelectedObjectIds()
        {
            RhinoDoc doc = RhinoDoc.ActiveDoc;
            if (doc == null)
                return [];

            IReadOnlyList<Guid> objIds = [.. doc.Objects.GetSelectedObjects(false, false).Select(obj => obj.Id)];
            return objIds;
        }

        public void Redraw()
        {
            RhinoDoc doc = RhinoDoc.ActiveDoc;
            if (doc == null)
                return;

            doc.Views.Redraw();
        }

        static RhinoDoc GetDocOrThrow()
        => RhinoDoc.ActiveDoc
        ?? throw new InvalidOperationException("Active doc is null.");
    }
}
