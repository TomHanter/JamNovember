using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexogenChange : MonoBehaviour
{
    [SerializeField] private GameObject _newObject; 
    [SerializeField] private HexGrid hexGrid;

    public void ReplaceObjectAtPosition(GameObject targetObject)
    {
        if (targetObject != null && _newObject != null)
        {
            // Сохраняем позицию и поворот целевого объекта
            Vector3 position = targetObject.transform.position;
            Quaternion rotation = targetObject.transform.rotation;

            // Удаляем целевой объект
            Destroy(targetObject);

            // Создаем новый объект на месте удаленного
            Instantiate(_newObject, position, rotation);
            hexGrid.FindAllHex();

            Debug.Log("Object replaced with new object at the same position.");
        }
        else
        {
            Debug.LogWarning("Target object or new object reference is missing.");
        }
    }
}
