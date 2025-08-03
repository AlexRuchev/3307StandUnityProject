using System.Collections;
using UnityEngine;

namespace Assets.MenuScripts.FSM.States
{
    public class InfoMenuState : State
    {
        public InfoMenuState(Instans sceneContent, MenuStateMachine menuStateMachine): base (sceneContent, menuStateMachine)
        {
        }

        public override void Enter()
        {
        }

        public override void Exit()
        {
            throw new System.NotImplementedException();
        }
    }
}