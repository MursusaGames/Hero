using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private int damage = 5;
    private void OnEnable()
    {
        Destroy(gameObject,4f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(nameof(Player)))
        {
            other.gameObject.GetComponent<UnitController>().TakeDamage(damage);
            Destroy(gameObject);
        }        
    }    
}
