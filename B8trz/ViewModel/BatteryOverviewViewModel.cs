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
                BatteryRemaining = GetBatteryRemaining()
            };
        }

        private int GetBatteryLevelPercentage()
        {
            return _battery.RemainingChargePercent;
        }

        private int GetBatteryRemaining()
        {
            return (int)_battery.RemainingDischargeTime.TotalMinutes;
        }
    }
}
