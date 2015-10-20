using UnityEngine;
using WidgetShowcase;
using System;
using System.Collections;
using LMWidgets;


public class DateTimeController : DataBinderDial {

	// Returns the current toggle state of the data.
	public override string GetCurrentData() {
		return TimeAndLocationHandler.Instance.DateAndTime.ToString();
	}
	
	// Sets the current toggle state of the data.
	protected override void setDataModel(string value) {
//		TimeAndLocationHandler.Instance.DateAndTime = value;

	}
}