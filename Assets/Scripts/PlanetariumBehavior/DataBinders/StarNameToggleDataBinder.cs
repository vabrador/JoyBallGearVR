using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using LMWidgets;
using Asterisms;

public class StarNameToggleDataBinder : DataBinderToggle {
  [SerializeField] 
  SliderDemo slider;
  
  override public bool GetCurrentData() {
	if (Stars.StarUpdater.Instance == null)
		return true;
	else
	    return Stars.StarUpdater.Instance.LabelDrawToggle;
  }
  
  override protected void setDataModel(bool value) { 
    Stars.StarUpdater.Instance.SetLabelDrawing(value);
    slider.Interactable = value;
    
  }
}