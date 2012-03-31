using UnityEngine;
using System.Collections;

public class ColorTester : MonoBehaviour {

	void Start () {
		StartCoroutine ("ColorTest");
	}
	
	IEnumerator ColorTest ()
	{
		yield return new WaitForSeconds (1f);
		GameController gc = (GameController)FindObjectOfType (typeof(GameController));
		gc.ChangeColor (gc.red);
		yield return new WaitForSeconds (1.5f);
		gc.ChangeColor (gc.yellow);
		yield return new WaitForSeconds (1.5f);
		gc.ChangeColor (gc.teal);
	}
}
