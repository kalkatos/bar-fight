using UnityEngine;

namespace BarFight
{
	[RequireComponent(typeof(MovingController), typeof(FightingController))]
	public class Fighter : MonoBehaviour
	{
		protected MovingController movingController;
		protected FightingController fightingController;

		protected virtual void Awake ()
		{
			movingController = GetComponent<MovingController>();
			fightingController = GetComponent<FightingController>();
		}
	}
}
