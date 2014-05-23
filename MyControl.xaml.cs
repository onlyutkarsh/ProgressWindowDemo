using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell.Interop;
using IOleServiceProvider = Microsoft.VisualStudio.OLE.Interop.IServiceProvider;
using MessageBox = System.Windows.Forms.MessageBox;

namespace UtkarshShigihalli.ProgressWindowDemo
{
    /// <summary>
    /// Interaction logic for MyControl.xaml
    /// </summary>
    public partial class MyControl : UserControl
    {
        private IServiceProvider _serviceProvider;
        public MyControl(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1300:SpecifyMessageBoxOptions")]
        private void ThreadedNonCancellable_Click(object sender, RoutedEventArgs e)
        {
            var dialogFactory = _serviceProvider.GetService(typeof(SVsThreadedWaitDialogFactory)) as IVsThreadedWaitDialogFactory;
            IVsThreadedWaitDialog2 dialog = null;
            if (dialogFactory != null)
            {
                dialogFactory.CreateInstance(out dialog);
            }

            /* Wait dialog with marquee progress */
            if (dialog != null && dialog.StartWaitDialog(
                "Threaded Wait Dialog", "VS is Busy",
                "Progress text", null,
                "Waiting status bar text",
                0, false,
                true) == VSConstants.S_OK)
            {
                Thread.Sleep(4000);
            }
            int usercancel;
            dialog.EndWaitDialog(out usercancel);

        }

        private void OnShowWithCancelButton(object sender, RoutedEventArgs e)
        {
            var dialogFactory = _serviceProvider.GetService(typeof(SVsThreadedWaitDialogFactory)) as IVsThreadedWaitDialogFactory;
            IVsThreadedWaitDialog2 dialog = null;
            if (dialogFactory != null)
            {
                dialogFactory.CreateInstance(out dialog);
            }

            /* Wait dialog with marquee progress */
            if (dialog != null && dialog.StartWaitDialog(
                "Wait Dialog (with Cancel)",
                "VS is Busy, but you can cancel this task by clicking Cancel button",
                "Progress text", null,
                "Waiting status bar text", 0, true,
                true) == VSConstants.S_OK)
            {
                Thread.Sleep(5000);
            }

            bool isCancelled;
            dialog.HasCanceled(out isCancelled);
            if (isCancelled)
            {
                MessageBox.Show("Cancelled");
            }
        }

    }
}