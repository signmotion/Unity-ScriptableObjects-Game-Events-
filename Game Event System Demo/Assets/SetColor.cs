using UnityEngine;


public class SetColor : MonoBehaviour
{
    public void Run(Color color)
    {
        Debug.LogFormat("SetColor.Run() color {0}", color);
        ParticleSystem.MainModule psMain =
            gameObject.GetComponent<ParticleSystem>().main;
        psMain.startColor = color;
    }
}
