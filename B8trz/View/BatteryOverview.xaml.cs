using Windows.UI.Xaml.Controls;
using B8trz.Common;
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
        }
    }
}
