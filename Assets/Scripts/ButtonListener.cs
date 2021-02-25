using OculusSampleFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonListener : MonoBehaviour
{
    public UnityEvent proximityEvent;
    public UnityEvent contactEvent;
    public UnityEvent actionEvent;
    public UnityEvent defaultEvent;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<ButtonController>().InteractableStateChanged.AddListener(InitiateEvent);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InitiateEvent(InteractableStateArgs state)
    {
        if (state.NewInteractableState == InteractableState.ProximityState)
            proximityEvent.Invoke();
        else if (state.NewInteractableState == InteractableState.ContactState)
            proximityEvent.Invoke();
        else if (state.NewInteractableState == InteractableState.ActionState)
            proximityEvent.Invoke();
        else
            defaultEvent.Invoke();
    }
}
