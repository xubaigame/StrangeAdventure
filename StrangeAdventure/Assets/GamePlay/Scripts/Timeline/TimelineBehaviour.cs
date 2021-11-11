// ****************************************************
//     文件：TimelineFinshed.cs
//     作者：积极向上小木木
//     邮箱：positivemumu@126.com
//     日期：#CreateTime#
//     功能：
// *****************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;

public class TimelineBehaviour : MonoBehaviour
{
    [Header("Timeline")]
    public PlayableDirector timeLine;

    [Header("Marker Events")]
    public UnityEvent timelineFinished;
    
    public void StartTimeline()
    {
        timeLine.Play();
    }

    public void PauseTimeline()
    {
        timeLine.Pause();
    }

    public void StopTimeline()
    {
        timeLine.Stop();
    }

    public void TimelineFinished()
    {
        timelineFinished.Invoke();
    }
}
