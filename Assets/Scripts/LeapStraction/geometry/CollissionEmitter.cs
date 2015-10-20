using UnityEngine;
using System;
using System.Collections;

namespace WidgetShowcase
{
		public class CollissionEmitter : DataEmitter, IBoolEmitter
		{

#region loop
				void Start ()
				{
						DontEmitUnchangedValue = true;
				}
#endregion

				public GameObjectValidator TargetValidator = null;

				void OnCollisionEnter (Collision collision)
				{
						if (TargetValidator != null && !TargetValidator.Test (collision.gameObject))
								return;

						BoolValue = true;
				}

				public virtual event EventHandler<LMWidgets.EventArg<bool>> BoolEvent;

				public bool boolValue;

				public bool BoolValue {
						get {
								return boolValue;
						}
						set {
								if (DontEmitUnchangedValue && boolValue == value)
										return;
								boolValue = value;
								EventHandler<LMWidgets.EventArg<bool>> handler = BoolEvent;
								if (handler != null) {
										handler (this, new LMWidgets.EventArg<bool> (value));
								}
						}
				}

		}

}