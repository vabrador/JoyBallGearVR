using UnityEngine;
using WidgetShowcase;
using Stars;
using System;
using System.Collections;
using LMWidgets;

public class LuminenceFilterDataBinder : DataBinderSlider {
  public GameObject Skyglow;
  
  private float m_skyglowBaseAlpha;
  
  
  override protected void Start() {
    if ( Skyglow ) {
      m_skyglowBaseAlpha = Skyglow.GetComponent<Renderer>().material.color.a;
    }
  }
  
  // Returns the current system value of the data.
  override public float GetCurrentData() {
	if (StarUpdater.Instance == null)
	  return 1.0f;
	else
	  return 1.0f - StarUpdater.Instance.MinLuminance;
  }
  
  // Set the current system value of the data.
  override protected void setDataModel(float value) {
    StarUpdater.Instance.SetMinLuminance(1.0f - value);
    
    if ( Skyglow ) {
      float newSkyglowAlpha = m_skyglowBaseAlpha + ((1.0f - value) * (1.0f - m_skyglowBaseAlpha));
      Color temp = Skyglow.GetComponent<Renderer>().material.color;
      temp.a = newSkyglowAlpha;
      Skyglow.GetComponent<Renderer>().material.color = temp;
    }
  }
}
