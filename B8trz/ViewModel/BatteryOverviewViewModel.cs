using System;
using B8trz.Model;

namespace B8trz.ViewModel
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
                //BatteryLevelPercentage = new Random().Next(1, 100),
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
