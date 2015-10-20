using UnityEngine;
using WidgetShowcase;
using System;
using System.Collections;
using LMWidgets;

public class StarNameToggleController : DataBinderToggle {
  // Returns the current toggle state of the data.
  public override bool GetCurrentData() {
    return Stars.StarUpdater.Instance.LabelDrawToggle;
  }
  
  // Sets the current toggle state of the data.
  protected override void setDataModel(bool value) {
    Stars.StarUpdater.Instance.SetLabelDrawing(value);
  }
}