using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
    
    //////////////////////////////////////////////////////////////////////
    // types
    //////////////////////////////////////////////////////////////////////
    #region types
    
    #endregion

    //////////////////////////////////////////////////////////////////////
    // fields
    //////////////////////////////////////////////////////////////////////
    #region fields

    //-------------------------------------------------- SerializeField
    [SerializeField]
    bool isBall;

    //-------------------------------------------------- public fields

    //-------------------------------------------------- private fields
    Controller controller_Cp;

    CameraManager cameraManager_Cp;

    TransformInspector transformInspector_Cp;

    #endregion

    //////////////////////////////////////////////////////////////////////
    // properties
    //////////////////////////////////////////////////////////////////////
    #region properties

    //-------------------------------------------------- public properties

    //-------------------------------------------------- private properties

    #endregion

    //////////////////////////////////////////////////////////////////////
    // methods
    //////////////////////////////////////////////////////////////////////

    //-------------------------------------------------- Start is called before the first frame update
    void Start()
    {
        controller_Cp = GameObject.FindWithTag("GameController").GetComponent<Controller>();
        cameraManager_Cp = controller_Cp.cameraManager_Cp;
        transformInspector_Cp = controller_Cp.transformInspector_Cp;

        if(!isBall)
        {
            cameraManager_Cp.OnCreateCamera(this);
        }
    }

    //--------------------------------------------------
    public void OnSelectCamera()
    {
        cameraManager_Cp.OnSelectCamera(this);

        transformInspector_Cp.OnSelectTransform(transform);
    }

    //--------------------------------------------------
    public void OnDeselectCamera()
    {
        cameraManager_Cp.OnDeselectCamera();
        
        transformInspector_Cp.OnDeselectTransform();
    }

    //--------------------------------------------------
    public void OnSelectBall()
    {
        transformInspector_Cp.OnSelectTransform(transform);
    }

    //--------------------------------------------------
    public void OnDeselectBall()
    {
        transformInspector_Cp.OnDeselectTransform();
    }

    //--------------------------------------------------
    void OnDestroy()
    {
        cameraManager_Cp.OnCameraDestroy(this);
    }

}
