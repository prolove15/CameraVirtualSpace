using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
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
    [SerializeField]
    InputField launchSpeedInputF_Cp;

    //-------------------------------------------------- public fields
    public GameState_En gameState;

    //-------------------------------------------------- private fields
    Controller controller_Cp;

    BallPlayer ballPlayer_Cp;

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
        
    }

    //////////////////////////////////////////////////////////////////////
    // Init
    //////////////////////////////////////////////////////////////////////
    #region Init

    //-------------------------------------------------- Init
    public void Init()
    {
        controller_Cp = GameObject.FindWithTag("GameController").GetComponent<Controller>();
        ballPlayer_Cp = controller_Cp.ballPlayer_Cp;

        gameState = GameState_En.Inited;
    }

    #endregion

    //-------------------------------------------------- Shooting
    public void OnShooting()
    {

    }

    //-------------------------------------------------- Launch
    public void OnLaunch()
    {
        ballPlayer_Cp.Launch();
    }

    //-------------------------------------------------- 
    public void OnChange_LaunchSpeed(string value)
    {
        float filteredValue;
        if(!ballPlayer_Cp.SetLaunchSpeed(value, out filteredValue))
        {
            launchSpeedInputF_Cp.text = filteredValue.ToString();
        }
    }

    //--------------------------------------------------
    public void OnClick_InitBallTransform()
    {
        ballPlayer_Cp.InitBallTransform();
    }

}
