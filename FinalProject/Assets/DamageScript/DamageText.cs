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
        if(SaveData.whiteblock == true)
        {
            damageText.GetComponent<TextMeshProUGUI>().color = Color.white;
        }
        if (SaveData.redblock == true)
        {
            damageText.GetComponent<TextMeshProUGUI>().color = Color.red;
        }
        if (SaveData.blueblock == true)
        {
            damageText.GetComponent<TextMeshProUGUI>().color = Color.blue;
        }
        if (SaveData.greenblock == true)
        {
            damageText.GetComponent<TextMeshProUGUI>().color = Color.green;
        }
        if (SaveData.purpleblock == true)
        {
            damageText.GetComponent<TextMeshProUGUI>().color = new Color(0.3f, 0f, 0.5f);
        }
        damageText.GetComponent<TextMeshProUGUI>().text = hitDamage.ToString();
    }
}
