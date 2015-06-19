using UnityEngine;
using System.Collections;

public class SlideButton : MonoBehaviour 
{
	public Vector2 minMaxX;

	// Update is called once per frame
	void Update () {
		minMaxX = new Vector2 (transform.position.x, 0f);
		if (minMaxX.x >= 900) 
		{
			minMaxX.x = 900;
		}

		if (minMaxX.x <= -900) 
		{
			minMaxX.x = -900;
		}

		transform.position = minMaxX;
	}
}