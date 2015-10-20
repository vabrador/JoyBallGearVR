using UnityEngine;
using WidgetShowcase;
using Stars;
using System;
using System.Collections;
using LMWidgets;

public class MilkyWayIntensityController : DataBinderSlider {
  [SerializeField]
  private FilterBehavior m_filterBehavior;
	  
  // Returns the current system value of the data.
  public override float GetCurrentData() {
    return m_filterBehavior.MilkyWayIntensity;
  }
  
  // Set the current system value of the data.
  protected override void setDataModel(float value) {
    m_filterBehavior.MilkyWayIntensity = value;
    
  }
  
}