using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BarFight
{
	public class EnemyController : Fighter
    {
		[SerializeField] private float findEnemyDelay;
		[SerializeField] private float startFightDelay;
		[SerializeField] private float targetDistance;

        private Fighter targetEnemy;
		private float findEnemyDelayTimer;
		private float startFightDelayTimer;

		protected override void Awake ()
		{
			base.Awake();
			findEnemyDelayTimer = findEnemyDelay;
			startFightDelayTimer = startFightDelay;
		}

		private void FixedUpdate ()
		{
			if (!targetEnemy)
			{
				if (findEnemyDelayTimer > 0)
					findEnemyDelayTimer -= Time.fixedDeltaTime;
				else
				{
					Fighter[] fighters = FindObjectsOfType<Fighter>();
					if (fighters != null)
					{
						Fighter closest = null;
						float closestDistance = float.MaxValue;
						for (int i = 0; i < fighters.Length; i++)
						{
							if (fighters[i] == this)
								continue;
							float currentDistance = Vector3.Distance(fighters[i].transform.position, transform.position);
							if (!closest || currentDistance < closestDistance)
							{
								closest = fighters[i];
								closestDistance = currentDistance;
							}
						}
						targetEnemy = closest;
					}
				}
			}
			else
			{
				Vector2 directionVector = (targetEnemy.transform.position - transform.position).ToVector2XZ();
				float distanceToEnemy = directionVector.magnitude;
				if (distanceToEnemy >= targetDistance)
				{
					movingController.MoveDirection = directionVector.normalized;
				}
				else
				{

				}
			}
		}
	}

	public static class Vector3To2
	{
		public static Vector2 ToVector2XZ (this Vector3 from)
		{
			return new Vector2(from.x, from.z);
		}
	}
}
