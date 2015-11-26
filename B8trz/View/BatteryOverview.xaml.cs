using System;
using Windows.ApplicationModel.Background;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using B8trz.Common;
using B8trz.Utility;
using B8trz.ViewModel;

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

            // check if task is already registered
            foreach (var cur in BackgroundTaskRegistration.AllTasks)
                if (cur.Value.Name == myTaskName)
                {
                    //await (new MessageDialog("Task already registered")).ShowAsync();
                    return;
                }

            // Windows Phone app must call this to use trigger types (see MSDN)
            await BackgroundExecutionManager.RequestAccessAsync();

            // register a new task
            BackgroundTaskBuilder taskBuilder = new BackgroundTaskBuilder { Name = "TileBackgroundTask", TaskEntryPoint = "B8trz.Utility.TileBackgroundTask" };
            taskBuilder.SetTrigger(new TimeTrigger(30, false));
            BackgroundTaskRegistration myFirstTask = taskBuilder.Register();

            //await (new MessageDialog("Task registered")).ShowAsync();
        }
    }
}
