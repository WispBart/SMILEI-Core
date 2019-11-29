using System.Collections;
using System.Collections.Generic;
using SMILEI.Core;
using UnityEngine;

namespace SMILEI.Core
{
    public interface IEmotionMixer
    {
        void StartRecording();
        Emotion StopRecording();
        Emotion GetRawValue();
    }
    
}

