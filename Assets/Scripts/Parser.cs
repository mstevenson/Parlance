using UnityEngine;
using System.Collections;
using System.Linq;

public class Parser : MonoBehaviour
{	
	TextMesh textMesh;
	Noun[] globalNouns;
	string text = "";
	
	
	void Start ()
	{
		globalNouns = (Noun[])FindSceneObjectsOfType (typeof(Noun));
		
		textMesh = GetComponent<TextMesh> ();
		text = textMesh.text;
	}
	
	
	void Update ()
	{
		if (text.Length > 0 && (Input.GetKeyDown (KeyCode.Backspace) || Input.GetKeyDown (KeyCode.Delete))) {
			text = text.Remove (text.Length - 1, 1);
		} else if (Input.GetKeyDown (KeyCode.Space)) {
			text += " ";
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
		
		// Have a verb
		if (words.Length == 1) {
			string verb = words [0];
		}
		
		// Have a verb and a noun
		if (words.Length == 2) {
			string verb = words [0];
			string noun = words [1];
			
			foreach (Noun n in globalNouns) {
				Debug.Log (n.HasSynonym (noun));
				if (n.HasSynonym (noun)) {
					n.CallVerb (verb);
				}
			}
		}
		
		if (thisText == "i" || thisText == "inventory") {
			
		}
	}
	
}
