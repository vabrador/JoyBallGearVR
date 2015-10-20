using UnityEngine;
using WidgetShowcase;
using System;
using System.Collections;
using LMWidgets;

public class MilkyWayToggleController : DataBinderToggle {
  [SerializeField]
  private FilterBehavior m_filterBehavior;

  // Returns the current toggle state of the data.
  public override bool GetCurrentData() {
    return m_filterBehavior.DrawMilkyWay;
  }
  
  // Sets the current toggle state of the data.
  protected override void setDataModel(bool value) {
    m_filterBehavior.DrawMilkyWay = value;
    
  }
}