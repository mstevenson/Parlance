using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	
	public Camera cam;
	public Renderer ground;
	
	public float transitionSpeed = 1;
	
	public Color defaultColor = new Color (109 / 255f, 124 / 255f, 147 / 255f);
	public Color red = new Color (109 / 255f, 0, 0);
	public Color green = new Color (0, 124 / 255f, 0);
	public Color purple = new Color (109 / 255f, 0, 147 / 255f);
	public Color teal = new Color (0, 124 / 255f, 147 / 255f);
	public Color yellow = new Color (109 / 255f, 124 / 255f, 0);
	
	private Color currentColor;
	
	void Awake ()
	{
		SetColor (defaultColor);
	}
	
	
	public void ChangeColor (Color color)
	{
		StopCoroutine ("DoChange");
		StartCoroutine ("DoChange", color);
	}
	
	private IEnumerator DoChange (Color targetColor)
	{
		Color startColor = currentColor;
		float time = 0;
		while (time < 1 * transitionSpeed) {
			float r = Mathf.Lerp (startColor.r, targetColor.r, time / transitionSpeed);
			float g = Mathf.Lerp (startColor.g, targetColor.g, time / transitionSpeed);
			float b = Mathf.Lerp (startColor.b, targetColor.b, time / transitionSpeed);
			time += Time.deltaTime;
			SetColor (new Color (r, g, b));
			yield return null;
		}
	}
	
	
	void Reset () {
		SetColor (defaultColor);
	}
	
	void SetColor (Color color)
	{
		currentColor = color;
		cam.backgroundColor = color;
		ground.material.color = color;
		RenderSettings.fogColor = color;
	}
	
}
