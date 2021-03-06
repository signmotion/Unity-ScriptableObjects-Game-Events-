﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class EventListener : MonoBehaviour
{
    //[Reorderable]
    public List<EventAndResponse> eventAndResponses = new List<EventAndResponse>();


    private void OnEnable()
    {
        foreach (EventAndResponse eAndR in eventAndResponses)
        {
            eAndR.gameEvent.Register(this);
        }
    }

    private void OnDisable()
    {
        foreach (EventAndResponse eAndR in eventAndResponses)
        {
            eAndR.gameEvent.DeRegister(this);
        }
    }

    [ContextMenu("Raise Events")]
    public void OnEventRaised(GameEvent passedEvent)
    {
        for (int i = eventAndResponses.Count - 1; i >= 0; i--)
        {
            // check if the passed event is the correct one
            if (passedEvent == eventAndResponses[i].gameEvent)
            {
                Debug.Log("Called Event named: " + eventAndResponses[i].name + " on GameObject: " + gameObject.name, this);
                eventAndResponses[i].EventRaised();
            }
        }

    }
}




[System.Serializable]
public class EventAndResponse
{
    public string name;
    public GameEvent gameEvent;

    public ResponseWithNone responseForSentNone;
    public ResponseWithString responseForSentString;
    public ResponseWithInt responseForSentInt;
    public ResponseWithFloat responseForSentFloat;
    public ResponseWithBool responseForSentBool;
    public ResponseWithColor responseForSentColor;


    public void EventRaised()
    {
        // default/generic
        // always check if at least 1 object is listening for the event
        if (responseForSentNone.GetPersistentEventCount() >= 1)
        {
            responseForSentNone.Invoke();
        }

        // string
        if (responseForSentString.GetPersistentEventCount() >= 1)
        {
            responseForSentString.Invoke(gameEvent.sentString);
        }

        // int
        if (responseForSentInt.GetPersistentEventCount() >= 1)
        {
            responseForSentInt.Invoke(gameEvent.sentInt);
        }

        // float
        if (responseForSentFloat.GetPersistentEventCount() >= 1)
        {
            responseForSentFloat.Invoke(gameEvent.sentFloat);
        }

        // bool
        if (responseForSentBool.GetPersistentEventCount() >= 1)
        {
            responseForSentBool.Invoke(gameEvent.sentBool);
        }

        // Color
        if (responseForSentColor.GetPersistentEventCount() >= 1)
        {
            responseForSentColor.Invoke(gameEvent.GetColor());
        }
    }
}




[System.Serializable]
public class ResponseWithNone : UnityEvent
{
}

[System.Serializable]
public class ResponseWithString : UnityEvent<string>
{
}

[System.Serializable]
public class ResponseWithInt : UnityEvent<int>
{
}

[System.Serializable]
public class ResponseWithFloat : UnityEvent<float>
{
}

[System.Serializable]
public class ResponseWithBool : UnityEvent<bool>
{
}

[System.Serializable]
public class ResponseWithColor : UnityEvent<Color>
{
}