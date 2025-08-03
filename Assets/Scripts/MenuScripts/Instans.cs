using UnityEngine;
using Assets.MenuScripts.FSM.States;


public class Instans : MonoBehaviour
{
    public MenuStateMachine MenuStateMachine;
    [SerializeField] private GameObject _infoMenu;
    [SerializeField] private GameObject _startMenu;
    public InfoMenuState infoMenuState;
    public StartMenuState mainMenuState;

    private void Start()
    {
        MenuStateMachine = new MenuStateMachine();
        infoMenuState = new InfoMenuState(this, MenuStateMachine);
        mainMenuState = new StartMenuState(this, MenuStateMachine);
        MenuStateMachine.Initialize(mainMenuState);
        
    }
    
}
