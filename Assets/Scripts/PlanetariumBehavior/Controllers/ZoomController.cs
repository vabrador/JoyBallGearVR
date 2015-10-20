using UnityEngine;
using WidgetShowcase;
using Stars;
using System;
using System.Collections;
using LMWidgets;

public class ZoomController : DataBinderSlider {
  // Returns the current system value of the data.
  public override float GetCurrentData() {
    return StarUpdater.Instance.Zoom;
  }
  
  // Set the current system value of the data.
  protected override void setDataModel(float value) {
    StarUpdater.Instance.SetZoom(value);

  }
  
}
