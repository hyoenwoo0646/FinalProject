using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextUp : MonoBehaviour
{
    private void Start()
    {
        Invoke("DestroyText", 1f);
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up;
    }

    public void DestroyText()
    {
        Destroy(gameObject);
    }
}
