using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace RhinoWPFMVVVMIntro.Base
{
    /// <summary>
    /// Base type for view models that notify WPF bindings about property changes.
    /// </summary>
    public abstract class PropertyChangedNotifier : INotifyPropertyChanged
    {
        /// <summary>
        /// Gets or sets whether invalid property names throw during debug validation.
        /// </summary>
        public bool ThrowOnInvalidPropertyName { get; set; } = false;

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Raises property change notification.
        /// </summary>
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            VerifyPropertyName(propertyName);

            PropertyChanged?.Invoke(
                this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Verifies that a property name exists on this instance in debug builds.
        /// </summary>
        [Conditional("DEBUG")]
        [DebuggerStepThrough]
        public void VerifyPropertyName(string? propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
                return;

            if (TypeDescriptor.GetProperties(this)[propertyName] == null)
            {
                string msg = "Invalid property name: " + propertyName;
                if (ThrowOnInvalidPropertyName)
                    throw new Exception(msg);

                Debug.Fail(msg);
            }
        }
    }
}
