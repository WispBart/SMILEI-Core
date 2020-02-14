using System;
using UnityEngine;
using UnityEngine.Events;

namespace SMILEI.Core
{
    /// <summary>
    /// Classes that implement IEmotionMixer are the core of the SMILEI framework.
    /// A Mixer can be thought of as a manipulation on a data stream.
    /// By combining different mixers, we can perform configurable logic on any datastream within SMILEI and issue the result to the end user in the same way.
    /// </summary>
    public interface IEmotionMixer
    {
        Emotion GetValue();
        
        // TODO: allow push instead of pull with an observer pattern.
        // public EmotionEvent OnChange;
    }
    
    // TODO:
    // [Serializable] public class EmotionEvent : UnityEvent<Emotion> { }

}

