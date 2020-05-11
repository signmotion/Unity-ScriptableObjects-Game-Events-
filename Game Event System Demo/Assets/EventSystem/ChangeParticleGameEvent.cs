using UnityEngine;


[CreateAssetMenu(menuName = "Game Events / Change Particle")]
public class ChangeParticleGameEvent : GameEvent
{
    public Color startColor;

    public override Color GetColor() { return startColor; }
}