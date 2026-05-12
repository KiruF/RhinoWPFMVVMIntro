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

        void Redraw();
    }
}
