using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BarFight
{
    public class PlayerController : Fighter
    {
		private void Update ()
		{
			if (Input.GetKeyDown(KeyCode.J))
				fightingController.ExecuteMove(fightingController.Punch);
		}

		private void FixedUpdate ()
		{
			movingController.MoveDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
		}
	}
}
