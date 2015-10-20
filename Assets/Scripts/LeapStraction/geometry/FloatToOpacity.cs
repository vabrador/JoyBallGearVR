using UnityEngine;
using System.Collections;

namespace WidgetShowcase
{
		public class FloatToOpacity : MonoBehaviour
		{

				public FloatEmitter InputEmitter;
				public GameObject Target;

				// Use this for initialization
				void Start ()
				{
						InputEmitter.FloatEvent += HandleFloatEvent;
				}

				void HandleFloatEvent (object sender, LMWidgets.EventArg<float> e)
				{
						if (Target && Target.GetComponent<Renderer>() && Target.GetComponent<Renderer>().material) {
								Color c = Target.GetComponent<Renderer>().material.color;
								c.a = Mathf.Clamp01 (e.CurrentValue);
								Target.GetComponent<Renderer>().material.color = c;
						}
				}
	
				// Update is called once per frame
				void Update ()
				{
	
				}
		}
}
