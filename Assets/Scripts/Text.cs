using UnityEngine;
using System.Collections;

[RequireComponent(typeof(TextMesh))]
[RequireComponent(typeof(MeshRenderer))]
//[ExecuteInEditMode]
public class Text : MonoBehaviour {
	
	public Font font;
	public Color color;
	
	[HideInInspector]
	public Material material;
	
	void Reset ()
	{
		TextMesh mesh = GetComponent<TextMesh> ();
		mesh.text = "Text";
		mesh.anchor = TextAnchor.MiddleCenter;
		mesh.fontSize = 0;
		mesh.tabSize = 0;
		mesh.alignment = TextAlignment.Center;
		mesh.font = font;
		mesh.characterSize = 0.1f;
		
		
//		if (Application.isEditor && !Application.isPlaying) {
//			renderer.sharedMaterial = material;
//			renderer.sharedMaterial.color = color;
//		} else {
//			renderer.material = material;
//			renderer.material.color = color;
//		}
	}
	
	void Awake () {
		
	}
	
}
