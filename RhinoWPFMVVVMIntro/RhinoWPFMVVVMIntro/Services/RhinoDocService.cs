using Rhino;
using Rhino.DocObjects;
using Rhino.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public IReadOnlyList<Guid> GetSelectedObjectIds()
        {
            RhinoDoc doc = RhinoDoc.ActiveDoc;
            if (doc == null)
                return [];

            IReadOnlyList<Guid> objIds = [.. doc.Objects.GetSelectedObjects(false, false).Select(obj => obj.Id)];
            return objIds;
        }

        public void Replace(Guid objectsId, GeometryBase geometry)
        {
            RhinoDoc doc = GetDocOrThrow();

            doc.Objects.Replace(objectsId, geometry, false);
        }

        public void Redraw()
        {
            RhinoDoc doc = GetDocOrThrow();
            doc.Views.Redraw();
        }

        static RhinoDoc GetDocOrThrow()
            => RhinoDoc.ActiveDoc
            ?? throw new InvalidOperationException("Active doc is null.");

        public List<GeometryBase> GetGeometryFromIds(IReadOnlyList<Guid> selectedObjectsIds)
        {
            RhinoDoc doc = GetDocOrThrow();
            List<GeometryBase> selectedGeometries = new List<GeometryBase>();

            foreach (Guid id in selectedObjectsIds)
            {
                RhinoObject rhObj = doc.Objects.Find(id);
                if (rhObj != null)
                {
                    GeometryBase geometryBase = rhObj.Geometry;
                    selectedGeometries.Add(geometryBase);
                }
            }

            return selectedGeometries;
        }
    }
}
