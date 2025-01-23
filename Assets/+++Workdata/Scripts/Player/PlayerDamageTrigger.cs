using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerDamageTrigger : MonoBehaviour
{
    [SerializeField] private int weaponDamage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyInformation>().GetDamage(weaponDamage);
        }
    }
}
