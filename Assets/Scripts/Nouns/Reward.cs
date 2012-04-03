using UnityEngine;
using System.Collections;

public class Reward : Noun {
	
	public Color color;
	
	public override void CallVerb (string verb)
	{
//		GameController.Instance.ChangeColor (color);
		switch (verb) {
		case "get":
		case "take":
			World.Instance.ChangeColor (color);
			break;
		}
	}
	
	public void ChangeColor ()
	{
		World.Instance.ChangeColor (color);
	}
}
