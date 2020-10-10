using UnityEngine;

namespace AnimalBehaviours
{
    public class CorvanineManager : MonoBehaviour
    {

        public GameManager gameManager;

        public GameObject planks;
    
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
            {
                if (!gameManager.bools.InventoryBools.hasCovanineBaby)
                {
                    gameManager.DisplaySaveBaby();
                }
                else
                {
                    // Add to journal and provide wood
                    planks.SetActive(true);
                    FMODUnity.RuntimeManager.PlayOneShot("event:/Planks/Planks_Drop", GetComponent<Transform>().position);
                    gameManager.AddCorvanineToBook();
                    gameManager.bools.AnimalsMetBools.CorvinineMet = true;
                    //gameManager.bools.InventoryBools.hasWood = true;
                   // gameManager.DisplayWoodRecieved();
                    
                }
            }
        }
    }
}
