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
			Parse (text);
			text = "";
		} else {
			if (!string.IsNullOrEmpty (Input.inputString)) {
				text += Input.inputString.Trim ();
			}
		}
		
		textMesh.text = text;
	}
	
	void Parse (string thisText)
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
			
			Noun nounObject = null;
			foreach (Noun n in globalNouns) {
				if (n.HasSynonym (noun)) {
					nounObject = n;
				}
			}
			if (nounObject != null) {
				if (verb == "take" && nounObject.takeable) {
					Debug.Log ("took " + noun);
					var inv = Inventory.Instance;
					inv.Add (nounObject);
					nounObject.gameObject.SetActiveRecursively (false);
				} else {
					nounObject.CallVerb (verb);
				}
			}
			
		}
		
		if (thisText == "i" || thisText == "inventory") {
			
		}
	}
	
}
