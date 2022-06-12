using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BiliBiliAPI.GUI.Event
{
    public class MainEvent
    {
        public ControlEnum Controlenum { get; set; }
        public UserControl MyControl { get; set; } = null!;
    }

    public enum ControlEnum
    {
        Login,User
    }
}
