using System.Collections;
using System.Collections.Generic;
using SMILEI.Core;
using UnityEngine;

namespace SMILEI
{
    public interface IEMixer
    {
        void StartRecording();
        EValue StopRecording();
        EValue GetRawValue();
    }
    
}

