using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class TicTacToe : MonoBehaviour {
    public int times;
    public int count;
    private int[,] grid = new int[3, 3];
	// Use this for initialization
	void Start () {
        restart();
	}
    void restart()
    {
        times = 1;
        for (int i = 0; i < 3; ++i)
        {
            for (int j = 0; j < 3; ++j)
            {
                grid[i, j] = 0;
            }
        }
        count = 0;
    }
    private int winCheck()
    {
        for(int i = 0; i < 3; ++i)
        {
            if (grid[i, 0] != 0 && grid[i,0]==grid[i, 1] && grid[i, 1] == grid[i, 2])
            {
                return grid[i, 0];
            }
        }
        for (int i = 0; i < 3; ++i)
        {
            if (grid[0, i] != 0 && grid[0, i] == grid[1, i] && grid[1, i] == grid[2, i])
            {
                return grid[0, i];
            }
        }
        if(grid[1,1]!=0 && grid[0,0]==grid[1,1] && grid[1,1]==grid[2,2] || grid[0,2]==grid[1,1]&&
            grid[1,1]==grid[2,0]
            )
        {
            return grid[1, 1];
        }
        if (count == 9) return 3;
        return 0;
    }
    private void OnGUI()
    {
        if(GUI.Button(new Rect(30, 200, 100, 50),"restart"))
        {
            restart();
        }
        int result = winCheck();//
 
        GUIStyle temp = new GUIStyle
        {
            fontSize = 30
        };
        temp.normal.textColor = Color.red;
        temp.fontStyle = FontStyle.BoldAndItalic;
 
        switch (result)
        {
            case 1:
                GUI.Label(new Rect(35, 165, 100, 50), "O WIN", style: temp);
                break;
            case 2:
                GUI.Label(new Rect(35, 165, 100, 50), "X WIN", style: temp);
                break;
            case 3:
                GUI.Label(new Rect(35, 165, 100, 50), "DEUCE", style: temp);
                break;
        }
 
        for (int i = 0; i < 3; ++i)
        {
            for(int j = 0; j < 3; ++j)
            {
                if (grid[i, j] == 1)
                {
                    GUI.Button(new Rect(i * 50, j * 50, 50, 50), "O");
                }
                if (grid[i, j] == 2)
                {
                    GUI.Button(new Rect(i * 50, j * 50, 50, 50), "X");
                }
                if(GUI.Button(new Rect(i * 50, j * 50, 50, 50), ""))
                {
                    if (result == 0)
                    {
                        if (times == 1) grid[i, j] = 1;
                        else grid[i, j] = 2;
                        count++;
                        times = -times;
                    }
                }
            }
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}