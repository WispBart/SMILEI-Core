using System.Collections;
using System.Collections.Generic;
using SMILEI;
using SMILEI.Core;
using UnityEngine;

public abstract class EMixerAsset : ScriptableObject, IEMixer
{
    public abstract IEMixer Implementation { get; }
    public virtual void StartRecording() => Implementation.StartRecording();
    public virtual EValue StopRecording() => Implementation.StopRecording();
    public virtual EValue GetRawValue() => Implementation.GetRawValue();
}
