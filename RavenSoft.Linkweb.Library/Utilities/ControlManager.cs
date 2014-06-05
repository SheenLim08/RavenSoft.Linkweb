using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace RavenSoft.Linkweb.Library.Utilities
{
    public static class ControlManager
    {
        public static void SetControlFocus(Control[] controls)
        {
            for (int i = 0; i < controls.Count(); i++)
                controls[i].TabIndex = i;
        }
    }
}
