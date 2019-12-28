using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroBase : MonoBehaviour
{
    internal static float hp;//здоровье
    internal static float ShootSpeed;//скорость стрельбы
    float speed;//скорость передвижения
    float damage;//урон
    private int HP;

    public List<GameObject> HeroAll; // герои

    public List<GameObject> Ability1; // кнопка абилки 1
    public List<GameObject> Ability2; // кнопка абилки 2

    private void Awake()
    {
        HP = CharControl.hp;
    }
    private void Update()
    {
        
    }
}
