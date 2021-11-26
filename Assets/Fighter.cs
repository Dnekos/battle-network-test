using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Attack
{
	public Vector2[] TargetedSpaces;
	public int Damage;

	public Attack()
	{
		Damage = 0;
	}
}

public class Fighter : MonoBehaviour
{
	[SerializeField] bool isPlayer;

	[SerializeField] GridManager GM;
	[SerializeField] CombatManager CM;
	[SerializeField] Attack currentAttack;
	Vector2 pos;

	float height;
	//Vector3 LocalPosition;
	LayerMask mask;

    // Start is called before the first frame update
    void Start()
    {
		//LocalPosition = transform.localPosition;
		height = transform.position.y;

		//pos = GM.GetPositionAt(transform.parent);
		//DisplayAttack();

		mask = (isPlayer) ? LayerMask.GetMask("PlayerTiles") : LayerMask.GetMask("EnemyTiles");
		
		PlaceOnBelowTile();
	}

	// Update is called once per frame
	void Update()
    {

	}

	public void DisplayAttack()
	{
		GM.DisplayAttack(pos, currentAttack.TargetedSpaces);
	}

	void OnMouseDrag()
	{
		if (!isPlayer)
			return;
		 
		Plane plane = new Plane(Vector3.up, new Vector3(0, height, 0));
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		float distance;

		if (plane.Raycast(ray, out distance))
		{
			transform.position = ray.GetPoint(distance);
		}
	}

	void PlaceOnBelowTile()
	{
		Ray ray = new Ray(transform.position, Vector3.down);
		RaycastHit info;

		if (Physics.Raycast(ray, out info, 20, mask))
		{
			transform.SetParent(info.transform);
			pos = GM.GetPositionAt(info.transform);
			GM.Refresh();
			CM.DisplayAttacks();
			//GM.DisplayAttack(pos, currentAttack.TargetedSpaces);

		}

		transform.localPosition = new Vector3(0,2,0);
	}
	private void OnMouseUp()
	{
		if (!isPlayer)
			return;

		PlaceOnBelowTile();
	}
}