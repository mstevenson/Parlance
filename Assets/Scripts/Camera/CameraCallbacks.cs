using UnityEngine;
using System.Collections;

public delegate void CameraCallback ();

/// <summary>
/// Broadcast Unity camera events as standard C# callbacks.
/// </summary>
public class CameraCallbacks : MonoBehaviour {
	
	/// <summary>
	/// Called before a camera culls the scene.
	/// </summary>
	public event CameraCallback PreCullCallback;
	/// <summary>
	/// Called before a camera starts rendering the scene.
	/// </summary>
	public event CameraCallback PreRenderCallback;
	/// <summary>
	/// Called after a camera finished rendering the scene.
	/// </summary>
	public event CameraCallback PostRenderCallback;
	
	
	private void OnPreCull ()
	{
		if (PreCullCallback != null)
			PreCullCallback ();
	}
	
	
	private void OnPreRender ()
	{
		if (PreRenderCallback != null)
			PreRenderCallback ();
	}
	
	
	private void OnPostRender ()
	{
		if (PostRenderCallback != null)
			PostRenderCallback ();
	}
	
}
