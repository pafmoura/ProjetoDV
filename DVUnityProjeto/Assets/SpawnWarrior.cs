using UnityEngine;

public class SpawnWarrior : MonoBehaviour
{
    public GameObject allyWarrior;
    public GameObject allyTank;
    public float spawnRadius = 5f;



    [SerializeField] private TroopsManager troopsManager;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Vector3 spawnPosition = GetValidSpawnPosition();
            if (spawnPosition != Vector3.zero)
            {

                if(troopsManager.getCurrentTroopLittle()>0)
                {
                Instantiate(allyWarrior, spawnPosition, Quaternion.Euler(new Vector3(0,120,0)));
                troopsManager.removeTroopLittle(); 
                }
        
            }
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            Vector3 spawnPosition = GetValidSpawnPosition();
            if (spawnPosition != Vector3.zero)
            {
                if(troopsManager.getCurrentTroopBig()>0){
                    Instantiate(allyTank, spawnPosition, Quaternion.Euler(new Vector3(0,120,0)));
                    troopsManager.removeTroopBig();
                }
            }
        }
    }

    private Vector3 GetValidSpawnPosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.transform.position.z;

        Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Collider[] colliders = Physics.OverlapSphere(spawnPosition, spawnRadius);

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("AllyWarrior") || collider.CompareTag("Enemy"))
            {
                // A spawned prefab is too close, return zero to indicate an invalid position
                return Vector3.zero;
            }
        }

        return spawnPosition;
    }
}
