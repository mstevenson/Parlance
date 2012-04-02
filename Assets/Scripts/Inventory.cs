using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {
	
	[HideInInspector]
	private List<Noun> items = new List<Noun> ();
	
	public static Inventory Instance {
		get { return (Inventory)FindObjectOfType (typeof(Inventory)); }
	}
	
	
	public void Add (Noun noun)
	{
		items.Add (noun);
	}
	
	public void Remove (Noun noun)
	{
		items.Remove (noun);
	}
	
	public bool HasItem (Noun noun)
	{
		foreach (var n in items) {
			if (n == noun)
				return true;
		}
		return false;
	}
	
	public bool HasItem (string noun)
	{
		foreach (var n in items) {
			foreach (string s in n.synonyms) {
				if (s == noun)
					return true;
			}
		}
		return false;
	}
}
