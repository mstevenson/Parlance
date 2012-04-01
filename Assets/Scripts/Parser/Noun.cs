using UnityEngine;
using System.Collections;

public class Noun : MonoBehaviour {
	
	public string[] synonyms = new string[1];
	
	public bool takeable = true;
	public Noun combineWith;

	public override bool Equals (object obj)
	{
		if (obj is string) {
			string target = (string)obj;
			bool matched;
			foreach (string s in synonyms) {
				if (s == target) {
					return true;
				}
			}
			return false;
		} else {
			return base.Equals (obj);
		}
	}
}
