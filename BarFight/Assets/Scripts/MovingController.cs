using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace BarFight
{
	[RequireComponent(typeof(Rigidbody2D), typeof(SortingGroup))]
    public class MovingController : MonoBehaviour
    {
		public float Speed;
        [HideInInspector] public Vector2 MoveDirection;

		private bool canMove;
		private Rigidbody2D rb;
		private SortingGroup sortingGroup;
        private Animator animator;

        private void Awake ()
		{
			rb = GetComponent<Rigidbody2D>();
			sortingGroup = GetComponent<SortingGroup>();
			animator = GetComponentInChildren<Animator>();
		}

		private void Start ()
		{
			canMove = true; //TODO Move to the correct position
		}

		private void Update ()
		{
			sortingGroup.sortingOrder = Mathf.RoundToInt(transform.position.y * -100);
		}

		private void FixedUpdate ()
		{
			SetZPosition();
			if (canMove)
				rb.velocity = MoveDirection * Speed;
			else
				rb.velocity = Vector2.zero;

			updateAnimation(rb.velocity);
			faceWalkingDirection(rb.velocity);
		}

        private void faceWalkingDirection(Vector2 velocity)
        {
			Vector3 charecterScale = transform.localScale;
			if (velocity.x < 0)
			{
				charecterScale.x = -1;
			}
			if (velocity.x > 0)
			{
				charecterScale.x = 1;
			}
			transform.localScale = charecterScale;
		}

        private void updateAnimation(Vector2 velocity)
        {
			if (animator == null) return;

			animator.SetFloat("speed", Mathf.Abs(velocity.x) + Mathf.Abs(velocity.y));
        }

        private void SetZPosition ()
		{
			Vector3 pos = transform.position;
			pos.z = pos.y;
			transform.position = pos;
		}
	}
}