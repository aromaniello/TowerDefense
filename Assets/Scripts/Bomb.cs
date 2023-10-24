using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bomb : MonoBehaviour
{
    [SerializeField] private List<Transform> _damageList = new List<Transform>();
    [SerializeField] private int _damagePower = 50;
    [SerializeField] private UnityEvent OnDamageDealt;
    [SerializeField] private Renderer _renderer;
    [SerializeField] private int _delayBeforeExplosion = 1;
    [SerializeField] private float _blinkDuration = 0.1f;
    [SerializeField] private float _blinkDelayDecreaseRate = 0.1f;
    [SerializeField] private string _tagToCompare = "Weapon";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_tagToCompare))
        {
            _damageList.Add(other.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _damageList.Remove(other.transform);
    }

    private void Start()
    {
        StartCoroutine(ExplodeRoutine());
    }

    IEnumerator ExplodeRoutine()
    {
        float blinkDelay = 1;
        while (blinkDelay > 0)
        {
            yield return new WaitForSeconds(blinkDelay);
            _renderer.material.SetColor("EmissionColor", Color.white);
            yield return new WaitForSeconds(_blinkDuration);
            _renderer.material.SetColor("EmissionColor", Color.red);
            blinkDelay -= _blinkDelayDecreaseRate;
        }
        _renderer.material.SetColor("EmissionColor", Color.white);
        yield return new WaitForSeconds(_delayBeforeExplosion);
        foreach (var weapon in _damageList)
        {
            if (TryGetComponent(out Health health))
            {
                health.ReceiveDamage(_damagePower);
            }
        }

        OnDamageDealt?.Invoke();
    }
}
