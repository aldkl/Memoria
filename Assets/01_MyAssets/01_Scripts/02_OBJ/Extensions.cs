using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{
    public static bool IsInteractable(this RaycastHit hit)
    {
        return hit.transform.GetComponent<Interactable>();
    }

    public static void Interact(this RaycastHit hit)
    {
        hit.transform.GetComponent<Interactable>().Interact();
    }
}