using UnityEngine;
using WidgetShowcase;
using Stars;
using System;
using System.Collections;
using LMWidgets;

public class StarNameController : DataBinderSlider {
  
  // Returns the current system value of the data.
  public override float GetCurrentData() {
    return StarUpdater.Instance.LabelOpacity;
  }
  
  // Set the current system value of the data.
  protected override void setDataModel(float value) {
    StarUpdater.Instance.SetLabelOpacity(value);
    
  }
}
