using UnityEngine;
using WidgetShowcase;
using Asterisms;
using System;
using System.Collections;
using LMWidgets;


public class AsterismToggleController : DataBinderToggle {


  // Returns the current toggle state of the data.
  public override bool GetCurrentData() {
    return AsterismDrawer.DrawToggle;
  }
  
  // Sets the current toggle state of the data.
  protected override void setDataModel(bool value) {
    if ( value == false )  { AsterismDrawer.TurnOffAsterisms(); } else { AsterismDrawer.TurnOnAsterisms(); }
		
  }
}
