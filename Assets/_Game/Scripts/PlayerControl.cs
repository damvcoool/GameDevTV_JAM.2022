using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] SriptablePlayer player;
    private void Start()
    {
        Instantiate(player);
    }

    

}
