using UnityEngine;
using WidgetShowcase;
using System;
using System.Collections;
using LMWidgets;

public class DateTimeHourController : DataBinderDial {
  // Returns the current toggle state of the data.
  public override string GetCurrentData() {
    return TimeAndLocationHandler.Instance.DateAndTime.Hour.ToString();
  }
  
  // Sets the current toggle state of the data.
  protected override void setDataModel(string value) {
    DateTime newDateTime = TimeAndLocationHandler.Instance.DateAndTime;
    try {
			newDateTime = new DateTime(newDateTime.Year, newDateTime.Month, newDateTime.Day, Int32.Parse(value), newDateTime.Minute, newDateTime.Second);
    }
    catch (ArgumentOutOfRangeException e) {
      Debug.LogWarning("Attempting to set improper date. Ignoring: " + e.Message);
      return;
    }
    TimeAndLocationHandler.Instance.DateAndTime = newDateTime;
  }
}