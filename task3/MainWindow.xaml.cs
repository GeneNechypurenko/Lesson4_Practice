using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace task3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Event> Events { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Events = new ObservableCollection<Event>();
            eventListView.ItemsSource = Events;
        }

        private void EventCalendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            eventDatePicker.SelectedDate = eventCalendar.SelectedDate;
            eventTitleTextBox.Clear();
            eventDescriptionTextBox.Clear();
        }

        private void AddEventButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime selectedDate = eventCalendar.SelectedDate.GetValueOrDefault();
            string title = eventTitleTextBox.Text;
            string description = eventDescriptionTextBox.Text;

            if (selectedDate != default && !string.IsNullOrWhiteSpace(title))
            {
                Event newEvent = new Event { Date = selectedDate, Title = title, Description = description };
                Events.Add(newEvent);
            }
            else
            {
                MessageBox.Show("Select date");
            }
        }
    }

    public class Event
    {
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}