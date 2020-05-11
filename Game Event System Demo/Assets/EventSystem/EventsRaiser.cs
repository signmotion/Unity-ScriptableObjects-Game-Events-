using UnityEngine;


public class EventsRaiser : MonoBehaviour
{
    public GameEvent[] events;


    public void RaiseEvents()
    {
        if (events.Length == 0)
        {
            Debug.Log("Event was not set for Event Raiser on GameObject named: " + gameObject.name, this);
            return;
        }

        foreach (GameEvent e in events)
        {
            e.Raise();
        }
    }
}
