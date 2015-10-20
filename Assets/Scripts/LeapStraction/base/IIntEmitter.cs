using UnityEngine;
using System;
using System.Collections;

namespace WidgetShowcase
{
		public interface IIntEmitter
		{
				int IntValue { get; set; }

				event EventHandler<LMWidgets.EventArg<int>> IntEvent;
		}

}