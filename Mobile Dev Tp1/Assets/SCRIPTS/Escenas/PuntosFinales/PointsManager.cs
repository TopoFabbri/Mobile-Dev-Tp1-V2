using UnityEngine;
using UnityEngine.UI;

namespace Escenas.PuntosFinales
{
    public class PointsManager : MonoBehaviour
    {
        [SerializeField] private Text money1;
        [SerializeField] private Text money2;
        [SerializeField] private Image winnerImg;
        [SerializeField] private Sprite p2Img;
                
        private void Awake()
        {
            money1.text = DatosPartida.LadoGanadaor == DatosPartida.Lados.Izq ? "$" + DatosPartida.PtsGanador : "$" + DatosPartida.PtsPerdedor;
            money2.text = DatosPartida.LadoGanadaor == DatosPartida.Lados.Der ? "$" + DatosPartida.PtsGanador : "$" + DatosPartida.PtsPerdedor;
            
            if (DatosPartida.LadoGanadaor != DatosPartida.Lados.Izq)
                winnerImg.sprite = p2Img;
        }
    }
}