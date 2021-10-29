using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Threading;

namespace KursyPlayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region VARIABLES
        string courseMainPath = String.Empty;
        string filmPaths = String.Empty;
        Dictionary<string, string> courses = new Dictionary<string, string>();
        Dictionary<string, string> lessons = new Dictionary<string, string>();
        bool progressChanging = false;
        #endregion


        public MainWindow()
        {
            InitializeComponent();

            sldProgress.AddHandler(MouseLeftButtonUpEvent,
                      new MouseButtonEventHandler(timeSlider_MouseLeftButtonUp),
                      true);

        }

        private void LoadCourses(string path)
        {          
            foreach(var val in Directory.GetDirectories(path).ToList())
            {
                courses.Add(val.Substring(val.LastIndexOf('\\') + 1), val);
            }

            lbxCourses.ItemsSource = courses.Keys;
        }

        private void lbxCourses_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
            if (lbxCourses.SelectedIndex > -1)
            {
                string directory = courses.GetValueOrDefault(lbxCourses.SelectedItem.ToString());
                if (Directory.Exists(directory))
                {
                    lessons = new Dictionary<string, string>();
                    foreach (var val in Directory.GetFiles(directory).Where(x => x.EndsWith(".mp4") || x.EndsWith(".MP4")).ToList())
                    {
                        lessons.Add(val.Substring(val.LastIndexOf('\\') + 1).Replace(".mp4","").Replace(".MP4",""), val);
                    }
                    lbxLessons.ItemsSource = lessons.Keys;
                }
            }
        }

        private void lbxLessons_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbxLessons.SelectedIndex > -1)
            {
                filmPaths = lessons.GetValueOrDefault(lbxLessons.SelectedItem.ToString());
                if (File.Exists(filmPaths))
                {
                    mediaElement.Source = new Uri(filmPaths);
                    mediaElement.Play();
                }
            }
        }

        private void btnLoadCourses_Click(object sender, RoutedEventArgs e)
        {
            using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                dialog.RootFolder = Environment.SpecialFolder.Desktop;
                System.Windows.Forms.DialogResult result = dialog.ShowDialog();
                if (result.ToString() == "OK")
                {
                    courseMainPath = dialog.SelectedPath;
                    LoadCourses(courseMainPath);
                }
            }
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            mediaElement.Play();
        }

        private void btnMinus10_Click(object sender, RoutedEventArgs e)
        {
            mediaElement.Position = mediaElement.Position - TimeSpan.FromSeconds(10);
        }

        private void btnPasue_Click(object sender, RoutedEventArgs e)
        {
            mediaElement.Pause();
        }

        private void btnPlus10_Click(object sender, RoutedEventArgs e)
        {
            mediaElement.Position = mediaElement.Position + TimeSpan.FromSeconds(10);
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            mediaElement.Stop();            
        }



        private TimeSpan TotalTime;
        private DispatcherTimer timerVideoTime;

        private void mediaElement_MediaOpened(object sender, RoutedEventArgs e)
        {
            TotalTime = mediaElement.NaturalDuration.TimeSpan;

            // Create a timer that will update the counters and the time slider
            timerVideoTime = new DispatcherTimer();
            timerVideoTime.Interval = TimeSpan.FromSeconds(1);
            timerVideoTime.Tick += new EventHandler(timer_Tick);
            timerVideoTime.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            // Check if the movie finished calculate it's total time
            try
            {
                if (mediaElement.NaturalDuration.TimeSpan.TotalSeconds > 0)
                {
                    if (TotalTime.TotalSeconds > 0)
                    {
                        // Updating time slider
                        if(!sldProgress.IsMouseOver)
                            sldProgress.Value = mediaElement.Position.TotalSeconds / TotalTime.TotalSeconds;
                        lblTime.Content = $"{mediaElement.Position.ToString(@"hh\:mm\:ss")} / {TotalTime.ToString(@"hh\:mm\:ss")}";
                    }
                }
            }
            catch { }
        }


        private void timeSlider_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (TotalTime.TotalSeconds > 0)
            {
                mediaElement.Position = TimeSpan.FromSeconds(sldProgress.Value * TotalTime.TotalSeconds);
            }
        }

        private void btnCloseWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnMaximalizeWindow_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == System.Windows.WindowState.Normal)
                this.WindowState = System.Windows.WindowState.Maximized;
           else if (this.WindowState == System.Windows.WindowState.Maximized)
                this.WindowState = System.Windows.WindowState.Normal;
        }

        private void btnMinimalizeWindow_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Minimized;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void sldVolume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            mediaElement.Volume = sldVolume.Value;
        }
    }
}
