using UnityEngine;
using HoloToolkit.Unity.InputModule;
using System;
using System.Collections;
public class Strenght : MonoBehaviour, IFocusable, IInputClickHandler, IHoldHandler
{
    private float HoldStartTime;
    public void OnFocusEnter()
    {
        throw new NotImplementedException();
    }

    public void OnFocusExit()
    {
        throw new NotImplementedException();
    }

    public void OnHoldCanceled(HoldEventData eventData)
    {
       
    }

    public void OnHoldCompleted(HoldEventData eventData)
    {
        Debug.Log("Czas ktory uplynal od tapniecia: " + (Time.time - HoldStartTime));
    }

    public void OnHoldStarted(HoldEventData eventData)
    {
        HoldStartTime = Time.time;
     
    }
    public void OnInputClicked(InputClickedEventData eventData)
    {
        throw new NotImplementedException();
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

}