using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharOrther : CharBase
{
    [SerializeField] private HeroMain.HeroAction heroAction;

    public virtual float ActionTargetHero() {
        return 0;
    }
}
