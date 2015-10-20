using UnityEngine;
using System;
using System.Collections;

namespace WidgetShowcase
{
		public class FloatEmitter : DataEmitter
		{
		
				public virtual event EventHandler<LMWidgets.EventArg<float>> FloatEvent;
		
				private float floatValue;
		
				public float FloatValue {
						get {
								return floatValue;
						}
						set {
								if (DontEmitUnchangedValue && (value == floatValue))
										return;
								floatValue = value;
								EventHandler<LMWidgets.EventArg<float>> handler = FloatEvent;
								if (handler != null) {
										handler (this, new LMWidgets.EventArg<float> (value));
								}
						}
				}
		
		}
	
}
