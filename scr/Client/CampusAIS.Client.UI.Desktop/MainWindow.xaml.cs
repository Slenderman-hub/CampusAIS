using System.Windows;
using CampusAIS.Client.Core.BusinessLogic;
using CampusAIS.Client.Data.ApiClient;

namespace CampusAIS.Client.UI.Desktop
{
    public partial class MainWindow : Window
    {
        private readonly IScheduleService _scheduleService;

        public MainWindow()
        {
            InitializeComponent();
            // Ручная инъекция зависимости для простоты
            _scheduleService = new ScheduleService(new ScheduleApiClient(new System.Net.Http.HttpClient()));
        }

        private async void LoadSchedule_Click(object sender, RoutedEventArgs e)
        {
            var schedule = await _scheduleService.GetScheduleAsync();
            if (schedule != null)
            {
                ScheduleGrid.ItemsSource = schedule.Lessons;
            }
        }
    }
}