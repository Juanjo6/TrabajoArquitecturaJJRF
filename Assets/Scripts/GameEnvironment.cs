using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; //Funciones de C# 

public class GameEnvironment
{
    private static GameEnvironment instance;

    private List<GameObject> checkpoints1 = new List<GameObject>();
    public List<GameObject> Checkpoints1 { get { return checkpoints1; } }

    private List<GameObject> checkpoints2 = new List<GameObject>();
    public List<GameObject> Checkpoints2 { get { return checkpoints2; } }

    private List<GameObject> checkpoints3 = new List<GameObject>();
    public List<GameObject> Checkpoints3 { get { return checkpoints3; } }

    private List<GameObject> checkpoints4 = new List<GameObject>();
    public List<GameObject> Checkpoints4 { get { return checkpoints4; } }

    private List<GameObject> checkpoints5 = new List<GameObject>();
    public List<GameObject> Checkpoints5 { get { return checkpoints5; } }

    public static GameEnvironment Singleton
    {
        get
        {
            if (instance == null)
            {
                instance = new GameEnvironment();
                //Rellenamos las listas
                instance.Checkpoints1.AddRange(
                    GameObject.FindGameObjectsWithTag("Checkpoint1"));
                //Ordena alfabéticamente los checkpoints y los vuelve a meter dentro de la misma lista ordenados
                instance.checkpoints1 = instance.checkpoints1.OrderBy(waypoint => waypoint.name).ToList();
                instance.Checkpoints2.AddRange(
                    GameObject.FindGameObjectsWithTag("Checkpoint2"));
                //Ordena alfabéticamente los checkpoints y los vuelve a meter dentro de la misma lista ordenados
                instance.checkpoints2 = instance.checkpoints2.OrderBy(waypoint => waypoint.name).ToList();
                instance.Checkpoints3.AddRange(
                    GameObject.FindGameObjectsWithTag("Checkpoint3"));
                //Ordena alfabéticamente los checkpoints y los vuelve a meter dentro de la misma lista ordenados
                instance.checkpoints3 = instance.checkpoints3.OrderBy(waypoint => waypoint.name).ToList();
                instance.Checkpoints4.AddRange(
                    GameObject.FindGameObjectsWithTag("Checkpoint4"));
                //Ordena alfabéticamente los checkpoints y los vuelve a meter dentro de la misma lista ordenados
                instance.checkpoints4 = instance.checkpoints4.OrderBy(waypoint => waypoint.name).ToList();
                instance.Checkpoints5.AddRange(
                    GameObject.FindGameObjectsWithTag("Checkpoint5"));
                //Ordena alfabéticamente los checkpoints y los vuelve a meter dentro de la misma lista ordenados
                instance.checkpoints5 = instance.checkpoints5.OrderBy(waypoint => waypoint.name).ToList();
            }
            return instance;
        }
    }
}