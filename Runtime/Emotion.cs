using System;

namespace SMILEI.Core
{
    [Serializable] 
    public struct Emotion
    {
        public float Value;
        public float Confidence;

        public Emotion(float value, float confidence)
        {
            Value = value;
            Confidence = confidence;
        }
    }
}

