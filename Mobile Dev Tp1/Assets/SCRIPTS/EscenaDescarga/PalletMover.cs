﻿public class PalletMover : ManejoPallets {

    public MoveType miInput;
    public enum MoveType {
        WASD,
        Arrows
    }

    public ManejoPallets Desde, Hasta;
    bool segundoCompleto = false;
    
    private void Update()
    {
        switch (miInput) {
            case MoveType.WASD:
                if (!Tenencia() && Desde.Tenencia() && InputManager.Instance.GetAxis("Giro1") < .8f)
                    PrimerPaso();
                if (Tenencia() && InputManager.Instance.GetAxis("Vertical1") > .8f)
                    SegundoPaso();
                if (segundoCompleto && Tenencia() && InputManager.Instance.GetAxis("Giro1") > .8f)
                    TercerPaso();
                break;
            
            case MoveType.Arrows:
                if (!Tenencia() && Desde.Tenencia() && InputManager.Instance.GetAxis("Giro2") < .8f)
                    PrimerPaso();
                if (Tenencia() && InputManager.Instance.GetAxis("Vertical2") > .8f)
                    SegundoPaso();
                if (segundoCompleto && Tenencia() && InputManager.Instance.GetAxis("Giro2") > .8f)
                    TercerPaso();
                break;
        }
    }

    void PrimerPaso() {
        Desde.Dar(this);
        segundoCompleto = false;
    }
    void SegundoPaso() {
        base.Pallets[0].transform.position = transform.position;
        segundoCompleto = true;
    }
    void TercerPaso() {
        Dar(Hasta);
        segundoCompleto = false;
    }

    public override void Dar(ManejoPallets receptor) {
        if (Tenencia()) {
            if (receptor.Recibir(Pallets[0])) {
                Pallets.RemoveAt(0);
            }
        }
    }
    public override bool Recibir(Pallet pallet) {
        if (!Tenencia()) {
            pallet.Portador = this.gameObject;
            base.Recibir(pallet);
            return true;
        }
        else
            return false;
    }
}
