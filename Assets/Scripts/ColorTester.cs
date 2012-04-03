using UnityEngine;
using System.Collections;

public class ColorTester : MonoBehaviour {

	void Start () {
		StartCoroutine ("ColorTest");
	}
	
	IEnumerator ColorTest ()
	{
		yield return new WaitForSeconds (1f);
		World w = (World)FindObjectOfType (typeof(World));
		w.ChangeColor (w.red);
		yield return new WaitForSeconds (1.5f);
		w.ChangeColor (w.yellow);
		yield return new WaitForSeconds (1.5f);
		w.ChangeColor (w.teal);
	}
}
