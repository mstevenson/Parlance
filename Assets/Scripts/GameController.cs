using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	
	public Camera cam;
	public Renderer ground;
	
	public Color defaultColor = new Color (109 / 255f, 124 / 255f, 147 / 255f);
	public Color red = new Color (109 / 255f, 0, 0);
	public Color green = new Color (0, 124 / 255f, 0);
	public Color purple = new Color (109 / 255f, 0, 147 / 255f);
	public Color teal = new Color (0, 124 / 255f, 147 / 255f);
	public Color yellow = new Color (109 / 255f, 124 / 255f, 0);
	
	
	void Reset () {
		SetColor (defaultColor);
	}
	
	void SetColor (Color color)
	{
		cam.backgroundColor = color;
		ground.sharedMaterial.color = color;
		RenderSettings.fogColor = color;
	}
	
}
