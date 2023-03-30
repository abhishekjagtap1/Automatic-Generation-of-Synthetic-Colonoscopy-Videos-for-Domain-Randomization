using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTexture : MonoBehaviour
{

    [SerializeField]
    private GameObject Colon;

    [SerializeField]
    private Texture[] textures;

    private Renderer ColonRenderer;

    private int randomTextureIndex;


    // Use this for initialization
    void Start()
    {
        ColonRenderer = Colon.GetComponent<Renderer>();
        gameObject.GetComponent<Button>().onClick.AddListener(ChangeColonTexture);
    }

    // Update is called once per frame
    private void ChangeColonTexture()
    {
        randomTextureIndex = Random.Range(0, textures.Length);
        ColonRenderer.material.mainTexture = textures[randomTextureIndex];
    }
}
