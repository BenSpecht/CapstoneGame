using UnityEngine;

namespace AnimalBehaviours
{
    public class CorvanineManager : MonoBehaviour
    {

        public GameManager gameManager;
    
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
                    gameManager.AddCorvanineToBook();
                    gameManager.bools.InventoryBools.hasWood = true;
                    gameManager.DisplayWoodRecieved();
                }
            }
        }
    }
}
