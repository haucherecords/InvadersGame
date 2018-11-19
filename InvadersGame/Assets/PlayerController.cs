﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(Rigidbody))]
/*
 * Require component se utiliza para indicarle a Unity que para que este script funcione correctamente
 * el GameObject en el que fue atachado debe tener un componente del tipo indicado (En este caso Rigidbody).
 * Si atachamos este script a un GameObject que no lo tenga nos dará un error y no nos dejará correr nuestro juego.
 */
public class PlayerController : MonoBehaviour {

    [SerializeField] private float moveSpeed;
    private Rigidbody rb;
    /*
     * Los Rigidbodies le permite a sus GameObjects actuar bajo el control de la física. 
     * El rigidbody que utilizamos tiene la opción Freeze Rotation de todos los axis activada para que no pueda girarse.
     */

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        /*
         * Busca el primer componente del tipo indicado que este attachado en el GameObject que contiene este script, 
         * si no encuentra ninguno devuelve null. Si rb fuese null y tratásemos de accederlo Unity lanzaría una null 
         * pointer exception y se cortaría la ejecución del programa.
         * Como nuestro código utiliza [RequireComponent(typeof(Rigidbody))] nunca recibiremos null, no es necesario
         * checkear si fue null en el resto del código.
         */
    }


    // Update is called once per frame
    void Update () {

        float horizontalValue = Input.GetAxisRaw("Horizontal");
        /*
         * Input.GetAxisRaw("Horizontal") devuelve 1 si el jugador va a moverse a la derecha y -1 si va moverse a la izquierda.
         * Este método proporcionado por Unity permite abstraerse de lo que se utilice para mover el jugador, funciona para
         * teclado tanto para joystick.
         */

        if (horizontalValue == 1)
        {
            rb.velocity = Vector3.right * moveSpeed;
        }
        else if (horizontalValue == -1)
        {
            rb.velocity = Vector3.left * moveSpeed;
        }
        else
        {
            rb.velocity = Vector3.zero; //Si no se está moviendo para la izquierda ni para la derecha se le setea velocidad 0 así se queda quieto

        }

    }

}
