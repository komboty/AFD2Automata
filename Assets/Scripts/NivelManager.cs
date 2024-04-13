using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Splines;

/// <summary>
/// Script que maneja el nivel.
/// </summary>
public class NivelManager : MonoBehaviour
{
    // Constantes del juego.
    public Constants constants;
    // Cadena a mover por las transiciones.
    public SplineAnimate stringMove;
    // Transicion inicial.
    public SplineContainer transitionInitial;

    public void StartAutomata()
    {
        stringMove.Container = transitionInitial;
        stringMove.Restart(true);
        CameraController.instance.followTransform = stringMove.transform;
    }

    public void Restart()
    {
        SceneManager.LoadScene(constants.SceneNameNivel1);
    }
}
