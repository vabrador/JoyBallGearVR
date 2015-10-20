using UnityEngine;
using System;
using System.Collections;

/**
 * this script emits the value of current hand; best used as the basis for a
 * class that pulls hands from a controller and filters out a specific one for a given purpose.
*/

namespace WidgetShowcase
{
		public class HandEmitter : DataEmitter
		{
				public virtual event EventHandler<LMWidgets.EventArg<HandData>> HandEvent;
		
				private HandModel currentHand;
		
				public HandModel CurrentHand {
						get {
								return currentHand;
						}
						set {
								currentHand = value;
								if (currentHand) {

										EmitHand (currentHand);
								} else {
										EmitHand ();
								}
						}
				}
		
				protected void EmitHand (HandModel value = null)
				{
						EventHandler<LMWidgets.EventArg<HandData>> handler = HandEvent;
						if (handler != null) {
								handler (this, new LMWidgets.EventArg<HandData> (new HandData (value)));
						}
				}

		}

}