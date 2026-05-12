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

        public void ScaleSelectedRhinoObjects()
        {
            RhinoDoc doc = GetDocOrThrow();

            IReadOnlyList<Guid> selectedObjectsIds = GetSelectedObjectIds();
            List<RhinoObject> rhinoObjects = [.. selectedObjectsIds.Select(id => doc.Objects.Find(id))];

            ScaleService scaleService = new ScaleService();

            foreach (RhinoObject rhinoObject in rhinoObjects)
            {
                GeometryBase geometryScaled = scaleService.Scale(rhinoObject.Geometry, 10.0);
                Replace(rhinoObject.Id, geometryScaled);
            }

            Redraw();
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


        public void MoveAwaySelectedRhinoObjects()
        {
            RhinoDoc doc = GetDocOrThrow();
            MoveGeometryService moveService = new MoveGeometryService();

            foreach (RhinoObject rhinoObject in doc.Objects.GetSelectedObjects(false, false))
            {
                BoundingBox bbox = rhinoObject.Geometry.GetBoundingBox(true);
                Point3d center = bbox.Center;

                Vector3d direction = center - Point3d.Origin;

                if (direction.IsTiny())
                    continue;

                direction.Unitize();
                direction *= 10.0;

                GeometryBase movedGeometry =
                    moveService.Move(rhinoObject.Geometry, direction);
                Add(movedGeometry);
            }
            Redraw();
        }

        public void Add (GeometryBase geometry)
        {
            RhinoDoc doc = GetDocOrThrow();
            doc.Objects.Add(geometry);
        }

        static RhinoDoc GetDocOrThrow()
            => RhinoDoc.ActiveDoc
            ?? throw new InvalidOperationException("Active doc is null.");
    }
}
