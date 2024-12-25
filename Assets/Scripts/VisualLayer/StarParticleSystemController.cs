using UnityEngine;

namespace Quiz.VisualLayer
{
    public class StarParticleSystemController
    {
        private ParticleSystem particleSystem;

        public StarParticleSystemController(ParticleSystem particleSystem)
        {
            this.particleSystem = particleSystem;
        }

        public void SetParticleSystemPosition(Vector3 position)
        {
            particleSystem.transform.position = position;
        }

        public void PlayParticleSystem()
        {
            particleSystem.Play();
        }
    }
}