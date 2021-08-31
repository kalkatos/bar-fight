using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BarFight
{
	[RequireComponent(typeof(FightingController))]
    public class FighterVisuals : MonoBehaviour
    {
		[SerializeField] private Animator fighterAnimator;

        private FightingController fighterController;

		private void Awake ()
		{
			fighterController = GetComponent<FightingController>();
			fighterController.OnMoveExecuted += MoveExecuted;
		}

		private void OnDestroy ()
		{
			if (fighterController)
				fighterController.OnMoveExecuted -= MoveExecuted;
		}

		private void MoveExecuted (string id)
		{
			fighterAnimator.SetTrigger(id);
		}
	}
}
