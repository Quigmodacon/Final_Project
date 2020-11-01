using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float MaxHP = 1000;
    public float CurHP;
    bool reducing;
    // Start is called before the first frame update
    void Awake()
    {
        CurHP = MaxHP;
        reducing = false;
    }

    

    // Update is called once per frame
    public void TakeDamage(float amount) {
        CurHP -= amount;
        if (CurHP <= 0) {
            Die();
        }
    }

    public void Heal(int amount) {
        CurHP += amount;
        if (CurHP > 100 && !reducing) {
            reducing = true;
            Invoke("Reduce", 0.5f);
        }
    }

    void Reduce() {
        if (CurHP > 100) {
            CurHP -= 1;
            reducing = true;
            Invoke("Reduce", 0.5f);
        }
        reducing = false;
    }

    void Die() {
        Destroy(gameObject);
    }
}
