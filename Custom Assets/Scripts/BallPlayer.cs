using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPlayer : MonoBehaviour
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
    Transform ball_Tf;

    [SerializeField]
    float launchSpeedCoef = 1f;
    
    [SerializeField]
    float launchSpeedMax = 20f, launchSpeedMin = 1f;

    //-------------------------------------------------- public fields
    public GameState_En gameState;

    public float launchSpeed = 1f;

    //-------------------------------------------------- private fields
    Rigidbody ballRigidB_Cp;

    Vector3 startPos;

    Quaternion startRot;

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
        ballRigidB_Cp = ball_Tf.GetComponent<Rigidbody>();

        startPos = ball_Tf.position;
        startRot = ball_Tf.rotation;

        InitBallTransform();
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

    //--------------------------------------------------
    public void InitBallTransform()
    {
        ballRigidB_Cp.Sleep();
        ballRigidB_Cp.isKinematic = true;
        ballRigidB_Cp.WakeUp();

        ball_Tf.position = startPos;
        ball_Tf.rotation = startRot;
    }

    #endregion

    //--------------------------------------------------
    public void Launch()
    {
        ballRigidB_Cp.isKinematic = false;
        ballRigidB_Cp.AddForce(ball_Tf.forward * launchSpeed * launchSpeedCoef);
    }

    //--------------------------------------------------
    public bool SetLaunchSpeed(string value, out float filteredValue)
    {
        bool result = true;

        float launchSpeed_tp = 0f;
        if(!float.TryParse(value, out launchSpeed_tp))
        {
            result = false;
            filteredValue = launchSpeed;
            return result;
        }

        if(launchSpeed_tp > launchSpeedMax || launchSpeed_tp < launchSpeedMin)
        {
            result = false;
            filteredValue = Mathf.Clamp(launchSpeed_tp, launchSpeedMin, launchSpeedMax);
            return result;
        }

        filteredValue = launchSpeed_tp;
        return result;
    }

}
