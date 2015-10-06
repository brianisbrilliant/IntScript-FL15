using UnityEngine;
using Assets.Code.States;
using Assets.Code.Interfaces;

public class StateManager : MonoBehaviour
{
    private IStateBase activeState;
	
	private static StateManager instanceRef;
	
	void Awake ()
	{
		if(instanceRef == null)
		{
			instanceRef = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			DestroyImmediate(gameObject);
		}
	}

	void Start ()
	{
		activeState = new BeginState(this);
	}

    void Update()
    {
		if (activeState != null)
        	activeState.StateUpdate();
    }
	
	void OnGUI()
	{
		if(activeState != null)
			activeState.ShowIt();
	}

    public void SwitchState(IStateBase newState)
    {
        activeState = newState;
    }
	
	public void Restart()
	{
		Destroy(gameObject);
		Application.LoadLevel("Scene0");
	}
}