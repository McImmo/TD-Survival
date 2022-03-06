using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{

    public GameObject mapTile;
    public GameObject NexusPrefab;
    private GameObject Nexus;

    [SerializeField]
    private int mapWidth;   //bitte nur ungerade
    [SerializeField]
    private int mapHeight;  //bitte nur ungerade, mindestens 11

    private List<GameObject> mapTiles = new List<GameObject>();
    private List<GameObject> topPath = new List<GameObject>();
    private List<GameObject> bottomPath = new List<GameObject>();

    private bool reachedX = false;

    private GameObject currentTile;
    private int currentIndex;
    private int nextTile;
    private void Start()
    {
        generateMap();
    }

    //beliebige Reihe
    private List<GameObject> getRow(int y)  //bottom row is "row 0" and not "row 1"
    {
        List<GameObject> row = new List<GameObject>();

        for (int i = y*mapWidth; i < (y+1)*mapWidth; i++)
        {
            row.Add(mapTiles[i]);
        }

        return row;
    }
    

    //unterste Reihe
    private List<GameObject> getBottomEdgeTiles() 
    {
        List<GameObject> bottomEdgeTiles = getRow(0);
        return bottomEdgeTiles;
    }


    //oberste Reihe
    private List<GameObject> getTopEdgeTiles() 
    {
        List<GameObject> bottomEdgeTiles = getRow(mapHeight-1);
        return bottomEdgeTiles;
    }

    //waehlt random aus einer Liste (nur gemacht fuer Listen mit Laenge "Mapwidth")
    private GameObject randomFromRow(List<GameObject> row)  
    {
        int rand = Random.Range(0, mapWidth); //Range geht von 0 bis mapRange-1, deshalb funktioniert es
        GameObject pick = row[rand];
        return pick;
    }





    //Pfad von einer node zur naechsten
    private List<GameObject> generatePath(GameObject startNode, GameObject endNode)
    {
        List<GameObject> path = new List<GameObject>();

        int pathLength = 0;
        float endX = endNode.transform.position.x;  //Start-Koordinaten
        float endY = endNode.transform.position.y;  //

        currentTile = startNode;
        currentIndex = mapTiles.IndexOf(currentTile);

        int loopCounter = 0;
            while(currentTile.transform.position.x > endX)  //wenn rechts von endNode
            {
                pathLength++;
                path.Add(currentTile);
                moveLeft();
                loopCounter++;

                if(loopCounter > 100)
                {
                    Debug.Log("loopBreak");
                    break;
                }
            }

            while(currentTile.transform.position.x < endX)  //wenn links von endNode
            {
                pathLength++;
                path.Add(currentTile);
                moveRight();
                loopCounter++;

                if(loopCounter > 100)
                {
                    Debug.Log("loopBreak");
                    break;
                }

            }
            if(currentTile.transform.position.x == endX)
            {
                
        while (currentTile.transform.position.y > endY)    //man muss runterwandern
        {
            pathLength++;
            path.Add(currentTile);
            moveDown();
        }

        while (currentTile.transform.position.y < endY)    //man muss hochwandern
        {
            pathLength++;
            path.Add(currentTile);
            moveUp();
        }

        if(currentTile.transform.position.y == endY)    //man muss nach links oder rechts wandern
        {
                Debug.Log("currentTile gleich endNode");
        }
            }
        
        
        Debug.Log("Pfadlaenge " + pathLength);
        for (int i = 0; i < pathLength; i++)
        {
            Destroy(path[i]);
            Debug.Log("Objekt zerstoert" + i);
        }

        return path;
    }




    private void moveDown()
    {
        currentTile = mapTiles[currentIndex-mapWidth];  //wandert auf das gleiche Feld eine Reihe tiefer
        currentIndex = mapTiles.IndexOf(currentTile);
    }

    private void moveLeft()
    {
        currentTile = mapTiles[currentIndex-1];
        currentIndex = mapTiles.IndexOf(currentTile);
    }

    private void moveRight()
    {
        currentTile = mapTiles[currentIndex+1];
        currentIndex = mapTiles.IndexOf(currentTile);
    }

    private void moveUp()
    {
        currentTile = mapTiles[currentIndex+mapWidth];
        currentIndex = mapTiles.IndexOf(currentTile);
    }



    //erstellt den Kristall mittig der Map (Koordinaten nicht 0/0)
    private void createNexus() 
    {
        int index = (mapHeight * mapWidth -1)/2;
        Nexus =  Instantiate(NexusPrefab);

        Destroy(mapTiles[index]);
        mapTiles[index] = Nexus;

        Nexus.transform.position = new Vector2((mapWidth-1)/2, (mapHeight-1)/2);
    }

    private void generateMap()
    {
        for (int y = 0; y < mapHeight; y++)     //mapBereich wird mit Grass gefuellt
        {
            for (int x = 0; x < mapWidth; x++)
            {
                GameObject newTile =  Instantiate(mapTile);

                mapTiles.Add(newTile);

                newTile.transform.position = new Vector2(x, y);
            }
        }

        createNexus();  //erstellt Nexus

        GameObject startTop = randomFromRow(getTopEdgeTiles());    //random aus der oberen Reihe
        GameObject StartBottom = randomFromRow(getBottomEdgeTiles());   //random aus der unteren Reihe


        //Pfadgenerierung
        topPath = generatePath(startTop, Nexus);

        Destroy(StartBottom);

    }

}