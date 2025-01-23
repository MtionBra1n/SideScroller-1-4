using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyAnimBehaviour : MonoBehaviour
{
    public UnityEvent onEndAttack;
    
    public void EndAttack()
    {
        onEndAttack?.Invoke();
    }
}
