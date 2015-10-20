using UnityEngine;
using WidgetShowcase;
using System;
using System.Collections;
using LMWidgets;


public class DateTimeDayController : DataBinderDial {

  // Returns the current toggle state of the data.
  public override string GetCurrentData() {
    return TimeAndLocationHandler.Instance.DateAndTime.Day.ToString();
  }
  
  // Sets the current toggle state of the data.
  protected override void setDataModel(string value) {
	if ( value == "" || TimeAndLocationHandler.Instance) { return; }
    DateTime newDateTime = TimeAndLocationHandler.Instance.DateAndTime;
    try {
      newDateTime = new DateTime(newDateTime.Year, newDateTime.Month, Int32.Parse(value), newDateTime.Hour, newDateTime.Minute, newDateTime.Second);
    }
    catch (ArgumentOutOfRangeException e) {
	  Debug.LogWarning("Attempting to set improper date: " + newDateTime + " Ignoring: " + e.Message);
      return;
    }

    TimeAndLocationHandler.Instance.DateAndTime = newDateTime;

  }
}