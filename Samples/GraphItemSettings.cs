using UnityEngine;

namespace SMILEI.Core.Samples
{
    /// <summary>
    /// A settings object for displaying Mixers in, for example, a graph.
    /// </summary>
    [CreateAssetMenu]
    public class GraphItemSettings : ScriptableObject
    {
        public string DisplayName;
        public Color LineColor;
        public EmotionMixerAsset MixerAsset;
    }
}

