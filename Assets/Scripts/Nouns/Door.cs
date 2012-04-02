using UnityEngine;
using System.Collections;

public class Door : Noun {
	
	public override void CallVerb (string verb)
	{
		switch (verb) {
		case "open":
			if (Inventory.Instance.HasItem ("key")) {
				StartCoroutine ("DoOpen");
			}
			break;
		}
	}
	
	private IEnumerator DoOpen ()
	{
		Debug.Log ("opening");
		while (transform.rotation.eulerAngles.y < 90) {
			transform.Rotate (new Vector3 (0, 1, 0), 100 * Time.deltaTime);
			yield return null;
		}
	}
}
