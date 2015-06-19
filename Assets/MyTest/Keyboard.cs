using UnityEngine;

public class Keyboard : MonoBehaviour
{
	// drag an object with a TextMesh here, in Unity's inspector
	public TextMesh TextObject;
	
	private TouchScreenKeyboard keyboard;
	private string text = "Starting text!";
	
	void OnGUI()
	{
		// "Open" has several arguments. If you want special functionality, see
		// http://docs.unity3d.com/ScriptReference/TouchScreenKeyboard.Open.html
		
		if (GUI.Button(new Rect(10, 10, 300, 50), "Open Keyboard"))
		{
			if (keyboard == null) {
				keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.EmailAddress, false, false, false, false, "Username:");
			}
			keyboard.active = true;
		}
	}
	
	void Update()
	{
		// for each character inserted this frame
		foreach (char c in Input.inputString)
		{
			if (c == '\b' && text.Length > 0)
			{
				// backspace: remove last char
				text = text.Substring(0, text.Length - 1);
			}
			else if (c == '\n' || c == '\r')
			{
				// New line ("Enter" was pressed).
				// Possibly handle it as "confirm", or do "text += c" for multiline text.
			}
			else
			{
				// add any other char to the string
				text += c;
			}
		}
		TextObject.text = text;
	}
}