
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;

namespace CodeFlow.Test.Game
{
	public enum GameStateTypes
	{
		INTRO, 
		PLAYING, 
		MENU, 
		END, 
		UNKNOWN
	}

	public abstract class GameBaseState 
	{
		public GameBaseState(
			GameStateTypes type, 
			GameController controller)
		{
			_controller = controller;
			_type = type;
		}

		public GameStateTypes Type{ get{ return _type; }}
		protected GameStateTypes _type = GameStateTypes.UNKNOWN;

		public GameController Controller{ get{ return _controller; }}
		protected GameController _controller;

		public abstract void Init();
		public abstract void Update();
		public abstract void Finish();
	}
}
