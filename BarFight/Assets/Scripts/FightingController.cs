using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BarFight
{
	public class FightingController : MonoBehaviour
    {
        public Action<CharacterStance> OnEnteredStance;
        public Action<CharacterStance> OnLeftStance;

        public FightingMove Punch;
        public FightingMove Kick;

        private CharacterStance stance;
        public CharacterStance Stance
		{
            get { return stance; }
            set
			{
                if (value == stance)
                    return;
                OnLeftStance?.Invoke(stance);
                stance = value;
                OnEnteredStance?.Invoke(stance);
			}
		}

        public void ExecuteMove (FightingMove move)
        {
            move.Execute();
        }
    }

    [Flags]
    public enum CharacterStance
	{
        Undefined = 0,
        LaidDown = 1,
        Crounched = 2,
        StandingUp = 4,
        Jumping = 8,
	}
}
