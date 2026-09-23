using UnityEngine;

public class FinishActivator : MonoBehaviour, Activator
{
    public ParticleSystem particles;

    void Start()
    {
        particles.Stop();
    }

    public void Activate()
    {
        particles.Play();
    }
}
