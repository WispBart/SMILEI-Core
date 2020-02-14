using System;

namespace SMILEI.Core
{
    /// <summary>
    /// The core data struct of the SMILEI framework.
    /// Signifies a single measurement of a single value at a specific point in time.
    /// </summary>
    [Serializable] 
    public struct Emotion
    {
        /// <summary> Strength of the reported emotion. Expected range [0-1]. </summary>
        public float Value;
        /// <summary> How reliable is this data? Expected range [0-1]. </summary>
        public float Confidence;
        
        // public ? TimeStamp; // TODO: Add

        public Emotion(float value, float confidence)
        {
            Value = value;
            Confidence = confidence;
        }
    }
}

