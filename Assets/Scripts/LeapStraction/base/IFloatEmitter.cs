using UnityEngine;
using System;
using System.Collections;

namespace WidgetShowcase
{
		public interface IFloatEmitter
		{
				float FloatValue { get; set; }

				event EventHandler<LMWidgets.EventArg<float>> FloatEvent;
		}

}