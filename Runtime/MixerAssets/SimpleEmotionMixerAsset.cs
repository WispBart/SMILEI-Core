using System;
using System.Collections;
using System.Collections.Generic;
using SMILEI.Core;
using UnityEngine;

[CreateAssetMenu(menuName="SMILEI/Simple Emotion Mixer")]
public class SimpleEmotionMixerAsset : EmotionMixerAsset
{
    public float Timestamp;
    public float Value;
    public float Confidence;

    public override IEmotionMixer Implementation => (IEmotionMixer) this;

    public void SetValue(float value, float confidence, float timestamp)
    {
        this.Value = value;
        this.Timestamp = timestamp;
        this.Confidence = confidence;
    }

    public override Emotion GetValue()
    {
        return new Emotion(Value, Confidence);
    }
}
