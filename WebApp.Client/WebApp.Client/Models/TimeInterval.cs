using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace WebApp.Client.Models
{
    public class TimeInterval
    {
        public string Interval
        {
            get
            {
                return $"{TimeFrom.ToString(@"hh\:mm")} - {TimeTo.ToString(@"hh\:mm")}";
            }
        }
        public TimeSpan TimeFrom { get; set; }
        public TimeSpan TimeTo { get; set; }

        public ObservableCollection<TimeInterval> GetRangeTime(TimeSpan step)
        {
            var times = new ObservableCollection<TimeInterval>();

            for (int i = 0; TimeFrom.Add(TimeSpan.FromTicks(step.Ticks * i)) < TimeTo; i++)
            {
                var timeInterval = new TimeInterval();
                timeInterval.TimeFrom = TimeFrom.Add(TimeSpan.FromTicks(step.Ticks * i));
                timeInterval.TimeTo = timeInterval.TimeFrom.Add(step);
                times.Add(timeInterval);
            }

            return times;
        }

    }
}
