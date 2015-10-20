using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using LMWidgets;
using WidgetShowcase;
using Stars;

public class StarSaturationDataBinder : DataBinderSlider
{
  
	override public float GetCurrentData ()
	{
		if (StarUpdater.Instance == null)
			return 0;
		else
			return StarUpdater.Instance.Saturation;
	}
  
	override protected void setDataModel (float value)
	{
		StarUpdater.Instance.SetStarSaturation (value);    
	}
}

