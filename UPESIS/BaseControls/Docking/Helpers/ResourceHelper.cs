using System;
using System.Drawing;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;

namespace BaseControls.Docking
{
	internal static class ResourceHelper
	{
        private static ResourceManager _resourceManager = null;

        private static ResourceManager ResourceManager
        {
            get
            {
                if (_resourceManager == null)
                    _resourceManager = new ResourceManager("BaseControls.Properties.Resources", typeof(ResourceHelper).Assembly);
                return _resourceManager;
            }

        }

        public static Bitmap LoadBitmap(string name)
        {
            Assembly assembly = typeof(DockPanel).Assembly;
            string fullNamePrefix = "BaseControls.Docking.Resources.";
            return new Bitmap(assembly.GetManifestResourceStream(fullNamePrefix + name));
        }
        public static Bitmap LoadExtenderBitmap(string name)
        {
            Assembly assembly = typeof(Extender).Assembly;
            return new Bitmap(assembly.GetManifestResourceStream("BaseControls.Docking.Resources." + name));
        }


		public static string GetString(string name)
		{
			return ResourceManager.GetString(name);
		}
	}
}
