using UnityEngine;
using System.Collections;

public class Parser : MonoBehaviour {
	
	string text = "";
	
	void OnGUI ()
	{
		text = GUI.TextArea (new Rect (0, Screen.height - 40, Screen.width, 40), text);
	}
	
	
	void Start ()
	{
		
	}
	
}
