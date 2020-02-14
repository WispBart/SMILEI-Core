using SMILEI.Core;
using UnityEngine;

/// <summary>
/// Simple reusable EmotionMixerAsset. It will just report the last-used value that is set on it.
/// </summary>
[CreateAssetMenu(menuName="SMILEI/Simple Emotion Mixer")]
public class SimpleEmotionMixerAsset : EmotionMixerAsset
{
    public float Timestamp;
    public float Value;
    public float Confidence;

    public override IEmotionMixer Implementation => (IEmotionMixer) this;

    /// <summary>
    /// Set a new value on the EmotionMixerAsset.
    /// </summary>
    /// <param name="value">Strength of the reported emotion. Expected range [0-1].</param>
    /// <param name="confidence">How reliable is this data? Expected range [0-1]</param>
    /// <param name="timestamp">When was this measured?</param>
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
