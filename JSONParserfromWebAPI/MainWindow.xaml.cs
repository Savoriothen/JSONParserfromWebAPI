using System.Net;
using System.Runtime.Serialization.Formatters;
using Newtonsoft.Json;
using JSONParserfromWebAPI.JsonTypes;
using System.Timers;
using System.Collections.Generic;

namespace JSONParserfromWebAPI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        #region Instance Properties
        /*Set JsonSerializerSettings:
         * TypeNameHandling.All therefor : Always include the .NET type name when serializing.
         * TypeNameAssemblyFormat = FormatterAssemblyStyle.Full:
         * the assembly used during deserialization need not match exactly the assembly used during serialization.
         */
        private JsonSerializerSettings _jsonSettings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All,
            TypeNameAssemblyFormat = FormatterAssemblyStyle.Full
        };
        private readonly Timer _refreshTimer;
        RootObject root = new RootObject();
        #endregion

        #region Instance Methods

        public MainWindow()
        {
            InitializeComponent();

            //refresh timer refreshing every minute
            _refreshTimer = new Timer(60000);
            _refreshTimer.AutoReset = false;
            SetTimer();
            // Download string via webcilent
            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString("http://www.bbc.co.uk/radio4/programmes/schedules/fm/today.json");
                //Deserialize json with Newtonsoft JsonConvert
                root = JsonConvert.DeserializeObject<RootObject>(json, _jsonSettings);
            }
            //Only Use Broadcast list, because it contains the programs
            Broadcasts.ItemsSource = root.schedule.day.broadcasts;

        }
        private void SetTimer()
        {
            //Setting up timer
            //Timer started
            _refreshTimer.Elapsed += OnTimerTickerControllerElapsed;
            _refreshTimer.Start();
        }
        private void OnTimerTickerControllerElapsed(object sender, ElapsedEventArgs e)
        {
            lock (_refreshTimer)
            {

                try
                {
                    //refresh root
                    using (WebClient wc = new WebClient())
                    {

                        // Download string via webcilent
                        var json = wc.DownloadString("http://www.bbc.co.uk/radio4/programmes/schedules/fm/today.json");
                        // Deserialize json with Newtonsoft JsonConvert
                        root = JsonConvert.DeserializeObject<RootObject>(json, _jsonSettings);
                    }

                }
                finally
                {
                    _refreshTimer.Start();
                }
            }
        }
        #endregion
    }

}