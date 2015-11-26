using System;
using Windows.ApplicationModel.Background;
using Windows.UI.Popups;
using B8trz.ViewModel;

namespace B8trz.Utility
{
    public sealed class TileBackgroundTask : IBackgroundTask
    {
        public void Run(IBackgroundTaskInstance taskInstance)
        {
            BatteryOverviewViewModel viewModel = new BatteryOverviewViewModel();
            TileHelper.SetupTiles(viewModel.Battery.BatteryLevelPercentage, viewModel.Battery.BatteryRemaining);
            TileHelper.SetupBadge(viewModel.Battery.BatteryLevelPercentage);
        }
    }
}
