using Rhino.Geometry;
using System;
using System.Collections.Generic;

namespace RhinoWPFMVVVMIntro.Services
{
    /// <summary>
    /// Exposes document operations used by view models.
    /// </summary>
    public interface IRhinoDocService
    {
        IReadOnlyList<Guid> GetSelectedObjectIds();

        void SelectAllRhinoObjects();
        void MoveAwaySelectedRhinoObjects();

        void ScaleSelectedRhinoObjects();

        void Redraw();

        void Replace(Guid rhinoObjectId, GeometryBase geometry);

        List<GeometryBase> GetGeometryFromIds(IReadOnlyList<Guid> selectedObjectsIds);
    }
}
