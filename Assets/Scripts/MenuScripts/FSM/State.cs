namespace Assets.MenuScripts.FSM.States
{
    public abstract class State
    {
        protected Instans sceneContent;
        protected MenuStateMachine stateMachine;

        protected State(Instans sceneContent, MenuStateMachine stateMachine)
        {
            this.sceneContent = sceneContent;
            this.stateMachine = stateMachine;
        }

        public virtual void Enter()
        {

        }

        public virtual void LateEnter()
        {

        }

        public virtual void LogicUpdate()
        {
            if (sceneContent.gameObject.activeSelf == true)
            {
                
            }
        }

        public virtual void Exit()
        {

        }
    }
}