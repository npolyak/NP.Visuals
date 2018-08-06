using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace NP.Visuals
{
    public class ChannelToConsoleBehavior : TextWriter, IVisualBehavior
    {
        TextBlock _textBlockToChannelConsoleOutputTo = null;

        public override Encoding Encoding =>
            Encoding.ASCII;

        SynchronizationContext _syncContext = null;

        public void Attach(FrameworkElement el)
        {
            _textBlockToChannelConsoleOutputTo =
                (TextBlock)el;

            _syncContext = SynchronizationContext.Current;

            Console.SetOut(this);
        }

        public void Detach(FrameworkElement el)
        {
            _textBlockToChannelConsoleOutputTo = null;

            Console.SetOut(null);
        }

        void PerformInSyncContext<T>(T val, Action<T> operation)
        {
            if (_syncContext != null)
            {
                _syncContext.Send((state) => operation(val), null);
            }
            else
            {
                operation(val);
            }
        }

        public override void Write(char value)
        {
            PerformInSyncContext<char>
            (
                value,
                (val) => _textBlockToChannelConsoleOutputTo.Text += val
            );
        }

        public override void Write(string value)
        {
            PerformInSyncContext<string>
            (
                value,
                (val) => _textBlockToChannelConsoleOutputTo.Text += val
            );
        }
    }
}
