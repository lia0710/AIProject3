using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCompletedStateBehaviour : StateMachineBehaviour
{
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        IAnimationCompleted callBack = animator.gameObject.GetComponent(typeof(IAnimationCompleted)) as IAnimationCompleted;
        if (callBack != null)
        {
            callBack.AnimationCompleted(stateInfo.shortNameHash);
        }
    }
}
