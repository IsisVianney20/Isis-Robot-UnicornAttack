using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InstantiateObject : MonoBehaviour
{
   [SerializeField]
   private GameObject _objectToinstantiate;
   [SerializeField]
   private Stack<GameObject> _objectPool = new Stack<GameObject>();
   public GameObject ObjectToInstantiate => _objectToinstantiate;

   public void InstantiateObjectAPosition(Transform asset)
   {
     GameObject obj = CreateInstantiate();
     obj.transform.position = asset.position;
   }

   public GameObject CreateInstantiate()
   {
     GameObject obj;
     
     if (_objectPool.Count > 0)
     {
      obj = _objectPool.Pop();
      obj.SetActive(true);
     }
     else
     {
       obj = Instantiate(_objectToinstantiate, transform.position, Quaternion.identity);
       obj.GetComponent<ObjectFromPool>().onDeactivate.AddListener(OnObjectDeactivated);
     }
     return obj;
   }

   public void OnObjectDeactivated(GameObject obj)
   {
     _objectPool.Push(obj);
   }
}
