using UnityEngine;

namespace SMILEI.Core.Samples
{
    [CreateAssetMenu]
    public class GraphItemSettings : ScriptableObject
    {
        public string DisplayName;
        public Color LineColor;
        public EmotionMixerAsset MixerAsset;
    }
}

