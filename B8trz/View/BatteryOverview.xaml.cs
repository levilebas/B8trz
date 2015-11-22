using Windows.UI.Xaml.Controls;
using B8trz.Common;
using B8trz.ViewModel;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace B8trz
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
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

        public BatteryOverviewViewModel ViewModel
        {
            get
            {
                return _viewModel;
            }
        }
    }
}
