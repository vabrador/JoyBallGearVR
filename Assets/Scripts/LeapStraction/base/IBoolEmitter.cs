using UnityEngine;
using System;
using System.Collections;

namespace WidgetShowcase
{
		public interface IBoolEmitter
		{
				bool BoolValue { get; set; }

				event EventHandler<LMWidgets.EventArg<bool>> BoolEvent;
		}

}