﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    // Start is called before the first frame update
    bool ApplyDamage(DamageMessage damageMessage);
}
