using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
	Fighter[] AllFighters;
	private void Awake()
	{
		AllFighters = FindObjectsOfType<Fighter>();
	}
	
	public void DisplayAttacks()
	{
		foreach (Fighter fi in AllFighters)
			fi.DisplayAttack();
	}
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
