
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;

namespace CodeFlow.Test.Game
{
	public class GamePlayingState : GameBaseState
	{
		public GamePlayingState(GameController controller) :  base(GameStateTypes.PLAYING, controller) 
		{
		}

		public override void Init()
		{
		}

		public override void Update()
		{
		}

		public override void Finish()
		{
		}
	}
}
