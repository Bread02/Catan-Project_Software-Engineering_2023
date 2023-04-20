using System.Collections;
using UnityEngine;

public class HexGrid : MonoBehaviour
{
    public GameObject hexTile;
    public Transform holder;

    [SerializeField] int maxWidth = 11;
    [SerializeField] int maxHeight = 11;

    float tileXOffset = 1.1f;
    float tileZOffset = 0.8f;

    private void Start()
    {
        CreateGrid();
    }

    void CreateGrid()
    {
        float mapXMin = -maxWidth / 2;
        float mapXMax = maxWidth / 2;

        float mapZMin = -maxHeight / 2;
        float mapZMax = maxHeight / 2;

        for (float x = mapXMin; x<mapXMax; x++)
        {
            for (float z = mapZMin; z < mapZMax; z++)
            {
                GameObject TempHex = Instantiate(hexTile);
                Vector3 pos;
                
                if (z%2 == 0)
                {
                    pos = new Vector3(x * tileXOffset, 0, z * tileZOffset);
                }
                else
                {
                    pos = new Vector3(x * tileXOffset + tileXOffset/2, 0, z * tileZOffset);
                }

                StartCoroutine(SetHexInfo(TempHex, x, z, pos));
            }
        }
    }

    IEnumerator SetHexInfo(GameObject hexObject, float x, float z, Vector3 pos)
    {
        yield return new WaitForSeconds(0.0000000000001f);
        hexObject.transform.parent = holder;
        hexObject.name = x.ToString() + ", " + z.ToString();
        hexObject.transform.position = pos;
    }

    private void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }

}
