using UnityEngine;
using System.Collections;

public class boardstruct : MonoBehaviour {
    link[,] gameboard = new link[36,36];
	// Use this for initialization
	void Start () {
        gameboard[0,1] = new link(0,0,1);
        gameboard[0,2] = new link(0,3);
        gameboard[1,2] = new link(0,4);
        gameboard[1,3] = new link(0,0,1);
        gameboard[1,6] = new link(8,6);
        gameboard[2,6] = new link(0,4);
        gameboard[2,7] = new link(7,6);
        gameboard[3,4] = new link(3,5,5);
        gameboard[3,5] = new link(2,6);
        gameboard[4,5] = new link(4,7,5);
        gameboard[4,32] = new link(8,5,3);
        gameboard[5,6] = new link(5,3);
        gameboard[5,9] = new link(6,8,3);
        gameboard[5,10] = new link(4,3);
        gameboard[6,7] = new link(2,4);
        gameboard[6,8] = new link(4,6);
        gameboard[6,11] = new link(6,5);
        gameboard[6,9] = new link(3,4);
        gameboard[7,8] = new link(1,4);
        gameboard[7,12] = new link(0,6);
        gameboard[8,12] = new link(0,3);
        gameboard[8,11] = new link(0,0,2);
        gameboard[8,18] = new link(6,3);
        gameboard[8,15] = new link(5,6);
        gameboard[9,11] = new link(5,4);
        gameboard[9,19] = new link(1,4,4);
        gameboard[9,33] = new link(6,4);
        gameboard[9,34] = new link(0,2);
        gameboard[9,35] = new link(7,5);
        gameboard[10,32] = new link(0,2);
        gameboard[11,18] = new link(2,4);
        gameboard[11,19] = new link(0,0,1);
        gameboard[12,15] = new link(0,2);
        gameboard[12,13] = new link(1,5);
        gameboard[13,14] = new link(0,0,2);
        gameboard[13,16] = new link(2,3);
        gameboard[13,15] = new link(0,3);
        gameboard[14,16] = new link(8,6,2);
        gameboard[15,17] = new link(0,2);
        gameboard[15,18] = new link(7,4);
        gameboard[16,17] = new link(7,3,2);
        gameboard[16,23] = new link(1,4,2);
        gameboard[17,18] = new link(4,1,3);
        gameboard[17,20] = new link(3,5);
        gameboard[17,21] = new link(8,4);
        gameboard[17,22] = new link(0,2);
        gameboard[17,23] = new link(0,2);
        gameboard[18,20] = new link(3,7,2);
        gameboard[19,20] = new link(2,5,2);
        gameboard[19,33] = new link(0,0,2);
        gameboard[20,21] = new link(0,2);
        gameboard[20,27] = new link(0,2);
        gameboard[21,22] = new link(1,3);
        gameboard[21,25] = new link(0,1);
        gameboard[21,27] = new link(7,3);
        gameboard[22,23] = new link(0,0,2);
        gameboard[22,24] = new link(0,2);
        gameboard[22,25] = new link(0,0,2);
        gameboard[24,25] = new link(0,2);
        gameboard[24,26] = new link(5,4);
        gameboard[25,26] = new link(2,5);
        gameboard[25,28] = new link(8,4,4);
        gameboard[26,28] = new link(6,6);
        gameboard[27,28] = new link(3,3);
        gameboard[27,29] = new link(0,2);
        gameboard[27,33] = new link(0,2);
        gameboard[28,30] = new link(0,2);
        gameboard[29,30] = new link(0,0,1);
        gameboard[29,33] = new link(0,0,2);
        gameboard[29,31] = new link(6,4);
        gameboard[30,31] = new link(3,6);
        gameboard[31,34] = new link(0,2);
        gameboard[31,35] = new link(0,3);
        gameboard[31,32] = new link(1,6);
        gameboard[31,33] = new link(8,5);
        gameboard[32,35] = new link(0,3);
        gameboard[33,34] = new link(2,3);
        gameboard[34,35] = new link(0,3);
    }
	
	// Update is called once per frame
	void Update () {
	
	}


}

class link  {
    int connection1;
    int connection2;
    int color1;
    int color2;
    int length;

    public link() { //default constructor
        this.connection1 = -1;
        this.connection2 = -1;
        this.color1 = -1;  //0 = gray; 1 = black; 2 = blue; 3 = green; 4 = orange; 5 = pink; 6 = red; 7 = white; 8 = yellow (alphabetical, except for grey)
        this.color2 = -1;
        this.length = -1;
    }
    //--------------------------------------------------------------------------------------------------------------------------
    public link(int color1, int length) { //constructor for single link

        this.connection1 = 0;
        this.connection2 = -1;
        this.color1 = color1; //0 = gray; 1 = black; 2 = blue; 3 = green; 4 = orange; 5 = pink; 6 = red; 7 = white; 8 = yellow (alphabetical, except for grey)
        this.color2 = -1;
        this.length = length;

    }
    //-------------------------------------------------------------------------------------------------------------------------
    public link(int color1, int color2, int length) { //constructor for double link
        this.connection1 = 0;
        this.connection2 = 0;
        this.color1 = color1; //0 = gray; 1 = black; 2 = blue; 3 = green; 4 = orange; 5 = pink; 6 = red; 7 = white; 8 = yellow (alphabetical, except for grey)
        this.color2 = color2;
        this.length = length;
    }
    //--------------------------------------------------------------------------------------------------------------------------
    public void set_link(int color, int player_num) {
        if (this.connection1 == 0 && this.connection2 != player_num)
        {
            if (this.color1 == color || this.color1 == 0)
            {
                connection1 = player_num;
                return;
            }

        }
        else if (this.connection2 == 0 && this.connection1 != player_num)
        {
            if (this.color2 == color || this.color1 == 0)
            {
                connection2 = player_num;
                return;
            }

        }    
    }
    //----------------------------------------------------------------------------------------------------------------------------
    public bool test_link(int color, int player_num)
    {
        if (this.connection1 == 0 && this.connection2 != player_num)
        {
            if (this.color1 == color || this.color1 == 0)
            {
                return true;
            }

            else return false;
        }
        else if (this.connection2 == 0 && this.connection1 != player_num)
        {
            if (this.color2 == color || this.color1 == 0)
            {
                return true;
            }

            else return false;
        }
        else return false;
    }
    public int get_length() {
        return this.length;
    }
    public int get_color1() {
        return this.color1;
    }
    public int get_color2() {
        return this.color2;
    }
}
