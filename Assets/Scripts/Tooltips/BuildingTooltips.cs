using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class BuildingTooltips : Interactable
{
    private DisplayTooltip tooltipManager;


    protected override void Start()
    {
        base.Start();
        tooltipManager = GameObject.Find("TooltipManager").GetComponent<DisplayTooltip>();
    }


    protected override void OnHandHoverBegin(Hand hand)
    {
        base.OnHandHoverBegin(hand);
    }
}
