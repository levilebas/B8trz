using Windows.ApplicationModel.Background;
using B8TRZ.Portable.Utility;
using B8TRZ.Portable.ViewModel;

namespace B8TRZ.TileBackgroundTask
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
