using UnityEngine;
using System.Collections;

public class Reward : Noun {
	
	public Color color;
	
	public override void CallVerb (string verb)
	{
		Debug.Log ("qwerqwer");
		switch (verb) {
		case "take":
//			GameController.Instance.ChangeColor (color);
			break;
		}
	}
	
	public void ChangeColor ()
	{
		GameController.Instance.ChangeColor (color);
	}
}
