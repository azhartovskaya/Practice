using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Xml.Serialization;

namespace src
{
    public partial class SecondWindow : Window
    {
        private const string XmlFilePath = "NameHistory.xml";

        public SecondWindow(string name)
        {
            InitializeComponent();
            GreetingLabel.Content = $"Привет, {name}!";
            UpdateHistory(name);
            LoadHistory();
        }

        private void UpdateHistory(string name)
        {
            var historyEntry = new HistoryEntry { Name = name, DateTime = DateTime.Now };
            List<HistoryEntry> history;

            if (File.Exists(XmlFilePath))
            {
                history = LoadHistoryFromFile();
            }
            else
            {
                history = new List<HistoryEntry>();
            }

            history.Add(historyEntry);
            SaveHistoryToFile(history);
        }

        private List<HistoryEntry> LoadHistoryFromFile()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<HistoryEntry>));
            using (FileStream fs = new FileStream(XmlFilePath, FileMode.Open))
            {
                return (List<HistoryEntry>)serializer.Deserialize(fs);
            }
        }

        private void SaveHistoryToFile(List<HistoryEntry> history)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<HistoryEntry>));
            using (FileStream fs = new FileStream(XmlFilePath, FileMode.Create))
            {
                serializer.Serialize(fs, history);
            }
            HistoryDataGrid.ItemsSource = history;
        }

        private void LoadHistory()
        {
            if (File.Exists(XmlFilePath))
            {
                var history = LoadHistoryFromFile();
                HistoryDataGrid.ItemsSource = history;
            }
        }
    }

    public class HistoryEntry
    {
        public string Name { get; set; }
        public DateTime DateTime { get; set; }
    }
}
