using System.Collections;
using System.Collections.Generic;
using SMILEI.Core;
using UnityEngine;

namespace SMILEI.Samples
{
    /// <summary>
    /// Sets an Animator float value from an EmotionMixerAsset.
    /// </summary>
    public class MixerToAnimator : MonoBehaviour
    {
        public EmotionMixerAsset Mixer;
        public Animator Animator;
        public string AnimatorKey;
        private int _animatorKey;

        void Awake()
        {
            _animatorKey = Animator.StringToHash(AnimatorKey);
        }

        void Update()
        {
            Animator.SetFloat(_animatorKey, Mixer.GetValue().Value);
        }
    }
}

