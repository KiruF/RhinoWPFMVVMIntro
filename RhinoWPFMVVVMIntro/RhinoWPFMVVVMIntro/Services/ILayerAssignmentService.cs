using System;
using System.Collections.Generic;

namespace RhinoWPFMVVVMIntro.Services
{
    public interface ILayerAssignemntService
    {
        public void AssignLayers(IReadOnlyList<Guid> objIds);
    }
}
