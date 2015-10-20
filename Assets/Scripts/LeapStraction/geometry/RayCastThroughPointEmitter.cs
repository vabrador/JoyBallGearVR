using UnityEngine;
using System.Collections;

namespace WidgetShowcase
{
		public class RayCastThroughPointEmitter : RayCastEmitter
		{

				public PointEmitter targetEmitter;

				// Use this for initialization
				override protected void Start ()
				{
						targetEmitter.PointEvent += HandlePointEvent;
				}

				void HandlePointEvent (object sender, LMWidgets.EventArg<PointData> e)
				{
						if (e.CurrentValue.HasData) {
								BoolValue = RayCheck (e.CurrentValue.Point);
						}
				}
		}

}