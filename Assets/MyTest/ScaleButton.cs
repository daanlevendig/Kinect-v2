using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScaleButton : MonoBehaviour 
{
	public Vector3 scaleButton;
	public RectTransform button;
	private float xScale = 1f, yScale = 1f;

	// Update is called once per frame
	void Update () 
	{
		xScale = -Mathf.Abs (transform.position.y / 750) + 1;
		yScale = -Mathf.Abs (transform.position.y / 750) + 1;

		if (yScale >= 1f) {
			xScale = 1f;
			yScale = 1f;
			button.SetAsLastSibling();
		} 
		else button.SetAsFirstSibling();

		scaleButton = new Vector3 (xScale, yScale, 0f);
		if(transform.position.y != 0f)
		{
			transform.localScale = scaleButton;
		}
	}
}
