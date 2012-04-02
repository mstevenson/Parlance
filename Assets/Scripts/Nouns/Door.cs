using UnityEngine;
using System.Collections;

public class Door : Noun {
	
	public override void CallVerb (string verb)
	{
		switch (verb) {
		case "open":
			Debug.Log ("opening");
			StartCoroutine ("DoOpen");
			break;
		}
	}
	
	private IEnumerator DoOpen ()
	{
		while (transform.rotation.eulerAngles.y < 90) {
			
//			yield return null;
		}
	}
}
