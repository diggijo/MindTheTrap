using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class CharacterController2D : MonoBehaviour
{
	[SerializeField] private GameHandler gh;
	[SerializeField] private PlayerMovement pm;
	[SerializeField] private LayerMask groundLayer;
	[SerializeField] private Transform groundCheck;

	const float groundedRadius = .2f;
	internal bool isGrounded;
	internal bool isDead;
	private Rigidbody2D rb;

	public UnityEvent OnLandEvent;

	[System.Serializable]
	public class BoolEvent : UnityEvent<bool> { }

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();

		if (OnLandEvent == null)
			OnLandEvent = new UnityEvent();
	}

	private void FixedUpdate()
	{
		bool wasGrounded = isGrounded;
		isGrounded = false;

		Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundedRadius, groundLayer);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
				isGrounded = true;
				if (!wasGrounded)
					OnLandEvent.Invoke();
			}
		}

		if(isDead)
        {
			pm.enabled = false;
        }
	}
}
