using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationListener : MonoBehaviour, IAnimationCompleted
{
    #region Animation Move
    public System.Action OnAnimatorMoveEvent;

    private void OnAnimatorMove()
    {
        if (OnAnimatorMoveEvent != null)
        {
            OnAnimatorMoveEvent.Invoke();
        }
    }
    #endregion

    private Dictionary<int, System.Action<int>> OnAnimationCompletedEvents = new Dictionary<int, System.Action<int>>();

    public void AddAnimationCompletedListener(int animationName, System.Action<int> callback)
    {
        System.Action<int> action;
        if (OnAnimationCompletedEvents.TryGetValue(animationName, out action))
        {
            action += callback;
        }
        else
        {
            OnAnimationCompletedEvents.Add(animationName, callback);
        }
    }

    public void RemoveAnimationCompletedListener(int animationName, System.Action<int> callback)
    {
        System.Action<int> action;
        if (OnAnimationCompletedEvents.TryGetValue(animationName, out action))
        {
            action -= callback;
        }
    }

    public void AnimationCompleted(int shortHashName)
    {
        System.Action<int> action;
        if (OnAnimationCompletedEvents.TryGetValue(shortHashName, out action))
        {
            action(shortHashName);
        }
    }

}
