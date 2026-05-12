using Rhino;
using Rhino.PlugIns;
using Rhino.UI;
using RhinoWPFMVVVMIntro.Services;
using RhinoWPFMVVVMIntro.Views;
using System;
using System.IO;
using System.Reflection;

namespace RhinoWPFMVVVMIntro
{
    /// <summary>
    /// Rhino plugin entry point.
    /// </summary>
    public class RhinoWPFMVVVMIntroPlugin : Rhino.PlugIns.PlugIn
    {
        static RhinoWPFMVVVMIntroPlugin? _instance;

        public RhinoWPFMVVVMIntroPlugin()
        {
            _instance = this;
            RhinoDoc.NewDocument += OnNewDoc;
        }

        void OnNewDoc(object? sender, DocumentEventArgs e)
        {
            RhinoDoc.NewDocument -= OnNewDoc;

            RhinoDoc doc = e.Document
                ?? throw new InvalidOperationException("Rhino active document was not found");

            RhinoDocService = new RhinoDocService(doc);
            LayerAssignmentService = new LayerAssignmentService(doc);
        }

        /// <summary>
        /// Gets the loaded plugin instance.
        /// </summary>
        public static RhinoWPFMVVVMIntroPlugin Instance
        {
            get
            {
                if (_instance == null)
                    throw new InvalidOperationException("RhinoWPFMVVVMIntro plugin instance was not initialized");

                return _instance;
            }
        }

        /// <summary>
        /// Provides plugin-wide access to Rhino document operations.
        /// </summary>
        public IRhinoDocService RhinoDocService { get; private set; }
        public ILayerAssignemntService LayerAssignmentService { get; private set; }

        protected override LoadReturnCode OnLoad(ref string errorMessage)
        {
            try
            {
                Panels.RegisterPanel(
                    this,
                    typeof(HostView),
                    "Rhino WPF MVVM Intro",
                    LoadEmbeddedIcon("RhinoWPFMVVVMIntro.EmbeddedResources.plugin-utility.ico"),
                    PanelType.PerDoc);
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return LoadReturnCode.ErrorShowDialog;
            }

            return LoadReturnCode.Success;
        }

        static System.Drawing.Icon LoadEmbeddedIcon(string resourceName)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            using Stream stream = assembly.GetManifestResourceStream(resourceName)
                ?? throw new InvalidOperationException($"Embedded resource {resourceName} not found");

            return new System.Drawing.Icon(stream);
        }
    }
}
