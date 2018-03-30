using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColliderActions : MonoBehaviour {

    [HideInInspector]
    public string ObservedTag;
    [HideInInspector]
    public UnityEvent OnTriggerEnterEvent;
    [HideInInspector]
    public UnityEvent OnTriggerExitEvent;
    [HideInInspector]
    public UnityEvent OnTriggerStayEvent;

    private Collider Player;

    #region Collider Calbacks
    void OnTriggerEnter(Collider other)
    {
        if (ObservedTag.Equals(other.tag))
        {
            Player = other;
            OnTriggerEnterEvent.Invoke();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (ObservedTag.Equals(other.tag)) OnTriggerExitEvent.Invoke();
    }

    void OnTriggerStay(Collider other)
    {
        if (ObservedTag.Equals(other.tag))
        {
            Player = other;
            OnTriggerStayEvent.Invoke();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        
    }
    #endregion

    // If I want to destroy everything with ObeservedTag
    public void DestroyPlayer(float time)
    {
        Destroy(Player.gameObject, time);
    }
}
