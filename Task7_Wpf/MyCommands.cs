using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Task7._1_Wpf
{
    class MyCommands
    {
        //public static RoutedCommand Exit { get; set; }
        public static RoutedUICommand SaveAs { get; set; }
        public static RoutedUICommand Exit { get; set; }
        static MyCommands()
        {
            SaveAs = new RoutedUICommand();
            InputGestureCollection inputs1 = new InputGestureCollection();
            inputs1.Add(new KeyGesture(Key.S, ModifierKeys.Control | ModifierKeys.Shift, "Ctrl+Shift+S"));
            SaveAs = new RoutedUICommand("Сохранить как", "SaveAs", typeof(MyCommands), inputs1);

            Exit = new RoutedUICommand();
            InputGestureCollection inputs2 = new InputGestureCollection();
            inputs2.Add(new KeyGesture(Key.T, ModifierKeys.Control, "Ctrl+T"));
            //Exit = new RoutedCommand("Exit", typeof(MyCommands), inputs);
            Exit = new RoutedUICommand("Выход", "Exit", typeof(MyCommands), inputs2);

        }
    }
}
