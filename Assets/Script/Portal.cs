using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    Npc Owner;

    private void Awake()
    {
        Owner = GetComponentInParent<Npc>();

    }
}
