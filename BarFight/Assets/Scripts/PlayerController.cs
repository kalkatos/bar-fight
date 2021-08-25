using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BarFight
{
    [RequireComponent(typeof(MovingController), typeof(FightingController))]
    public class PlayerController : MonoBehaviour
    {
		public FightingMove Punch;

        private MovingController movingController;
		private FightingController fightingController;

		private void Awake ()
		{
			movingController = GetComponent<MovingController>();
			fightingController = GetComponent<FightingController>();
		}

		private void Update ()
		{
			if (Input.GetKeyDown(KeyCode.J))
				fightingController.ExecuteMove(Punch);
		}

		private void FixedUpdate ()
		{
			movingController.MoveDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
		}
	}
}
