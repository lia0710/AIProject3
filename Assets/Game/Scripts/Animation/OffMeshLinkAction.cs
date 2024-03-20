using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(OffMeshLink))]
public class OffMeshLinkAction : MonoBehaviour
{
    public enum Action
    {
        Climb,
        JumpWithStyle,
        JumpAcross,
        ClimbDown
    };

    public Action action;

    public bool useStartForward = false;
    public bool applyLocationBlend = true;
    public bool applyRotationBlend = true;
}
