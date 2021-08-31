using UnityEngine;

namespace BarFight
{
	public abstract class FightingMove : MonoBehaviour
	{
		public string Id;
        public abstract void Execute ();
	}
}
