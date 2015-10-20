using UnityEngine;
using System.Collections;

namespace WidgetShowcase
{

	public class JoyballZone : MonoBehaviour {

			
		[SerializeField]		
		private bool m_isRHandInZone = false;
		public bool IsRHandInZone { get { return m_isRHandInZone; } }
		private bool IsInteracting = false;
		
		private GameObject target_ = null; // Intersecting object that controls position
		
		public Material ZoneInActiveMat;
		public Material ZoneActiveMat;
		
		public float InitialDepth;
		public float CurrentHoverDepth;
		public float HoverValue;
		
		public HorizonDetector OverEarth;
		
		public Alphan ZoneAlpha;
		public Alphan ZoneOuterAlpha;
    public Alphan JoyballArrows;
		
		public JoystickActiveEmitter joystickActiveEmitter;
		
		public IconManager WristIconManager;
		public HandController handController;
		
    private bool m_isJoyzoneOn = false;
		
		// Use this for initialization
		void Start () {
        JoyzoneOff ();
    }
    
		// Update is called once per frame
		void Update () {
//			if(OverEarth.IsAboveHorizon == false && IsInteracting == false && ModalityManager.Instance.ActiveItemName == ""){
				if(OverEarth.IsAboveHorizon == false && IsInteracting == false && joystickActiveEmitter.Value == false || ModalityManager.Instance.ActiveItemName == "ARMHUD"){
	        if(m_isJoyzoneOn == true){
            //Debug.Log ("JoyzoneOff");
            JoyzoneOff();
            m_isJoyzoneOn = false;
          
          }
			}
//			if(OverEarth.IsAboveHorizon == false && IsInteracting == false && ModalityManager.Instance.ActiveItemName == ""){
				if(OverEarth.IsAboveHorizon == true && IsInteracting == false && joystickActiveEmitter.Value == false && ModalityManager.Instance.ActiveItemName == ""){
          if(m_isJoyzoneOn == false){
            //Debug.Log ("JoyzoneOn");
            JoyzoneOn();	
            m_isJoyzoneOn = true;        
          }
			}
			if (IsInteracting && target_ == null) {
				// Fire OnExt
				IsInteracting = false;
			}
			if (target_ == null)
				return;
			
			if(IsInteracting == true) {	
				CurrentHoverDepth = (target_.transform.position - transform.position).magnitude;
				HoverValue = Mathf.Clamp01(InitialDepth - CurrentHoverDepth);
				SetIconRadius();
//				Debug.Log ("HoverValue = " + HoverValue);
	//			ZoneAlpha.SetAlpha(HoverValue, 0.0f);
//				WristIconManager.IconOffsetDistance = Mathf.Lerp(.04f, 3.0f, .01f);
			}
		}
		
		// Ensure that the icon remains above the JoyBall surface
		private void SetIconRadius() {
			// REQUIRE: this.transform.parent is HandController
			if (handController == null) {
			  return;
			}
			HandModel hand = GetHandFromFingerBone (target_.transform);
			if (hand == null) {
				return;
			}
			SphereCollider ball = GetComponent<SphereCollider>();
			if (ball == null) {
				return;
			}

			// MATH: The following derives the radius sufficient for the icon
			// to float above the surface of the sphere
			Vector3 ballLeapCenter = transform.TransformPoint (ball.center);
			Vector3 palmLeapTo = hand.palm.position - ballLeapCenter;
			if (!(ball.radius * ball.radius > palmLeapTo.sqrMagnitude)) {
				WristIconManager.IconOffsetDistance = 0.04f;
				return;
			}
			Vector3 palmLeapUp = -hand.GetPalmNormal();
			float pCos = Vector3.Dot(palmLeapTo, palmLeapUp);
			// RESULT: rSurfTo is the distance in the up direction to the sphere surface
			float rSurfTo = Mathf.Sqrt(ball.radius * ball.radius - (palmLeapTo.sqrMagnitude - pCos * pCos)) - pCos;
			// RESULT: planeAdd is the additional distance needed to ensure that 
			// a plane perpendicular to palmWolrdUp does not intersect the sphere surface
			float planeAdd = ball.radius - pCos - rSurfTo;

			// Ensure that icon remains above ball surface
			if (rSurfTo + planeAdd > 0.04f) {
				WristIconManager.IconOffsetDistance = rSurfTo + planeAdd;
			} else {
				WristIconManager.IconOffsetDistance = 0.04f;
			}
		}

		private HandModel GetHandFromFingerBone (Transform target) {
			// WARNING: This relies on the collider hierarchy to identify hands
			if (target.parent && 
			    target.parent.parent) {
				return target.parent.parent.GetComponent<HandModel> ();
			}
			return null;
		}
		
		private bool IsHand (Collider other)
		{
			return GetHandFromFingerBone (other.transform) != null;
		}
		
		void OnTriggerEnter (Collider other)
		{
			if (target_ == null && IsHand (other) && joystickActiveEmitter.Value == false) {
				target_ = other.gameObject;

				m_isRHandInZone = true;
//				if (dialGraphics)
//					dialGraphics.HiLightDial ();
				InitialDepth = (target_.transform.position - transform.position).magnitude;
				IsInteracting = true;
				StopAllCoroutines();
				// FIX THIS: 0.12f is the sphere radius.
				// GOAL ensure that the icon is 0.04f above the *sphere* surface
				//StartCoroutine(LerpIconOffset(.12f));
				WristIconManager.ToggleGrabIconCycle(true);
			}
//			gameObject.GetComponent<Renderer>().material = ZoneActiveMat;
			
		}
		
		void OnTriggerExit (Collider other)
		{
			if (other.gameObject == target_) {
				target_ = null;
				m_isRHandInZone = false;
				IsInteracting = false;
				StopAllCoroutines();
				StartCoroutine(LerpIconOffset(0.04f));
				WristIconManager.ToggleGrabIconCycle(false);
				
			}
//			gameObject.GetComponent<Renderer>().material = ZoneInActiveMat;
		}
		private IEnumerator LerpIconOffset (float destOffset) {
//			Debug.Log("Lerp wrist Icon");
			float duration = 2.0f;
			float elapsedTime = 0f;
			while(elapsedTime < duration){
				WristIconManager.IconOffsetDistance = Mathf.Lerp(WristIconManager.IconOffsetDistance, destOffset, elapsedTime / duration);
				elapsedTime += Time.deltaTime;
				yield return null;
			}
		}
    
    public void JoyzoneOn (){
//      m_isJoyzoneOn = true;
      ZoneAlpha.SetAlpha(0.1f, 0.5f);
      ZoneOuterAlpha.SetAlpha(0.5f, 0.5f);
      JoyballArrows.SetAlpha(0.1f, 0.5f); 
      Collider[] colliders = GetComponentsInChildren<Collider>();
      foreach(Collider c in colliders){
        c.enabled = true;
      } 
    }
    public void JoyzoneOff () {
//      m_isJoyzoneOn = false;
      ZoneAlpha.SetAlpha(0.0f, 0.5f);
      ZoneOuterAlpha.SetAlpha(0.0f, 0.5f);
      JoyballArrows.SetAlpha(0.0f, 0.5f); 
      Collider[] colliders = GetComponentsInChildren<Collider>();
      foreach(Collider c in colliders){
        c.enabled = false;
      }
    }
  }
}
