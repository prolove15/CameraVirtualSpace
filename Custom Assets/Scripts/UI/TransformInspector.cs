using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Battlehub.RTHandles;

public class TransformInspector : MonoBehaviour
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
    List<InputField> transformPosText_Cps;

    [SerializeField]
    List<InputField> transformRotText_Cps;

    //-------------------------------------------------- public fields
    public Transform transform_Tf;

    //-------------------------------------------------- private fields
    Vector3 transformPos;

    Vector3 transformRot;

    bool editTransformState;

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

    //--------------------------------------------------
    void SetTransformPosition()
    {
        BaseHandle baseHandle_Cp_tp = GameObject.FindObjectOfType<BaseHandle>();
        baseHandle_Cp_tp.SetTransformPosition(transformPos);
    }

    //--------------------------------------------------
    void SetTransformRotation()
    {
        BaseHandle baseHandle_Cp_tp = GameObject.FindObjectOfType<BaseHandle>();
        baseHandle_Cp_tp.SetTransformRotation(Quaternion.Euler(transformRot));
    }

    //--------------------------------------------------
    public void SetTransformText(bool nullFlag_pr = false)
    {
        if(!transform_Tf)
        {
            return;
        }

        if(!nullFlag_pr)
        {
            transformPosText_Cps[0].text = transform_Tf.position.x.ToString();
            transformPosText_Cps[1].text = transform_Tf.position.y.ToString();
            transformPosText_Cps[2].text = transform_Tf.position.z.ToString();
            
            transformRotText_Cps[0].text = transform_Tf.rotation.x.ToString();
            transformRotText_Cps[1].text = transform_Tf.rotation.y.ToString();
            transformRotText_Cps[2].text = transform_Tf.rotation.z.ToString();
        }
        else
        {
            transformPosText_Cps[0].text = string.Empty;
            transformPosText_Cps[1].text = string.Empty;
            transformPosText_Cps[2].text = string.Empty;
            
            transformRotText_Cps[0].text = string.Empty;
            transformRotText_Cps[1].text = string.Empty;
            transformRotText_Cps[2].text = string.Empty;
        }
    }

    //////////////////////////////////////////////////////////////////////
    // callback
    //////////////////////////////////////////////////////////////////////
    #region callback

    //-------------------------------------------------- 
    public void OnEdit_TransformPosition(int axisIndex)
    {
        if(!transform_Tf)
        {
            return;
        }

        // 
        float posValue_tp;
        float.TryParse(transformPosText_Cps[axisIndex].text, out posValue_tp);

        // 
        transformPos = transform_Tf.position;
        switch(axisIndex)
        {
        case 0:
            transformPos.x = posValue_tp;
            break;
        case 1:
            transformPos.y = posValue_tp;
            break;
        case 2:
            transformPos.z = posValue_tp;
            break;
        }

        // 
        SetTransformPosition();
    }

    //--------------------------------------------------
    public void OnEdit_TransformRotation(int axisIndex)
    {
        if(!transform_Tf)
        {
            return;
        }

        // 
        float rotValue_tp;
        float.TryParse(transformRotText_Cps[axisIndex].text, out rotValue_tp);

        // 
        transformRot = transform_Tf.rotation.eulerAngles;
        switch(axisIndex)
        {
        case 0:
            transformRot.x = rotValue_tp;
            break;
        case 1:
            transformRot.y = rotValue_tp;
            break;
        case 2:
            transformRot.z = rotValue_tp;
            break;
        }

        // 
        SetTransformRotation();
    }

    //--------------------------------------------------
    public void OnSelectTransform(Transform transfrom_Tf_pr)
    {
        transform_Tf = transfrom_Tf_pr;

        SetTransformText();
    }

    //--------------------------------------------------
    public void OnDeselectTransform()
    {
        transform_Tf = null;

        SetTransformText(true);
    }

    #endregion

}
