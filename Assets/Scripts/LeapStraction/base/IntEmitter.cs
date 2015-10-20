using UnityEngine;
using System;
using System.Collections;

namespace WidgetShowcase
{
		public class IntEmitter : DataEmitter, IIntEmitter
		{
		
				public virtual event EventHandler<LMWidgets.EventArg<int>> IntEvent;
		
				private int intValue;
		
				public int IntValue {
						get {
								return intValue;
						}
						set {
								if (DontEmitUnchangedValue && (value == intValue))
										return;
								intValue = value;
								EventHandler<LMWidgets.EventArg<int>> handler = IntEvent;
								if (handler != null) {
										handler (this, new LMWidgets.EventArg<int> (value));
								}
						}
				}
		
		}
	
}
