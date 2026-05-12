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

        public void AssignLayers(IReadOnlyList<Guid> selObjIds)
        {
            RhinoDoc doc = GetDocOrThrow();
            List<RhinoObject> selectedRhinoObjects = [.. selObjIds.Select(id => doc.Objects.Find(id))];
            foreach (RhinoObject rhinoObject in selectedRhinoObjects)
            {
                if (!IsNextLayerAvailable(out int layerIdx))
                    layerIdx = CreateNewRhinoLayer(rhinoObject.Id.ToString());

                AddObjectToLayer(rhinoObject, layerIdx);
            }
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

        private int CreateNewRhinoLayer(string layerName)
        {
            RhinoDoc doc = GetDocOrThrow();
            return doc.Layers.Add(new Layer() { Name = layerName });
        }

        private void AddObjectToLayer(RhinoObject obj, int layerIdx)
        {
            RhinoDoc doc = GetDocOrThrow();

            obj.Attributes.LayerIndex = layerIdx;

            if (doc.Layers[layerIdx].Name != obj.Id.ToString())
                doc.Layers[layerIdx].Name = obj.Id.ToString();

            doc.Objects.ModifyAttributes(obj, obj.Attributes, true);
        }

        static RhinoDoc GetDocOrThrow()
            => RhinoDoc.ActiveDoc
            ?? throw new InvalidOperationException("Active doc is null.");
    }
}
