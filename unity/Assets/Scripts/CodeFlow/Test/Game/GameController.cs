
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;

namespace CodeFlow.Test.Game
{
	public class GameController : MonoBehaviour
	{
		static public GameBaseState CreateState(GameStateTypes type, GameController controller)
		{
			switch(type)
			{
				case GameStateTypes.INTRO : return new GameIntroState(controller);
				case GameStateTypes.PLAYING : return new GamePlayingState(controller);
				case GameStateTypes.MENU : return new GameMenuState(controller);
				case GameStateTypes.END : return new GameEndState(controller);
			}
		
			throw new System.NotImplementedException();
		}

		public GameStateTypes CurrentGameType
		{ 
			get
			{
				if( _currentState != null )
				{
					return _currentState.Type;
				}
				
				return  GameStateTypes.UNKNOWN;
			}
		}

		protected GameBaseState _currentState = null;

		void Start()
		{
			ChangeState(GameStateTypes.INTRO);
		}

		public void ChangeState(GameStateTypes type)
		{
			if( _currentState != null )
			{
				_currentState.Finish();
			}

			Debug.Log("GameController -> changing state to : " + type.ToString() );
			_currentState = CreateState(type, this);
			_currentState.Init();
		}

		void Update()
		{
			if( _currentState != null )
			{
				_currentState.Update();
			}
		}
	}
}
