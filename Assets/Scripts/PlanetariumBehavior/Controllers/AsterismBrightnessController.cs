using UnityEngine;
using WidgetShowcase;
using Stars;
using System;
using System.Collections;
using LMWidgets;

public class AsterismBrightnessController : DataBinderSlider {

  // Returns the current system value of the data.
  public override float GetCurrentData() {
    return Asterisms.AsterismDrawer.Brightness;
  }
  
  // Set the current system value of the data.
protected override void setDataModel(float value) {
    Asterisms.AsterismDrawer.SetAsterismOpacity(value);
  }

}
