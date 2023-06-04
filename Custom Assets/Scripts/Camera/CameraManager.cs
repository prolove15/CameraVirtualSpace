using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Evereal.VideoCapture;

public class CameraManager : MonoBehaviour
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

    VideoCaptureManager videoManager_Cp;

    public List<CameraPlayer> cameraPlayers = new List<CameraPlayer>(); // temporary

    public CameraPlayer selectedCameraPlayer_Cp; // temporary

    #endregion

    //////////////////////////////////////////////////////////////////////
    // properties
    //////////////////////////////////////////////////////////////////////
    #region properties

    //-------------------------------------------------- public 
    public Camera selectedCamera_Cp
    {
        get { return selectedCameraPlayer_Cp.GetComponentInChildren<Camera>(); }
    }

    public Transform selectedCamera_Tf
    {
        get { return selectedCameraPlayer_Cp.transform.root; }
    }

    //-------------------------------------------------- private properties

    #endregion

    //////////////////////////////////////////////////////////////////////
    // methods
    //////////////////////////////////////////////////////////////////////

    //--------------------------------------------------
    void Awake()
    {
        controller_Cp = GameObject.FindWithTag("GameController").GetComponent<Controller>();
        videoManager_Cp = controller_Cp.videoManager_Cp;
    }

    //-------------------------------------------------- Start is called before the first frame update
    void Start()
    {
        
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
    public void OnCreateCamera(CameraPlayer cameraPlayer_Cp_pr)
    {
        cameraPlayers.Add(cameraPlayer_Cp_pr);

        videoManager_Cp.videoCaptures.Add(cameraPlayer_Cp_pr.GetComponentInChildren<VideoCapture>());

        OnSelectCamera(cameraPlayer_Cp_pr);
    }

    //--------------------------------------------------
    public void OnSelectCamera(CameraPlayer cameraPlayer_Cp_pr)
    {
        if(selectedCameraPlayer_Cp)
        {
            selectedCamera_Cp.depth = 1;
            selectedCamera_Cp.enabled = false;
        }

        selectedCameraPlayer_Cp = cameraPlayer_Cp_pr;
        selectedCamera_Cp.depth = 2;
        selectedCamera_Cp.enabled = true;
    }

    //--------------------------------------------------
    public void OnDeselectCamera()
    {
        if(selectedCameraPlayer_Cp)
        {
            selectedCamera_Cp.depth = 1;
            selectedCamera_Cp.enabled = false;
        }

        selectedCameraPlayer_Cp = null;
    }

    //--------------------------------------------------
    public void OnCameraDestroy(CameraPlayer cameraPlayer_Cp_pr)
    {
        cameraPlayers.Remove(cameraPlayer_Cp_pr);

        videoManager_Cp.videoCaptures.Remove(cameraPlayer_Cp_pr.GetComponentInChildren<VideoCapture>());
    }

}
