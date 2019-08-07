using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface iShootable 
{
    void shoot();
    int ammo();
    bool addAmmo(int amout,string type);
}
