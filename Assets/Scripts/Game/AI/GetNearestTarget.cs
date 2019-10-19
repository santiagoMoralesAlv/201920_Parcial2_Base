using AI;
using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class GetNearestTarget : Node
{
    public override void Execute()
    {
        //Vector3.Magnitude(this.transform.position-player.transform.position)
        List<PlayerController> listaTemporal = GameController.Instance.Players;
        PlayerController[] listaTemporal2 = GameController.Instance.Players.ToArray();
        //listaTemporal.Remove(this.GetComponent<PlayerController>());

        IOrderedEnumerable<PlayerController> lista = listaTemporal2.OrderBy(player => Vector3.Magnitude(this.transform.position - player.transform.position));

        Debug.Log("Nuevo enemigo: "+ lista.ElementAt(1).gameObject.name);
        this.GetComponent<AIController>().Target = lista.ElementAt(1).gameObject;
        //Debug.LogError(lista.First().gameObject.name+" primero "+ lista.First().gameObject.transform.position);

    }
}