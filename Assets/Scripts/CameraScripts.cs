using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScripts : MonoBehaviour
{

    public GameObject Canna;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Canna != null)
        {
            //basicamente, el script copia la posición del personaje y se lo aplica a la camara
            Vector3 position = transform.position;
            position.x = Canna.transform.position.x;
            position.y = Canna.transform.position.y + 0.2f;
            transform.position = position;
        }
    }
}
