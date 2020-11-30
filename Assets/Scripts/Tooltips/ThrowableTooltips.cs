using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class ThrowableTooltips : Interactable
{
    private DisplayTooltip tooltipManager;


    protected override void Start()
    {
        tooltipManager = GameObject.Find("TooltipManager").GetComponent<DisplayTooltip>();
    }


    protected override void OnHandHoverBegin(Hand hand)
    {
        base.OnHandHoverBegin(hand);
        tooltipManager.HighlightSqueezeHover();
    }


    protected override void OnHandHoverEnd(Hand hand)
    {
        base.OnAttachedToHand(hand);
        tooltipManager.UnhighlightSqueezeHover();
    }


    protected override void OnAttachedToHand(Hand hand)
    {
        base.OnAttachedToHand(hand);
        tooltipManager.HighlightSqueezeHolding();
    }


    protected override void OnDetachedFromHand(Hand hand)
    {
        base.OnDetachedFromHand(hand);
        tooltipManager.UnhighlightSqueezeHolding();
    }
}
