using System;
using System.Collections;
using System.Collections.Generic;
using SMILEI.Core;
using UnityEngine;

[CreateAssetMenu(menuName="SMILEI/Simple Emotion Mixer")]
public class SimpleEmotionMixerAsset : EmotionMixerAsset
{
    [SerializeField] private SimpleEmotionMixer _implementation = new SimpleEmotionMixer();
    public override IEmotionMixer Implementation => _implementation;

    public void SetValue(float value, float confidence, float timestamp) =>
        _implementation.SetValue(value, confidence, timestamp);
}

[Serializable] public class SimpleEmotionMixer : IEmotionMixer
{
    public float Timestamp;
    public float Value;
    public float Confidence;

    public void SetValue(float value, float confidence, float timestamp)
    {
        this.Value = value;
        this.Timestamp = timestamp;
        this.Confidence = confidence;
    }
    
    public Emotion GetValue()
    {
        return new Emotion(Value, Confidence);
    }
}