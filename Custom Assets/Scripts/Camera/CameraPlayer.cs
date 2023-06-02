using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
    
    //////////////////////////////////////////////////////////////////////
    // types
    //////////////////////////////////////////////////////////////////////
    #region types
    
    public enum GameState_En
    {
        Nothing, Inited
    }

    #endregion

    //////////////////////////////////////////////////////////////////////
    // fields
    //////////////////////////////////////////////////////////////////////
    #region fields

    //-------------------------------------------------- SerializeField

    //-------------------------------------------------- public fields
    public GameState_En gameState;

    //-------------------------------------------------- private fields
    Controller controller_Cp;

    CameraManager cameraManager_Cp;

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

        cameraManager_Cp.OnCreateCamera(this);
    }

    //////////////////////////////////////////////////////////////////////
    // Init
    //////////////////////////////////////////////////////////////////////
    #region Init

    //-------------------------------------------------- Init
    public void Init()
    {

        gameState = GameState_En.Inited;
    }

    #endregion

    //--------------------------------------------------
    public void OnSelectCamera()
    {
        cameraManager_Cp.OnSelectCamera(this);
    }

    //--------------------------------------------------
    public void OnDeselectCamera()
    {
        cameraManager_Cp.OnDeselectCamera();
    }

    //--------------------------------------------------
    void OnDestroy()
    {
        cameraManager_Cp.OnCameraDestroy(this);
    }

}
