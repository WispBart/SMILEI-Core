using UnityEngine;


namespace SMILEI.Core
{
    /// <summary>
    /// Linearly interpolates between value A and B based on the value of TConstant or TMixer (choose with MixFrom).
    /// Optionally uses either input if the other reports 0 confidence.
    /// </summary>
    [CreateAssetMenu(menuName = "SMILEI/LERP Mixer")]
    public class LerpMixerAsset : EmotionMixerAsset
    {
        public enum Usage
        {
            Constant = 0,
            Mixer = 1
        }

        [Tooltip("If confidence is 0 on one of the two mixers, always use the other one.")]
        public bool UseConfidenceOverride;
        public EmotionMixerAsset A;
        public EmotionMixerAsset B;
        public Usage MixFrom;
        public float TConstant;
        public EmotionMixerAsset TMixer;

        public override IEmotionMixer Implementation => this;

        public override Emotion GetValue()
        {
            if (A == null || B == null || (MixFrom == Usage.Mixer && TMixer == null))
            {
                Debug.LogError("Missing variables", this);
                return new Emotion(0, 0);
            }

            var a = A.GetValue();
            var b = B.GetValue();
            var t = MixFrom == Usage.Constant ? TConstant : TMixer.GetValue().Value;

            float value = Mathf.Lerp(a.Value, b.Value, t);

            if (UseConfidenceOverride)
            {
                if (Mathf.Approximately(a.Confidence, 0))
                {
                    value = b.Value;
                }
                else if (Mathf.Approximately(b.Confidence, 0))
                {
                    value = a.Value;
                }
            }
            
            var c = new Emotion()
            {
                Value = value,
                Confidence = Mathf.Lerp(a.Confidence, b.Confidence, t)
            };
            return c;
        }
    }
}
