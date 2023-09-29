using UnityEngine;

public class LoopTextura : MonoBehaviour
{
    public float Intervalo = 1;
    float Tempo = 0;

    public Texture2D[] Imagenes;
    [SerializeField] private Texture2D[] ImagesMob;
    int Contador = 0;
    
    private Renderer rend;

    // Use this for initialization
    void Start()
    {
        rend = GetComponent<Renderer>();
        
        if (Imagenes.Length > 0)
            rend.material.mainTexture = Imagenes[0];
    }

    // Update is called once per frame
    void Update()
    {
        Tempo += Time.deltaTime;

        if (Tempo >= Intervalo)
        {
            Tempo = 0;
            Contador++;
            
            if (Contador >= Imagenes.Length)
                Contador = 0;

            rend.material.mainTexture = Application.isMobilePlatform ? ImagesMob[Contador] : Imagenes[Contador];
        }
    }
}