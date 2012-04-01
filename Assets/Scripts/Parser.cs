using UnityEngine;
using System.Collections;
using System.Linq;

public class Parser : MonoBehaviour
{
	
	TextMesh textMesh;
	Noun[] nouns;
	
	public string text = "";
	
	
	void Start ()
	{
		nouns = (Noun[])FindSceneObjectsOfType (typeof(Noun));
		
		textMesh = GetComponent<TextMesh> ();
		text = textMesh.text;
	}
	
	
	void Update ()
	{
		if (text.Length > 0 && (Input.GetKeyDown (KeyCode.Backspace) || Input.GetKeyDown (KeyCode.Delete))) {
			text = text.Remove (text.Length - 1, 1);
		} else if (text != "" && (Input.GetKeyDown (KeyCode.KeypadEnter) || Input.GetKeyDown (KeyCode.Return))) {
			Enter (text);
			text = "";
		} else {
			if (!string.IsNullOrEmpty (Input.inputString)) {
				text += Input.inputString.Trim ();
			}
		}
		
		textMesh.text = text;
	}
	
	void Enter (string thisText)
	{
		string[] words = thisText.Split (' ');
		foreach (string word in words) {
			foreach (Noun noun in nouns) {
				if (noun.Equals (word)) {
					Debug.Log (word);
				}
			}
		}
		
		if (thisText == "i" || thisText == "inventory") {
			
		}
	}
	
}
