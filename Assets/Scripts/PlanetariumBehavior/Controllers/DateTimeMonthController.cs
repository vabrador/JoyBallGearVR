using UnityEngine;
using WidgetShowcase;
using System;
using System.Collections;
using LMWidgets;

public class DateTimeMonthController : DataBinderDial
{
		// Returns the current toggle state of the data.
		public override string GetCurrentData ()
		{
//				Debug.Log("DateTimeMonthController says:  " + TimeAndLocationHandler.Instance.DateAndTime.Month);
//				Debug.Log("LongDateString: " + TimeAndLocationHandler.Instance.DateAndTime.ToLongDateString());
				return TimeAndLocationHandler.Instance.DateAndTime.Month.ToString();
		}
	
		// Sets the current toggle state of the data.
  protected override void setDataModel (string value)
  {
    if (value == "") {
			return;
		}
		DateTime newDateTime = TimeAndLocationHandler.Instance.DateAndTime;

    try {
			newDateTime = new DateTime (newDateTime.Year, Int32.Parse(value), newDateTime.Day, newDateTime.Hour, newDateTime.Minute, newDateTime.Second);
    }
    catch (ArgumentOutOfRangeException e) {
      Debug.LogWarning("Attempting to set improper date. Exception: " + e);
      return;
    }
		TimeAndLocationHandler.Instance.DateAndTime = newDateTime;

	}
}