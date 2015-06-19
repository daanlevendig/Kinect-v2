using UnityEngine;
using System.Collections;

public class PositionButton : MonoBehaviour 
{	
	public Vector3 posButton;

	private float xPos = 0f, yPos = 0f;

	// Update is called once per frame
	void Update ()
	{
		xPos = (transform.position.x * ((Mathf.Abs (transform.position.x))/(Mathf.Pow((Mathf.Abs (transform.position.x)), 2f)/300)));

		posButton = new Vector3 (xPos, yPos, 0f);
		if (transform.position.x != 0f) 
		{
			transform.localPosition = posButton;
		}
	}
}
