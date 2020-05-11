using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Game Events / Game Event")]
public class GameEvent : ScriptableObject
{
    public string sentString;
    public int sentInt;
    public float sentFloat;
    public bool sentBool;

    public virtual Color GetColor() { return Color.black; }


    private List<EventListener> eventListeners = new List<EventListener>();


    public void Raise()
    {
        for (int i = eventListeners.Count - 1; i >= 0; i--)
        {
            Debug.LogFormat("Raise() '{0}' for '{1}'", this.name, eventListeners[i].name);
            eventListeners[i].OnEventRaised(this);
        }
    }

    public void Register(EventListener passedEvent)
    {
        if (!eventListeners.Contains(passedEvent))
        {
            eventListeners.Add(passedEvent);
        }

    }

    public void DeRegister(EventListener passedEvent)
    {
        if (eventListeners.Contains(passedEvent))
        {
            eventListeners.Remove(passedEvent);
        }

    }
}