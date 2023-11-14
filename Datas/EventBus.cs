using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.Events;

public class EventBus : MonoBehaviour, IEventBus
{
    private static Dictionary<EventType, Action> eventDictionary = new Dictionary<EventType, Action>();

    public static void Subscribe(EventType eventType, Action action)
    {
        if (!eventDictionary.ContainsKey(eventType))
        {
            eventDictionary[eventType] = action;
        }
        else
        {
            eventDictionary[eventType] += action;
        }
    }

    public static void UnSubscribe(EventType eventType, Action action)
    {
        if (eventDictionary.TryGetValue(eventType, out var eventDelegate))
        {
            eventDictionary[eventType] -= action;
        }
    }

    public static void Publish(EventType eventType)
    {
        if (eventDictionary.TryGetValue(eventType, out var eventDelegate))
        {
            eventDelegate?.Invoke();
        }
    }

    public static void ALL_Publish()
    {
        foreach (var eventType in eventDictionary.Keys)
        {
            Publish(eventType);
        }
    }
}

public enum EventType
{
    Hud
}

public interface IEventBus
{
    public static void Publish(EventType eventType, Action action) { }
    public static void Subscribe(EventType eventType, Action action) { }

    public static void UnSubscribe(EventType eventType, Action action) { }

}