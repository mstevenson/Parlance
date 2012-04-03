using UnityEngine;
using System.Collections;

public class Noun : MonoBehaviour {
	
	public string[] synonyms = new string[1];
	
	public bool takeable;
	public Noun combineWith;

	public bool HasSynonym (string word)
	{
		foreach (string s in synonyms) {
			if (s == word) {
				return true;
			}
		}
		return false;
	}
	
	public virtual void CallVerb (string verb) {
		
	}
}
