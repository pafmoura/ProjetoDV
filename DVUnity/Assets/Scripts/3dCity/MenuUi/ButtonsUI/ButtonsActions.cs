using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ButtonsActions : MonoBehaviour
{

    [SerializeField] private ResourcesManager resourcesManager;
    [SerializeField] private CanvasBuildScript canvasToShow;

    // aqui estara o levelbuild para poder mandar o nome do edicio para o canvas

    public void viewCanvasFarm()
    {

        canvasToShow.enableCanvas("Farm");
    //resourcesManager.addWood(10);
    }

    public void viewCanvasWood()
    {
        canvasToShow.enableCanvas("Sawmill");
    }

    public void viewCanvasRock()
    {
        canvasToShow.enableCanvas("Mine");
    }

    public void viewCanvasPort()
    {
        canvasToShow.enableCanvas("Port");
    }

    public void viewCanvasTownHall()
    {
        canvasToShow.enableCanvas("TownHall");
    }

    public void viewCanvasQuartel()
    {
        canvasToShow.enableCanvas("Quartel");
    }

    public void viewCanvasMarket()
    {
        canvasToShow.enableCanvas("Market");
    }

    



}
