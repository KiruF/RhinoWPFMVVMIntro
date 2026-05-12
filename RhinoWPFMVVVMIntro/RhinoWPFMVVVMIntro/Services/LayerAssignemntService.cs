using Rhino;
using Rhino.DocObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RhinoWPFMVVVMIntro.Services
{
    public class LayerAssignmentService : ILayerAssignemntService
    {
        public readonly RhinoDoc Doc;

        public LayerAssignmentService(RhinoDoc activeDocument)
        {
            Doc = activeDocument ?? throw new ArgumentNullException(nameof(activeDocument));
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
            => [.. Doc.Objects.GetSelectedObjects(false, false)];

        private bool IsNextLayerAvailable(out int layerIdx)
        {
            layerIdx = -1;
            for (int i = 0; i < Doc.Layers.Count; i++)
            {
                Layer layer = Doc.Layers[i];
                ObjectEnumeratorSettings settings = new()
                {
                    LayerIndexFilter = layer.Index,
                    NormalObjects = true
                };

                bool taken = Doc.Objects.GetObjectList(settings).Any();
                if (!taken)
                {
                    layerIdx = layer.Index;
                    return true;
                }
            }

            return false;
        }

        private int CreateNewRhinoLayer()
            => Doc.Layers.Add(new Layer());

        private void AddObjectToLayer(RhinoObject obj, int layerIdx)
        {
            obj.Attributes.LayerIndex = layerIdx;
            Doc.Objects.Add(obj.Geometry, obj.Attributes);
            Doc.Objects.Delete(obj);
        }
    }
}
