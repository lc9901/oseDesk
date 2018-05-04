using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.ComponentModel;

namespace LocationTest
{
    public class SetLanguage
    {
        public static void ReSetLanguage(string language, Form form, Type type)
        {
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(language);

            if (form != null)
            {
                ComponentResourceManager resource = new ComponentResourceManager(type);
                resource.ApplyResources(form, "$this");
                AppLang(form, resource);
            }
        }

        private static void AppLang(Control control, ComponentResourceManager resources)
        {
            foreach (Control c in control.Controls)
            {
                resources.ApplyResources(c, c.Name);
                AppLang(c, resources);
            }
        }
    }
}
