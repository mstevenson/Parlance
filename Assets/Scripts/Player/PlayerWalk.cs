using UnityEngine;
using System.Collections;

public class PlayerWalk : MonoBehaviour {
	
	public float walkSpeed = 1.5f;
	public float slideFriction = 0.5f; // Movement speed multiplier when brushing against objects
	
	private bool collidedLastFrame = false;
	
	private CharacterController character;
	
	
	#region Properties
	
	/// <summary>
	/// Walking speed in meters per second
	/// </summary>
	public float MoveSpeed {
		get { return character.velocity.magnitude; }
	}
	
	/// <summary>
	/// Determine whether the character controller is colliding against one of its sides
	/// </summary>
	public bool IsColliding {
		get { return (character.collisionFlags & CollisionFlags.Sides) == CollisionFlags.Sides; }
	}
	
	#endregion
	
	
	#region Unity Events
	
	private void Awake () {
		character = GetComponent<CharacterController> ();
	}
	
	
	private void Update ()
	{
		Vector3 moveDirection = transform.TransformDirection (Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical"));
		moveDirection *= walkSpeed;
		
		// Apply friction. 0 applies no friction, 1 stops all movement.
		if (collidedLastFrame) {
			float friction = Mathf.Clamp01 (1 - slideFriction);
			if (friction == 0) {
				friction = 0.001f;
				// Must use a small value since 0 fails completely
			}
			moveDirection *= friction;
		}
		
		// If free falling, reduce input-based movement
		if (!character.isGrounded)
			moveDirection *= 0.3f;
		
		// Carry out the move
		character.SimpleMove (moveDirection);
		
		// Record collisions
		collidedLastFrame = IsColliding ? true : false;
	}
	
	#endregion
	
	
	#region Public Methods
	
	/// <summary>
	/// Return the distance from the player to an obstruction directly forward.
	/// </summary>
	public float GetForwardClearance ()
	{
		Vector3 pos = character.transform.position;
		Vector3 capsuleBottom = new Vector3(pos.x, pos.y + character.radius + character.stepOffset, pos.z);
		Vector3 capsuleTop = new Vector3(pos.x, pos.y + character.height - character.radius, pos.z);
		RaycastHit hit;
		Physics.CapsuleCast(capsuleBottom, capsuleTop, character.radius, transform.rotation*Vector3.forward, out hit);
		if (hit.distance == 0)
			return Mathf.Infinity;
		else {
		//	Debug.DrawLine(_trans.position, _trans.position + (_trans.rotation*Vector3.forward*hit.distance));
			return hit.distance;
		}
	}
	
	#endregion
}
