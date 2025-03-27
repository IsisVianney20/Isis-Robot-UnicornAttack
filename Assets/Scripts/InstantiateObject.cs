using UnityEngine;

public class InstantiateObject : MonoBehaviour
{
   [SerializeField]
   private GameObject _objectToinstantiate;

   public void InstantiateObjectAPosition(Transform asset)
   {
     Instantiate(_objectToinstantiate, asset.position, Quaternion.identity);
   }
}
