using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class Test : MonoBehaviour
{
    [SerializeField]
    private ImageTargetBehaviour imageTargetBehaviour;

    public void Sth()
    {
        if(imageTargetBehaviour.TargetStatus.Status == Status.TRACKED && imageTargetBehaviour.TargetName == imageTargetBehaviour.TargetName)
        {
            Debug.LogError("Recognised");
        }
        else
        {
            Debug.LogError("NotRecognised");
        }
    }
}
