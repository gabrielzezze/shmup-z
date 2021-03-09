using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehaviour : MonoBehaviour, IDamageable {
    
    private int lifes;
    // Start is called before the first frame update
    void Start() {
        lifes = 1;
    }

    public void TakeDamage() {
        lifes--;
        if (lifes <= 0) Die();
    }

    public void Die() {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update() {}

    
}
