using NP.Utilities;
using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace NP.Visuals
{
    public class ChannelToConsoleBehavior : ConsoleWriterBase, IVisualBehavior
    {
        TextBlock _textBlockToChannelConsoleOutputTo = null;

        public void Attach(FrameworkElement el)
        {
            _textBlockToChannelConsoleOutputTo =
                (TextBlock)el;

            Console.SetOut(this);
        }

        public void Detach(FrameworkElement el)
        {
            _textBlockToChannelConsoleOutputTo = null;

            Console.SetOut(null);
        }

        protected override void WriteString(string str)
        {
            _textBlockToChannelConsoleOutputTo.Text += str;
        }
    }
}
