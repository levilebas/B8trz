using System;
using Battery = B8TRZ.Portable.Model.Battery;

namespace B8TRZ.Portable.ViewModel
{
    public class BatteryOverviewViewModel
    {
        private readonly Windows.Phone.Devices.Power.Battery _battery;
        public Battery Battery { get; set; }

        public BatteryOverviewViewModel()
        {
            _battery = Windows.Phone.Devices.Power.Battery.GetDefault();
            Battery = new Battery
            {
                BatteryLevelPercentage = GetBatteryLevelPercentage(),
                BatteryRemaining = GetBatteryRemaining()
            };
        }

        private int GetBatteryLevelPercentage()
        {
            return _battery.RemainingChargePercent;
        }

        private string GetBatteryRemaining()
        {
            TimeSpan remaining = _battery.RemainingDischargeTime;
            return string.Format("{0}h:{1}m", remaining.Hours, remaining.Minutes);
        }
    }
}
