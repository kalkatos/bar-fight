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

		private void Awake ()
		{
			rb = GetComponent<Rigidbody2D>();
			sortingGroup = GetComponent<SortingGroup>();
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
		}

		private void SetZPosition ()
		{
			Vector3 pos = transform.position;
			pos.z = pos.y;
			transform.position = pos;
		}
	}
}