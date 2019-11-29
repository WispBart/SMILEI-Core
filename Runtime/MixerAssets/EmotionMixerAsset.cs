using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SMILEI.Core
{
    public abstract class EmotionMixerAsset : ScriptableObject, IEmotionMixer
    {
        public abstract IEmotionMixer Implementation { get; }
        public virtual void StartRecording() => Implementation.StartRecording();
        public virtual Emotion StopRecording() => Implementation.StopRecording();
        public virtual Emotion GetRawValue() => Implementation.GetRawValue();
    }
}