﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Valve.VR.InteractionSystem;
using Valve.VR;

public class DisplayTooltip : MonoBehaviour
{
    public GameObject rightHand, leftHand;
    private Hand leftHandScript, rightHandScript;


    private void Start()
    {
        leftHandScript = leftHand.GetComponent<Hand>();
        rightHandScript = rightHand.GetComponent<Hand>();
    }
    

    //-----------------------------------
    // Helper functions
    //
    private void ShowHint(Hand handScript, ISteamVR_Action_In_Source action, string message)
    {
        ControllerButtonHints.ShowButtonHint(handScript, action);
        ControllerButtonHints.ShowTextHint(handScript, action, message);
    }
    private void HideHint(Hand handScript, ISteamVR_Action_In_Source action)
    {
        ControllerButtonHints.HideButtonHint(handScript, action);
        ControllerButtonHints.HideTextHint(handScript, action);
    }


    //-----------------------------------
    // Squeeze action hints
    // to instruct the player how to grab cars, tanks, etc.
    // and also to throw them
    //
    public void HighlightSqueezeHover(Hand hand)
    {
        ShowHint(hand, SteamVR_Input.GetSingleAction("Squeeze"), "Pick up");
    }
    public void UnhighlightSqueezeHover(Hand hand)
    {
        HideHint(hand, SteamVR_Input.GetSingleAction("Squeeze"));
    }
    public void HighlightSqueezeHolding(Hand hand)
    {
        ShowHint(hand, SteamVR_Input.GetSingleAction("Squeeze"), "Release to drop/throw");
    }
    public void UnhighlightSqueezeHolding(Hand hand)
    {
        HideHint(hand, SteamVR_Input.GetSingleAction("Squeeze"));
    }


    //-----------------------------------
    // MovementAxis action hints
    // to instruct the player how to walk
    //
    public void HighlightMovementAxis()
    {
        ShowHint(rightHandScript, SteamVR_Input.GetVector2Action("MovementAxis"), "Move around"); // currently mapped to right thumpad
    }
    public void UnhighlighMovementAxis()
    {
        HideHint(rightHandScript, SteamVR_Input.GetVector2Action("MovementAxis"));
    }


    //-----------------------------------
    // SnapTurn[Left/Right] action hints
    // to instruct the player how to snap turn
    //
    public void HighlightSnapTurn()
    {
        ShowHint(leftHandScript, SteamVR_Input.GetBooleanAction("SnapTurnLeft"), "Turn camera"); // currently mapped to left thumbpad
    }
    public void UnhighlightSnapTurn()
    {
        HideHint(leftHandScript, SteamVR_Input.GetBooleanAction("SnapTurnLeft"));
    }


    //-----------------------------------
    // GrabGrip action hints
    // Used for powerups
    //
    public void HighlightGrabGrip()
    {
        ShowHint(rightHandScript, SteamVR_Input.GetBooleanAction("GrabGrip"), "Use laser vision");
    }
    public void UnhighlightGrabGrip()
    {
        HideHint(rightHandScript, SteamVR_Input.GetBooleanAction("GrabGrip"));
    }


    //-----------------------------------
    // In the event that all hints need to be cleared
    //
    public void ClearAllHints()
    {
        ControllerButtonHints.HideAllButtonHints(rightHandScript);
        ControllerButtonHints.HideAllButtonHints(leftHandScript);
        ControllerButtonHints.HideAllTextHints(rightHandScript);
        ControllerButtonHints.HideAllTextHints(leftHandScript);
    }
}
