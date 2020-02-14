using UnityEngine;

namespace SMILEI.Core
{
    /// <summary>
    /// Base class for a ScriptableObject asset that contains an EmotionMixer.
    /// Subclasses can use [CreateAssetMenu] to enable the creation of assets.
    /// </summary>
    public abstract class EmotionMixerAsset : ScriptableObject, IEmotionMixer
    {
        /// <summary>
        /// The concrete implementation of the EmotionMixer.
        /// </summary>
        public abstract IEmotionMixer Implementation { get; }
        
        /// <summary>
        /// Default implementation of the IEmotionMixer interface gets the value from the Implementation.
        /// </summary>
        /// <returns></returns>
        public virtual Emotion GetValue() => Implementation.GetValue();
    }
}