using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class EnemyInformation : MonoBehaviour
{
    public static readonly int Hash_onDeath = Animator.StringToHash("onDeath");

    [SerializeField] private Animator anim;
    
    
    [SerializeField] private int maxEnemyHealthpoints;
    [SerializeField] private int currentEnemyHealthpoints;
    [SerializeField] private Image healthbar;
    [SerializeField] private ColorSpriteSetter _colorSpriteSetter;
    [SerializeField] private float destroyTimer;
    private void Awake()
    {
        currentEnemyHealthpoints = maxEnemyHealthpoints;
        RefreshHealthbar();
    }

    public void GetDamage(int dmg)
    {
        if (currentEnemyHealthpoints < 1) return;
        
        currentEnemyHealthpoints -= dmg;
        
        _colorSpriteSetter.ColorObject();
        
        if (currentEnemyHealthpoints < 1)
        {
            anim.SetTrigger(Hash_onDeath);
            Invoke("DestroyEnemy", destroyTimer);
        }
        
        RefreshHealthbar();
    }

    public void GetHealthpoints(int healthpoints)
    {
        currentEnemyHealthpoints += healthpoints;

        if (currentEnemyHealthpoints > maxEnemyHealthpoints)
        {
            currentEnemyHealthpoints = maxEnemyHealthpoints;
        }
        
        RefreshHealthbar();
    }

    void RefreshHealthbar()
    {
        healthbar.fillAmount = (float)currentEnemyHealthpoints / (float)maxEnemyHealthpoints;
    }

    void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
