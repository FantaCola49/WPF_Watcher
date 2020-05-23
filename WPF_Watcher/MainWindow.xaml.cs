using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Security.Permissions;

namespace WPF_Watcher
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        FileSystemWatcher watcher;
        DateTime FSLastRaised;
        string FileRoad;

        /// <summary>
        /// Watch on file deleting
        /// </summary>
        /// <param name="fschanged"></param>
        /// <param name="e"></param>
        protected void OnDeleted(object fschanged, FileSystemEventArgs e)
        {
            try
            {
                if (DateTime.Now.Subtract(FSLastRaised).TotalMilliseconds > 1000)
                {
                    FSLastRaised = DateTime.Now;
                    System.Threading.Thread.Sleep(100);

                    this.Dispatcher.Invoke((Action)(() =>
                    {
                        Display.Items.Add($"{e.ChangeType.ToString()};\n" +
                            $"{e.Name}; Time of Rename  : {DateTime.Now.ToShortTimeString()}");
                    }));
                }
            }
            catch
            {
                Display.Items.Add("\nОшибка в методе удаления!");
            }
        }
        /// <summary>
        /// Watch on file changing
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        public void OnChanged(object source, FileSystemEventArgs e)
        {
            string CreatedFileName = e.Name;
            FileInfo createdFile = new FileInfo(CreatedFileName);
            string extension = createdFile.Extension;
            string eventoccured = e.ChangeType.ToString();

            if (DateTime.Now.Subtract(FSLastRaised).TotalMilliseconds > 1000)
            {
                FSLastRaised = DateTime.Now;
                try
                {
                    System.Threading.Thread.Sleep(100);
                    this.Dispatcher.Invoke((Action)(() =>
                    {
                        //Notifications overlay
                        Display.Items.Add($"Changed File Name : {e.Name} ; \n" +
                            $"Event Occured : {e.ChangeType.ToString()};\n" +
                            $"Time of Modification : {DateTime.Now.ToShortTimeString()}");

                    }));
                }
                catch
                {
                    Display.Items.Add("\nERROR in change method!");
                }
            }
        }
        /// <summary>
        /// Watch on file creating
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        public void OnCreated(object source, FileSystemEventArgs e)
        {
            if (DateTime.Now.Subtract(FSLastRaised).TotalMilliseconds > 1000)
            {
                string CreatedFileName = e.Name;
                FileInfo createdFile = new FileInfo(CreatedFileName);
                string extension = createdFile.Extension;

                //Time of change notification
                FSLastRaised = DateTime.Now;
                //Method interruption to avoid dublicates in notifications
                System.Threading.Thread.Sleep(100);
                //Вызываю dispatcher 
                this.Dispatcher.Invoke((Action)(() =>
                {
                    //Display notification
                    Display.Items.Add($"{e.ChangeType};\n" +
                        $"{CreatedFileName};\n" +
                        $"Created Time  : {DateTime.Now.ToShortTimeString()}");
                }));

            }
        }

        /// <summary>
        /// Watch on file renaming
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        public void OnRenamed(object source, RenamedEventArgs e)
        {
            if (DateTime.Now.Subtract(FSLastRaised).TotalMilliseconds > 1000)
            {
                FSLastRaised = DateTime.Now;

                System.Threading.Thread.Sleep(100);

                //Old name of file
                string oldname = e.OldName;

                this.Dispatcher.Invoke((Action)(() =>
                {
                    //Display notification
                    Display.Items.Add($"{e.ChangeType.ToString()}, { e.Name};\n" +
                        $"Old Name: {e.OldName};\n" +
                        $"Time of Rename: {DateTime.Now.ToShortTimeString()}");
                }));
            }
        }

        /// <summary>
        /// Begin watching o_o
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Start_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FileRoad = $@"{FileWay.Text}";

                watcher = new FileSystemWatcher(FileRoad, "*.*");
                
                Display.Items.Add("Start watching");

                watcher.EnableRaisingEvents = true;
                watcher.IncludeSubdirectories = true;

                watcher.Created += new FileSystemEventHandler(OnCreated);
                watcher.Changed += new FileSystemEventHandler(OnChanged);
                watcher.Renamed += new RenamedEventHandler(OnRenamed);
                watcher.Deleted += new FileSystemEventHandler(OnDeleted);
            }
            catch
            {
                Display.Items.Add("Oops, something gone wrong, check the file path and try again!");
            }
        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                watcher.Dispose();
                Display.Items.Add("Stop watching");
            }
            catch
            {
                Display.Items.Add("You are not watching on directory! Try to put file path ant press start!");
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Display.Items.Clear();
        }
    }
}
