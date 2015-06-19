using UnityEngine;
using System.Collections;

public class TouchController : MonoBehaviour 
{
	public float speed = 0.1F;

	Vector2 scrollPos;

	void Update() {
		if(Input.touchCount == 0) return;
		Touch touch = Input.touches[0];
		if (touch.phase == TouchPhase.Moved)
		{
			float dt = Time.deltaTime / touch.deltaTime;
			if (dt == 0 || float.IsNaN(dt) || float.IsInfinity(dt))
				dt = 1.0f;
			Vector2 glassDelta = touch.deltaPosition * dt;
			
			scrollPos.x += glassDelta.x;
		}
	}
}