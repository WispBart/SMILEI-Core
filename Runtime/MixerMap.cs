using System;
using System.Collections;
using System.Collections.Generic;
using SMILEI.Core;
using UnityEngine;

namespace SMILEI.Core
{
    [Serializable]
    public class MixerMap
    {
        public EmotionType EmotionType;
        public EmotionMixerAsset EmotionMixer;

        //Todo: why don't we use datatype Emotion?
        [Range(0f, 1f)] public float LastValue;
        [Range(0f, 1f)] public float LastConfidence;

        public void UpdateValue()
        {
            if (EmotionMixer != null)
            {
                var value = EmotionMixer.GetValue();
                LastConfidence = value.Confidence;
                LastValue = value.Value;
            }
        }
    }
}