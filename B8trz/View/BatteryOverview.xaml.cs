using System;
using System.Linq;
using Windows.ApplicationModel.Background;
using Windows.UI.Xaml.Controls;
using B8TRZ.Portable.Utility;
using B8TRZ.Portable.ViewModel;

namespace B8trz
{
    public sealed partial class BatteryOverview : Page
    {
        private readonly BatteryOverviewViewModel _viewModel;
        public BatteryOverview()
        {
            this.InitializeComponent();

            _viewModel = new BatteryOverviewViewModel();
            this.DataContext = _viewModel;

            TileHelper.SetupTiles(_viewModel.Battery.BatteryLevelPercentage, _viewModel.Battery.BatteryRemaining);
            TileHelper.SetupBadge(_viewModel.Battery.BatteryLevelPercentage);
            RegisterTileBackgroundTask();
        }

        private async void RegisterTileBackgroundTask()
        {
            string myTaskName = "TileBackgroundTask";
            string taskEntryPoint = "B8TRZ.TileBackgroundTask.TileBackgroundTask";

            // check if task is already registered
            if (BackgroundTaskRegistration.AllTasks.Any(cur => cur.Value.Name == myTaskName))
            {
                return;
            }

            // Windows Phone app must call this to use trigger types (see MSDN)
            await BackgroundExecutionManager.RequestAccessAsync();

            // register a new task
            BackgroundTaskBuilder taskBuilder = new BackgroundTaskBuilder { Name = myTaskName, TaskEntryPoint = taskEntryPoint };
            taskBuilder.SetTrigger(new TimeTrigger(30, false));
            BackgroundTaskRegistration myFirstTask = taskBuilder.Register();

            //await (new MessageDialog("Task registered")).ShowAsync();
        }
    }
}
