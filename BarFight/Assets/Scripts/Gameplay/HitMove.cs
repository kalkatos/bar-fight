using UnityEngine;

namespace BarFight
{
	public class HitMove : FightingMove
	{
        public float Time;
        public Collider2D HitBox;
        public CharacterStance AllowedHitStances;
		public ContactFilter2D Filter;
		public float maxDepth;

		private RaycastHit2D[] hits = new RaycastHit2D[10];

        public override void Execute ()
		{
			//Hit
            int hitAmount = HitBox.Cast(Vector2.zero, Filter, hits, 0.1f);
            if (hitAmount > 0)
			{
				for (int i = 0; i < hitAmount; i++)
				{
					if (Mathf.Abs(hits[i].transform.position.z - transform.position.z) < maxDepth)
					{
						Debug.Log($"Hit {hits[i].collider.name} - normal: {hits[i].normal} - point: {hits[i].point} - distance: {hits[i].distance}");
					}
				}
			}
		}
	}
}
