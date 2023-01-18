using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour, IEntity
{
    public bool touched = false;

    public void OnCollision()
    {
        touched = true;
        //if (!touched) GameController.instance.score++;
    }
}
