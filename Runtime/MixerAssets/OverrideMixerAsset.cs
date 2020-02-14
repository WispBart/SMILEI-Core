using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SMILEI.Core
{
    /// <summary>
    /// If 'Override' returns a value greater than 0, it is returned. Else, Base is returned.
    /// </summary>
    [CreateAssetMenu(menuName = "SMILEI/Override Mixer")]
    public class OverrideMixerAsset : EmotionMixerAsset
    {
        public EmotionMixerAsset Base;
        public EmotionMixerAsset Override;
        
        public override IEmotionMixer Implementation => this;

        public override Emotion GetValue()
        {
            var baseMixer = Base.GetValue();
            var overrideMixer = Override.GetValue();

            if (Mathf.Approximately(overrideMixer.Value, 0f))
            {
                return baseMixer;
            }
            else
            {
                return overrideMixer;
            }
        }
    }

}
