using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.Utilities;
using Microsoft.MixedReality.Toolkit;

// used to add collidable cylinders to the index fingers of MRTK hands
// see https://microsoft.github.io/MixedRealityToolkit-Unity/Documentation/Input/HandTracking.html for more info

public class FingerSwordModifier : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform cubePrefab;
    public Material leftFingerMat;
    public Material rightFingerMat;
    IMixedRealityHandJointService handJointService;

    bool leftFingerInstantiated = false;
    bool rightFingerInstantiated = false;
    Transform LeftFinger;
    Transform RightFinger;
    void Start()
    {
        Debug.Log("Script Loaded");
        handJointService = CoreServices.GetInputSystemDataProvider<IMixedRealityHandJointService>();
    }

    // Update is called once per frame 
    void Update()
    {
        if (handJointService != null)
        {
            Transform LeftDistalTransform = handJointService.RequestJointTransform(TrackedHandJoint.IndexDistalJoint, Handedness.Left);
            Transform RightDistalTransform = handJointService.RequestJointTransform(TrackedHandJoint.IndexDistalJoint, Handedness.Right);
            
            if (!rightFingerInstantiated && handJointService.IsHandTracked(Handedness.Right)) {
                RightFinger = Instantiate(cubePrefab, RightDistalTransform.position, RightDistalTransform.rotation);
                RightFinger.SetParent(RightDistalTransform);
                RightFinger.GetComponent<Renderer>().material = rightFingerMat;
                rightFingerInstantiated = true;
            }

            if (!leftFingerInstantiated && handJointService.IsHandTracked(Handedness.Left)) {
                LeftFinger = Instantiate(cubePrefab, LeftDistalTransform.position, LeftDistalTransform.rotation);
                LeftFinger.SetParent(LeftDistalTransform);
                RightFinger.GetComponent<Renderer>().material = leftFingerMat;
                leftFingerInstantiated = true;
            }
            
        }
    }
}
