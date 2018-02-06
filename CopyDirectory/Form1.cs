using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CopyDirectory.Core;

namespace CopyDirectory
{
    public partial class Form1 : Form
    {
        private CancellationTokenSource cancellationToken;

        public Form1()
        {
            Debugger.Log(1, "locura", $"form id: {Thread.CurrentThread.ManagedThreadId}");
            InitializeComponent();
            DirectoryHandler = new DirectoryHandler();
            DirectoryHandler.NewFileCopied += AddFilePathIntoListBox;
        }

        private void AddFilePathIntoListBox(string filePath)
        {
            Invoke((MethodInvoker)(() =>
            {
                listBox.Items.Add(filePath);
                listBox.Refresh();
            }));
        }

        public DirectoryHandler DirectoryHandler { get; set; }

        private void sourceDirectoryButton_Click(object sender, EventArgs e) =>
            sourceDirectoryLabel.Text = GetFolderPath();

        private string GetFolderPath()
        {
            var dialog = new FolderBrowserDialog { ShowNewFolderButton = true };
            return dialog.ShowDialog() == DialogResult.OK ? dialog.SelectedPath : string.Empty;
        }

        private void targetDirectoryButton_Click(object sender, EventArgs e) =>
            targetDirectoryLabel.Text = GetFolderPath();

        private async void copyButton_Click(object sender, EventArgs e)
        {
            listBox?.Items.Clear();

            cancellationToken = new CancellationTokenSource();

            copyButton.Text = "Cancel";
            copyButton.Click -= copyButton_Click;
            copyButton.Click += CancelCopy;
            await Task.Run(() =>
            {
                DirectoryHandler.OperationResult? handler = null;
                try
                {
                    using (cancellationToken.Token.Register(Thread.CurrentThread.Abort))
                    {
                        handler =
                            DirectoryHandler.CopyDirectory(sourceDirectoryLabel.Text, targetDirectoryLabel.Text);
                    }
                }
                catch
                {
                }

                if (handler.HasValue)
                    switch (handler.Value)
                    {
                        case DirectoryHandler.OperationResult.SourceFolderDoesNotExist:
                            MessageBox.Show("Source folder does not exist");
                            break;
                        case DirectoryHandler.OperationResult.TargetFolderDoesNotExist:
                            MessageBox.Show("Target folder does not exist");
                            break;
                        case DirectoryHandler.OperationResult.NonEmptyTarget:
                            MessageBox.Show("The target folder is not empty");
                            break;
                        case DirectoryHandler.OperationResult.GeneralError:
                            MessageBox.Show("There was an unkown error");
                            break;
                        case DirectoryHandler.OperationResult.Succesful:
                            MessageBox.Show("Operation completed successfully");
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
            }, cancellationToken.Token).ContinueWith((_) =>
            {
                Invoke((MethodInvoker)(() =>
               {
                   copyButton.Text = "Copy";
                   copyButton.Click -= CancelCopy;
                   copyButton.Click += copyButton_Click;
               }));
            });
        }

        private void CancelCopy(object sender, EventArgs e) => cancellationToken.Cancel();
    }
}