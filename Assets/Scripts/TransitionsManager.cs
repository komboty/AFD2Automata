using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

/// <summary>
/// Script que controla las transiciones de un estado.
/// </summary>
public class TransitionsManager : MonoBehaviour
{
    // Constantes del juego.
    public Constants constants;
    // Cadena a mover por las transiciones.
    public SplineAnimate stringMove;
    /*
    // Es estado inicial?.
    public bool isStateInitial = false;
    // Transicion inicial.
    public SplineContainer transitionInitial;
    */
    // Transiciones.
    //public List<SplineContainer> transitions;
        
    void Start()
    {
        /*
        if(isStateInitial)
        {
            stringMove.Container = transitionInitial;
            Invoke(nameof(Play), 1);
        }
        */
    }

// Update is called once per frame
    void Update()
    {
        /*
       if (!stringMove.IsPlaying)
       {
           Debug.Log("IsPlaying");

           if (numSpline < splineContainers.Length)
           {
               numSpline++;
               splineAnimate.Container = splineContainers[numSpline];
               Invoke(nameof(Play), 1);
           }
           
    }*/

    }

    public void Play()
    {        
        //Debug.Log("play");
        stringMove.Play();
    }

    /*
    public void StartAutomata()
    {
        stringMove.Container = transitionInitial;
        stringMove.Play();
    }
    */

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.name);
        // Si la cadena entro al estado.
        if (other.CompareTag(constants.tagString))
        {
            // Se asigna la transicion segun el simbolo.
            for (int i = 0; i < transform.childCount; i++)
            {
                Transform transition = transform.GetChild(i);

                // Si el primer simbolo de la cadena es igual al de la transicion.
                if (other.transform.GetChild(0).name == transition.name)
                {
                    Debug.Log("Ir a transicion " + transition.name);
                    stringMove.Container = transition.GetComponent<SplineContainer>();
                    //Invoke(nameof(stringMove.Play), 1f);
                    stringMove.Restart(true);
                    //Invoke(nameof(stringMove.Play), 1);
                    return;
                }
            }
        }
    }
}
