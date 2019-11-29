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

        private Dictionary<EType, IEMixer> _mixerDic;

        void OnEnable()
        {
            UpdateDic();
        }

        void OnValidate() => UpdateDic();

        void UpdateDic()
        {
            _mixerDic = new Dictionary<EType, IEMixer>(16);
            foreach (var mixer in _mixers)
            {
                if(mixer.EMixer == null || mixer.Type == null) continue;
                _mixerDic.Add(mixer.Type, mixer.EMixer);
            }
        }
        public IEMixer GetMixer(EType t)
        {
            IEMixer mixer;
            if (_mixerDic.TryGetValue(t, out mixer))
            {
                return mixer;
            }
            else
            {
                if (Warnings) Debug.LogWarning("EType not known", this);
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
    
    [Serializable] 
    public class MixerMap
    {
        public EType Type;
        public EMixerAsset EMixer;
        [Range(0f, 1f)] 
        public float LastValue;
        [Range(0f, 1f)] 
        public float LastConfidence;

        public void UpdateValue()
        {
            if (EMixer != null)
            {
                var value = EMixer.GetRawValue();
                LastConfidence = value.Confidence;
                LastValue = value.Value;
            }
        }
    }
}

