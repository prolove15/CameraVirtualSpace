using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Evereal.VideoCapture;

public class Controller : MonoBehaviour
{
    
    //////////////////////////////////////////////////////////////////////
    // types
    //////////////////////////////////////////////////////////////////////
    #region types
    
    public enum GameState_En
    {
        Nothing, Inited
    }

    [System.Serializable]
    public class SerializedComponents_Cs
    {
        [Header("Background Manager")]
        [Tooltip("Background manager include curtain and background music")]
        public BgdManager bgdManager_Cp;

        [Space(5)]
        public UIManager uiManager_Cp;

        [Space(5)]
        public CameraManager cameraManager_Cp;

        [Space(5)]
        public BallPlayer ballPlayer_Cp;
        
        [Space(5)]
        public VideoCaptureManager videoManager_Cp;
    }

    #endregion

    //////////////////////////////////////////////////////////////////////
    // fields
    //////////////////////////////////////////////////////////////////////
    #region fields

    //-------------------------------------------------- SerializeField

    //-------------------------------------------------- public fields
    public GameState_En gameState;

    public BgdManager bgdManager_Cp
    {
        get { return serializedCp.bgdManager_Cp; }
    }

    public UIManager uiManager_Cp
    {
        get { return serializedCp.uiManager_Cp; }
    }

    public CameraManager cameraManager_Cps
    {
        get { return serializedCp.cameraManager_Cp; }
    }

    public BallPlayer ballPlayer_Cp
    {
        get { return serializedCp.ballPlayer_Cp; }
    }

    public VideoCaptureManager videoManager_Cp
    {
        get { return serializedCp.videoManager_Cp; }
    }

    [Header("Camera Manager")]
    public CameraManager cameraManager_Cp;

    //-------------------------------------------------- private fields
    public SerializedComponents_Cs serializedCp;

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
        Init();
    }

    //////////////////////////////////////////////////////////////////////
    // Init
    //////////////////////////////////////////////////////////////////////
    #region Init

    //-------------------------------------------------- Init
    public void Init()
    {
        bgdManager_Cp.Init();

        uiManager_Cp.Init();

        gameState = GameState_En.Inited;

        Play();
    }

    #endregion

    //--------------------------------------------------
    public void Play()
    {

    }

}
