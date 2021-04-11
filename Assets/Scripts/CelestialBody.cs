using UnityEngine;

public abstract class CelestialBody : MonoBehaviour
{
    private void Update() => Move();
    protected abstract void Move();
}
