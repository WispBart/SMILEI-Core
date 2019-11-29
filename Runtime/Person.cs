using UnityEngine;
using System;
using System.Collections.Generic;

namespace SMILEI.Core
{
    /// <summary>
    /// Represents a person with an emotional state.
    /// </summary>
    [ExecuteAlways]
    public class Person : MonoBehaviour
    {
        public bool Warnings = true;
        public bool UpdateDisplayValues = true;
        
        [SerializeField] 
        private List<MixerMap> _mixers = new List<MixerMap>();

        private Dictionary<EmotionType, IEmotionMixer> _mixerDic;

        void OnEnable()
        {
            UpdateDic();
        }

        void OnValidate() => UpdateDic();

        void UpdateDic()
        {
            _mixerDic = new Dictionary<EmotionType, IEmotionMixer>(16);
            foreach (var mixer in _mixers)
            {
                if(mixer.EmotionMixer == null || mixer.EmotionType == null) continue;
                _mixerDic.Add(mixer.EmotionType, mixer.EmotionMixer);
            }
        }
        public IEmotionMixer GetMixer(EmotionType t)
        {
            IEmotionMixer mixer;
            if (_mixerDic.TryGetValue(t, out mixer))
            {
                return mixer;
            }
            else
            {
                if (Warnings) Debug.LogWarning("EmotionType not known", this);
                return null;
            }
        }

        void Update()
        {
            if (UpdateDisplayValues)
            {
                foreach (var map in _mixers)
                {
                    map.UpdateValue();
                }
            }
        }
    }
 }

