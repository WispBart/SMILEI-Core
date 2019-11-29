using System.Collections;
using System.Collections.Generic;
using SMILEI.Core;
using UnityEngine;

namespace SMILEI.Samples
{
    [RequireComponent(typeof(Animator))]
    public class SMILEIToAnimator : MonoBehaviour
    {
        private Animator _animator;

        public string HappyKey = "Happiness";
        public EmotionType HappyType;
        
        public Person Person;
        
        
        void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        void Update()
        {
            var value = Person.GetMixer(HappyType)?.GetRawValue().Value ?? 0f;
            _animator.SetFloat(HappyKey, value);
        }

    }
}