using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CopyDirectory.Core;

namespace CopyDirectory
{
    public partial class Form1 : Form
    {
        public Form1()
        {
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

        private void copyButton_Click(object sender, EventArgs e)
        {
            listBox?.Items.Clear();
            Task.Run(() =>
            {
                DirectoryHandler.OperationResult handler =
                    DirectoryHandler.CopyDirectory(sourceDirectoryLabel.Text, targetDirectoryLabel.Text);
                switch (handler)
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
            });
        }
    }
}