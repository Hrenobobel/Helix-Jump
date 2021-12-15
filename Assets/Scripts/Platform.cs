using UnityEngine;

namespace Assets.Scripts
{
    public class Platform : MonoBehaviour
    {
        public float FlyUpPower;
        public int DestroyTime;
        public GameObject PlatformParticle;

        private Rigidbody[] _rigidbodymassive;
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Player player))
            {
                player.CurrentPlatform = this;
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (!other.TryGetComponent(out Player player)) return;

            player.Scores += 20;

            Instantiate(PlatformParticle, transform);

            _rigidbodymassive = GetComponentsInChildren<Rigidbody>();
            foreach (Rigidbody _rigidbody in _rigidbodymassive)
            {
                _rigidbody.isKinematic = false;
                _rigidbody.AddForce(Vector3.up * FlyUpPower, ForceMode.Impulse);
            }
            Destroy(this.gameObject, DestroyTime);
        }
    }
}