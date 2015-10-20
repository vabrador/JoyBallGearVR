using UnityEngine;
using System;
using System.Collections;

namespace WidgetShowcase
{
		public class BoolEmitter : DataEmitter, IBoolEmitter
		{
				public virtual event EventHandler<LMWidgets.EventArg<bool>> BoolEvent;

				public bool Value;

				public bool BoolValue {
						get {
								return Value;
						}
						set {
				if (DontEmitUnchangedValue && (Value == value))
										return;

								Value = value;
								EmitValue (Value);
						}
				}

// this should generally only be triggered by BoolValue changes, with the possible exception of emitOnStart;
				protected void EmitValue (bool value)
				{
						//		Debug.Log (string.Format ("BoolEmitter {0}({2}) emitting {1}", name, value, (this.GetType ())));
						EventHandler<LMWidgets.EventArg<bool>> handler = BoolEvent;
						if (handler != null) {
								handler (this, new LMWidgets.EventArg<bool> (value));
						}
				}

				protected virtual void Start ()
				{
						if (EmitOnStart)
								EmitValue (BoolValue);
				}
		}

}