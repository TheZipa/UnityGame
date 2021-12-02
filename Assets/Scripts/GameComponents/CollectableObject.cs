using UnityEngine;
using System.Collections;

public class CollectableObject : MonoBehaviour
{
    public CollectableType Type;
    public enum CollectableType
    {
        Ammo,
        Heart,
        Gem
    }

    [SerializeField] private ParticleSystem _collectParticales;
    [SerializeField] private GameObject _mesh;

    private Collider _collider;
    private AudioController _audioController;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
        _audioController = FindObjectOfType<AudioController>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            switch(Type)
            {
                case CollectableType.Ammo:
                    other.gameObject.GetComponent<PlayerShooter>().AddAmmo(Random.Range(10, 51));
                    break;
                case CollectableType.Heart:

                    HealthPoints playerHealth = other.gameObject.GetComponent<HealthPoints>();

                    if (playerHealth.IsFullHealthPoints())
                        return;
                    else
                        playerHealth.AddHealthPoints(1);

                    break;
                case CollectableType.Gem:
                    other.gameObject.GetComponent<Score>().AddScore(5);
                    break;
            }

            _collectParticales.Play();
            _audioController.PlaySound(2);

            StartCoroutine(WaitForActive());
        }
    }

    private IEnumerator WaitForActive()
    {
        SetCollectableActive(false);

        yield return new WaitForSeconds(Random.Range(25f, 40f));

        SetCollectableActive(true);
    }

    private void SetCollectableActive(bool active)
    {
        _collider.enabled = active;
        _mesh.SetActive(active);
    }
}