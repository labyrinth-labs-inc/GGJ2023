using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.EventSystems;
using MyBox;

public class InputManager: MonoBehaviour
{

    #region LeftHand Folder
    [Foldout("LEFT HAND", true)]

    [Header("Input")]
    public Transform leftHand;
    public XRNode leftHandController;
    public InputHelpers.Button triggerLeftHand;
    [Foldout("LEFT HAND")] public InputHelpers.Button grabLeftHand;
    #endregion

    #region RightHand Folder
    [Foldout("RIGHT HAND", true)]

    [Header("Input")]
    public Transform rightHand;
    public XRNode rightHandController;
    public InputHelpers.Button triggerRightHand;
    [Foldout("RIGHT HAND")] public InputHelpers.Button grabRightHand;
    #endregion
    
    [Space(10f)]
    [Separator()]
    [Space(10f)]

    [Header("References")]
    public OVRInputModule oVRInputModule;

    [Space(10f)]
    [Separator()]
    [Space(10f)]

    [Header("Current Input")]
    [DefinedValues("RightHand", "LeftHand")]
    [OverrideLabel("Main Hand")]
    [SerializeField]private string mainHand_Value;

    public string mainHand
    {
        get
        {
            return mainHand_Value;
        }
        set
        {
            mainHand_Value = value;
            SetCurrentSide();
        }
    }
    [Space(5f)]
    [Separator()]
    [Space(5f)]

    [Foldout("Current Main Hand", true)]
    public Transform currentMainHandTransform;
    public XRNode currentMainHandController;
    public InputHelpers.Button currentMainHand_Trigger;
    public InputHelpers.Button currentMainHand_Grab;
    [Foldout("Current Main Hand")]public OVRInput.Controller currentMainController;

    [Foldout("Current Other Hand", true)]
    public Transform currentOtherHandTransform;
    public XRNode currentOtherHandController;
    public InputHelpers.Button currentOtherHand_Trigger;
    public InputHelpers.Button currentOtherHand_Grab;
    [Foldout("Current Other Hand")]public OVRInput.Controller currentOtherController;

    #if UNITY_EDITOR
    [ButtonMethod]
    private void ChangeMainHand()
    {
        if(mainHand_Value == "RightHand")mainHand_Value = "LeftHand";
        else mainHand_Value = "RightHand";
        SetCurrentSide();
    }
    #endif
    
    void Awake()
    {
        SetCurrentSide();
    }

    private void SetCurrentSide()
    {
        if(mainHand_Value == "RightHand")
        {
            //#### Main Hand ####
            currentMainHandTransform = rightHand;
            currentMainHandController = rightHandController;
            currentMainHand_Trigger = triggerRightHand;
            currentMainHand_Grab = grabRightHand;
            currentMainController = OVRInput.Controller.RTouch;

            oVRInputModule.joyPadClickButton = OVRInput.Button.SecondaryIndexTrigger;
            oVRInputModule.rayTransform = rightHand;
            oVRInputModule.m_Cursor.SetCursorRay(rightHand);
            

            //#### Other Hand ####
            currentOtherHandTransform = leftHand;
            currentOtherHandController = leftHandController;
            currentOtherHand_Trigger = triggerLeftHand;
            currentOtherHand_Grab = grabLeftHand;
            currentOtherController = OVRInput.Controller.LTouch;
        }
        else
        {
            //#### Main Hand ####
            currentMainHandTransform = leftHand;
            currentMainHandController = leftHandController;
            currentMainHand_Trigger = triggerLeftHand;
            currentMainHand_Grab = grabLeftHand;
            currentMainController = OVRInput.Controller.LTouch;

            oVRInputModule.joyPadClickButton = OVRInput.Button.PrimaryIndexTrigger;
            oVRInputModule.rayTransform = rightHand;
            oVRInputModule.m_Cursor.SetCursorRay(rightHand);

            //#### Other Hand ####
            currentOtherHandTransform = rightHand;
            currentOtherHandController = rightHandController;
            currentOtherHand_Trigger = triggerRightHand;
            currentOtherHand_Grab = grabRightHand;
            currentOtherController = OVRInput.Controller.RTouch;
        }
    }
}
