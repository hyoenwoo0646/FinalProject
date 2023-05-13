using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageText : MonoBehaviour
{
    private static DamageText instance = null;

    public static DamageText Instance
    {
        get
        {
            if (null == instance)
            {
                instance = GameObject.FindObjectOfType<DamageText>();

                if(null == instance)
                {
                    Debug.Log("데미지텍스트 없음");
                }
            }
            return instance;
        }
    }


    public Canvas canvas;
    public GameObject dmgTxt;


    public void CreateDamageText(Vector3 hitPoint, int hitDamage)
    {
        GameObject damageText = Instantiate(dmgTxt, hitPoint, Quaternion.identity, canvas.transform);
        damageText.GetComponent<TextMeshPro>().text = hitDamage.ToString();
    }
}
