using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * A class unused by now
*/

[AddComponentMenu("Aventura_Trófica/CanvasButtons")]
public class CanvasButtons : MonoBehaviour
{
    public GameObject Mariposa;
    public void Fly()
    {   
        // Funciona invluso si sus padres están desactivados
        if(Mariposa.activeInHierarchy == true)
        {

        }
    }
}
