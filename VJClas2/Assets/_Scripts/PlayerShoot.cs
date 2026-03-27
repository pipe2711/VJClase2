using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform originBuller;

    // Limita la cantidad de balas que pueden estar en pantalla al mismo tiempo
    public int maxShots = 3;
    private List<GameObject> activeBullets = new List<GameObject>();

    public void Shoot(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            // Limpia de la lista cualquier bala que ya haya sido destruida
            activeBullets.RemoveAll(b => b == null);

            // Solo dispara si hay menos de 3 balas activas en pantalla
            if (activeBullets.Count < maxShots)
            {
                GameObject bullet = Instantiate(bulletPrefab, originBuller.position, originBuller.rotation);
                activeBullets.Add(bullet);
                
                // La bala se destruirá en 1 segundo (o antes si choca con una pared/enemigo)
                Destroy(bullet, 1);
            }
        }
    }
}
