using Rhino;
using Rhino.DocObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RhinoWPFMVVVMIntro.Services
{
    public class LayerAssignmentService : ILayerAssignemntService
    {
        public LayerAssignmentService()
        {
        }

        public void AssignLayers()
        {
            List<RhinoObject> selectedObjects = GetSelectedObjects();
            foreach (RhinoObject rhinoObject in selectedObjects)
            {
                if (!IsNextLayerAvailable(out int layerIdx))
                    layerIdx = CreateNewRhinoLayer();

                AddObjectToLayer(rhinoObject, layerIdx);
            }
        }

        private List<RhinoObject> GetSelectedObjects()
        {
            RhinoDoc doc = GetDocOrThrow();
            return [.. doc.Objects.GetSelectedObjects(false, false)];
        }

        private bool IsNextLayerAvailable(out int layerIdx)
        {
            RhinoDoc doc = GetDocOrThrow();

            layerIdx = -1;
            for (int i = 0; i < doc.Layers.Count; i++)
            {
                Layer layer = doc.Layers[i];
                ObjectEnumeratorSettings settings = new()
                {
                    LayerIndexFilter = layer.Index,
                    NormalObjects = true
                };

                bool taken = doc.Objects.GetObjectList(settings).Any();
                if (!taken)
                {
                    layerIdx = layer.Index;
                    return true;
                }
            }

            return false;
        }

        private int CreateNewRhinoLayer()
        {
            RhinoDoc doc = GetDocOrThrow();
            return doc.Layers.Add(new Layer());
        }

        private void AddObjectToLayer(RhinoObject obj, int layerIdx)
        {
            RhinoDoc doc = GetDocOrThrow();

            obj.Attributes.LayerIndex = layerIdx;
            doc.Objects.Add(obj.Geometry, obj.Attributes);
            doc.Objects.Delete(obj);
        }

        static RhinoDoc GetDocOrThrow()
            => RhinoDoc.ActiveDoc
            ?? throw new InvalidOperationException("Active doc is null.");
    }
}
