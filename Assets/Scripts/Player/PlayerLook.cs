using UnityEngine;
using System.Collections;

/* 
 * Instructions:
 *   Add PlayerLook to the main camera object.
 * 
 * Scene Hierarchy:
 * 
 *   Player
 *      Camera <-- PlayerLook
 */

/// <summary>
/// Controller for 1st person camera look.
/// </summary>
public class PlayerLook : MonoBehaviour {
	
	/// <summary>
	/// Mouse movement sensitivity
	/// </summary>
	public float sensitivity = 5;
	/// <summary>
	/// Minimum downward look angle. -90 is looking straight down.
	/// </summary>
	public float minimumTilt = -60;
	/// <summary>
	/// Maximum upward look angle. 90 is looking straight up.
	/// </summary>
	public float maximumTilt = 60;
	/// <summary>
	/// Force that pulls the camera into its target orientation.
	/// </summary>
	public float lookSpringForce = 100;
	/// <summary>
	/// Damping of the force that pulls the camera into its target orientation.
	/// </summary>
	public float lookSpringDamper = 4;
	/// <summary>
	/// Force that pulls the camera toward its target position.
	/// </summary>
	public float moveSpringForce = 50;
	/// <summary>
	/// Damping of the force that pulls the camera toward its target position.
	/// </summary>
	public float moveSpringDamper = 4;
	
	// Cached and temp values
	private Transform body;
	private Vector2 lookTarget;
	private Quaternion xQuat = Quaternion.identity;
	private Quaternion yQuat = Quaternion.identity;
	
	private bool initialized = false;
	
	Transform camTarget;
	ConfigurableJoint camJoint;
	
	
	public static Vector2 Look {
		get {
			// Mouse input
			float mouseX = Input.GetAxis ("Mouse X");
			float mouseY = Input.GetAxis ("Mouse Y");
			// Controller joystick input
//			float controllerX = Input.GetAxis ("Horizontal2") * 40 * Time.deltaTime;
//			float controllerY = Input.GetAxis ("Vertical2") * 40 * Time.deltaTime;
//			return new Vector2 (mouseX + controllerX, mouseY + controllerY);
			return new Vector2 (mouseX, mouseY);
		}
	}
	
	
	
	#region Unity Events
	
	private void Awake ()
	{
		Screen.lockCursor = true;
	}
	
	
	private void Start ()
	{
		body = transform.parent;
		
		// Record initial player rotation
		lookTarget.x = body.rotation.eulerAngles.y;
		
		// Create a target object for the main camera to pull toward
		camTarget = new GameObject ("Cam Target").transform;
		camTarget.parent = transform.parent;
		camTarget.position = transform.position;
		camTarget.rotation = transform.rotation;
		
		// Pop the camera out of the hierarchy so that it will drag behind the player body
		transform.parent = null;
		
		// Set up target rigidbody
		Rigidbody targetRigidbody = camTarget.gameObject.AddComponent<Rigidbody> ();
		targetRigidbody.useGravity = false;
		targetRigidbody.isKinematic = true;
		
		// Set up camera rigidbody
		Rigidbody camRigidbody = camera.gameObject.AddComponent<Rigidbody> ();
		camRigidbody.useGravity = false;
		
		// Create a soft spring joint attaching the camera to the cam target
		camJoint = gameObject.AddComponent<ConfigurableJoint> ();
		camJoint.rotationDriveMode = RotationDriveMode.Slerp;
		camJoint.connectedBody = targetRigidbody;
		
		// Set joint translation forces
		JointDrive drive = new JointDrive ();
		drive.mode = JointDriveMode.Position;
		drive.positionSpring = moveSpringForce;
		drive.positionDamper = moveSpringDamper;
		drive.maximumForce = Mathf.Infinity;
		camJoint.xDrive = drive;
		camJoint.yDrive = drive;
		camJoint.zDrive = drive;
	}
	
	
	private void Update ()
	{
		// FIXME Unity 3 doesn't register changes to Slerp Drive when set programatically during Start
		// So, we need to set it again at the beginning of Update.
		if (!initialized) {
			JointDrive drive = new JointDrive ();
			drive.mode = JointDriveMode.Position;
			drive.positionSpring = lookSpringForce;
			drive.positionDamper = lookSpringDamper;
			drive.maximumForce = 1000;
			camJoint.slerpDrive = drive;
		}
		
		// Smoothly adjust the camera target rotation
		
		lookTarget += Look * sensitivity;
		
		// Limit max upward/downward tilt angle
		lookTarget.y = ClampAngle (lookTarget.y, minimumTilt, maximumTilt);
		xQuat = Quaternion.AngleAxis (lookTarget.x, Vector3.up);
		yQuat = Quaternion.AngleAxis (lookTarget.y, Vector3.left);
		
		// Tilt cam target
		camTarget.localRotation = yQuat;
		// Spin body
		body.rotation = xQuat;
	}
	
	#endregion
	
	
	#region Helper Methods
	
	private float ClampAngle (float angle, float min, float max)
	{
		if (angle < -360f)
			angle += 360f;
		if (angle > 360f)
			angle -= 360f;
		return Mathf.Clamp(angle, min, max);
	}
	
	#endregion

}
