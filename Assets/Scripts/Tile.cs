using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using System.Text;
[Serializable]
public class Tile : MonoBehaviour
{
    public Vector2 position;

    public SpriteRenderer sr;
    public void Start()
    {
        position = transform.localPosition;
        sr = GetComponent<SpriteRenderer>();
     //   StartCoroutine(ChangeColor());
    }

    public IEnumerator ChangeColor()
    {
        while (true)
        {
            Color32 nc = new Color32((byte)UnityEngine.Random.Range(0, 255), (byte)UnityEngine.Random.Range(0, 255), (byte)UnityEngine.Random.Range(0, 255), 255);
            sr.color = nc;
            yield return new WaitForSeconds(UnityEngine.Random.Range(1, 4));

        }
    }

}

