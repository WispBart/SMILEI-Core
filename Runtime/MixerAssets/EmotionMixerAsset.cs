using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SMILEI.Core
{
    public abstract class EmotionMixerAsset : ScriptableObject, IEmotionMixer
    {
        public abstract IEmotionMixer Implementation { get; }
        public virtual Emotion GetValue() => Implementation.GetValue();
    }
}