using UnityEngine;
using WidgetShowcase;
using System;
using System.Collections;
using LMWidgets;

public class DateTimeYearController : DataBinderDial {
	// Returns the current toggle state of the data.
	public override string GetCurrentData() {
		return TimeAndLocationHandler.Instance.DateAndTime.Year.ToString();
	}
	
	// Sets the current toggle state of the data.
	protected override void setDataModel(string value) {
    if ( value == "" ) { return; }
		DateTime newDateTime = TimeAndLocationHandler.Instance.DateAndTime;

    try {
			newDateTime = new DateTime(Int32.Parse(value), newDateTime.Month, newDateTime.Day, newDateTime.Hour, newDateTime.Minute, newDateTime.Second);
    }
    catch (ArgumentOutOfRangeException e) {
      Debug.LogWarning("Attempting to set improper date. Ignoring. Exception: " + e);
      return;
    }

		TimeAndLocationHandler.Instance.DateAndTime = newDateTime;
	}
}