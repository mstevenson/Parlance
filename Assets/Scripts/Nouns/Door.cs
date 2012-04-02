using UnityEngine;
using System.Collections;

public class Door : Noun {
	
	public GameObject nextSection;
	
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
		nextSection.SetActiveRecursively (true);
		Debug.Log ("opening");
//		GameController.Instance.ChangeColor (GameController.Instance.red);
		while (transform.rotation.eulerAngles.y < 90) {
			transform.Rotate (new Vector3 (0, 1, 0), 100 * Time.deltaTime);
			yield return null;
		}
	}
}
