using UnityEngine;
using System.Collections;


public class MainGUI : MonoBehaviour
{
    NIInput m_input; ///< @brief The input we get the axes from.

    public Hashtable categories;
    public Texture upTexture;
    public Texture downTexture;
    public GUISkin customSkin;
    int itemTopIndex = 0;
    int ITEMWIDTH = 140;
    int ITEMHEIGHT = 140;

    //items for each category: "Upper Garment", "Pant", "Dress", "Shoes", "Accesory" 
    public Texture[] upperGarment;
    public Texture[] pant;
    public Texture[] dress;
    public Texture[] shoes;
    public Texture[] accessory;
    public Texture[][] catTest;
    ArrayList catArray;
    /// mono-behavior start - initializes the input
    public void Start()
    {
        m_input = FindObjectOfType(typeof(NIInput)) as NIInput;
       // categories.Add(categoryStrings[0], upperGarment);
        //categories.Add(categoryStrings[1], pant);
        //categories.Add(categoryStrings[2], dress);
        //categories.Add(categoryStrings[3], shoes);
        //categories.Add(categoryStrings[4], accessory);
        //catTest[0] = upperGarment;
        //catArray.Add(upperGarment);
    }

    /// mono-behavior OnGUI to show GUI elements
    public void OnGUI()
    {
        //debug
       

        GUI.skin = customSkin;

        //GUILayout.Button("I am a custom styled Button", "MyCustomControl");
        // create a regular label
        myRect.x = 20;
        myRect.y = 20;
        myRect.width = 300;
        myRect.height = 30;
        //GUI.Label(myRect, "Welcome to Virtual Dressing Room! ^_^");


        // place the first button
        //myRect.x = 20;
        //myRect.y = 330;
        //myRect.width = 200;
        //myRect.height = 150;
        //NIGUI.Button(myRect, "Random Try-on!");



        // place the selection grid GUI element
        myRect.x = 20;
        myRect.y = 10;
        myRect.width = 200;
        myRect.height = 300;
        categoryInt = NIGUI.SelectionGrid(myRect, categoryInt, categoryStrings, 1);



        //ITEM GROUP
        // placed the clipped area for the button        
        myRect.x = (Screen.width) - 260;
        myRect.y = 0;
        myRect.width = 400;
        myRect.height = Screen.height;
        NIGUI.BeginGroup(myRect);
        // internal background
        //myRect.x = 0;
        //myRect.y = 0;
        //Color c = GUI.backgroundColor;
        //Color almostClear = c;
        //almostClear.a = 0.2f;
        //GUI.backgroundColor = almostClear;
        //GUI.Box(myRect, "");
        //GUI.backgroundColor = c;

        //internal buttons
        Texture[] tempItems = upperGarment;//(Texture[])catArray[0];// = upperGarment;//(Texture[])categories[categoryStrings[categoryInt]];
        switch (categoryInt)
        {
            case 0:
                tempItems = upperGarment;
                break;
            case 1:
                tempItems = pant;
                break;
            case 2:
                tempItems = dress;
                break;
            case 3:
                tempItems = shoes;
                break;
            case 4:
                tempItems = accessory;
                break;
        }
        Debug.Log("category index: " + categoryInt);
        itemInt = NIGUI.SelectionGrid(new Rect(100, 10 - ITEMHEIGHT * itemTopIndex, ITEMWIDTH, tempItems.Length * ITEMHEIGHT), itemInt, tempItems, 1);
        if (NIGUI.Button(new Rect(10, 150, 80, 80), upTexture))
        {
            if (itemTopIndex > 0)
                itemTopIndex--;
        }
        if (NIGUI.Button(new Rect(10, 250, 80, 80), downTexture))
        {

            if (itemTopIndex < tempItems.Length - 1)
                itemTopIndex++;
        }
        //if (NIGUI.Button(new Rect(50, 50, 100, 200), "Garment Sample"))
        //    buttonPressedMessage = "Internal button was pressed";
        NIGUI.EndGroup();




    }

    /// @brief useful members to draw the GUI
    /// 
    /// @{
    private string[] categoryStrings = new string[] { "Upper Garment", "Pant", "Dress", "Shoes", "Accessory" };
    //private enum Category  {UpperGarment, Pant, Dress, Shoes, Accesory};
    private int toolbarInt = 0;
    private int categoryInt = 0;
    private int itemInt = 0;

    private string buttonPressedMessage = "Nothing was pressed yet";
    private string guiFrameCahngedMessage = "GUI last changed at frame 0";
    private Rect myRect = new Rect(0, 0, 100, 100);
    private bool m_toggle1 = false;
    private float hScroll, vScroll;
    private float floatSlider;
    private float intSlider;
    //@}
}
