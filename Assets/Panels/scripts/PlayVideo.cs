using UnityEngine;
using System.Collections;

namespace WidgetShowcase
{
		public class PlayVideo : MonoBehaviour, IBoolEmitter
		{
				public IBoolEmitter CollissionEmitter;
				static PlayVideo PlayingVideo;
				// Use this for initialization
				public GameObject MovieGameObject = null;
				
				public string MovieName;
				

				void Start ()
				{
						if (!MovieGameObject)
								MovieGameObject = gameObject;
						MovieGameObject.GetComponent<Renderer>().enabled = false;
						//if (!(MovieTexture)MovieGameObject.GetComponent<Renderer>().material.mainTexture)
						//		Debug.Log ("No movie in " + name);
				}

				public	void PlayMovie (bool play = true)
				{
						//	Debug.Log ("PlayMovie - setting play of " + name + " to " + (play ? "TRUE" : "FALSE"));
						if (play) {
								if (PlayingVideo != null)
										PlayingVideo.PlayMovie (false);
								GetComponent<Renderer>().enabled = true;
								//MovieGameObject.GetComponent<Renderer>().material.mainTexture = Movie;
				
								//Movie.Play ();
								//GetComponent<AudioSource>().clip = Movie.audioClip;
								//GetComponent<AudioSource>().Play ();
								//PlayingVideo = this;
						} else {
								GetComponent<Renderer>().enabled = false;
								try {
										//Movie.Stop ();
										GetComponent<AudioSource>().Stop ();
								} catch (System.NullReferenceException ex) {
										Debug.LogError ("Missing Video Exception: " + ex);
								}
						}
				}
	
				// Update is called once per frame
				void Update ()
				{
	
				}

		#region IBoolEmitter implementation
				public event System.EventHandler<LMWidgets.EventArg<bool>> BoolEvent;

				bool IsPlaying = false;

				public bool BoolValue {
						get { return IsPlaying; }
						set {
								IsPlaying = value;
								PlayMovie (value); 
								System.EventHandler<LMWidgets.EventArg<bool>> BoolEventHandler = BoolEvent;
								if (BoolEventHandler != null)
										BoolEventHandler (this, new LMWidgets.EventArg<bool> (value));
						}
				}
		#endregion
		}
	
}