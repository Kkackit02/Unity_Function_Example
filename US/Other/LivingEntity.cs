using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LivingEntity : MonoBehaviour, IDamageable
{


        public float startingHealth = 100f;
        public float health { get; protected set; }
        public bool dead { get; protected set; }
        public event Action onDeath;

        protected virtual void OnEnable()
        {
                dead = false;

                health = startingHealth;
        }

        
        public virtual void OnDamage(float damage)
        {
                health -= damage;

                if (health <= 0 && dead == false)
                {
                        Die();
                }
        }

        public virtual void RestoreHealth(float newHealth)
        {
                if (dead == true)
                {
                        return;
                }

                health += newHealth;
        }

        public virtual void Die()
        {
                if (onDeath != null)
                {
                        onDeath();
                }
                
                dead = true;
        }


}
