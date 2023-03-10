public class sharedVariable{
    // Start is called before the first frame update
    public static int healthPackNum=0;
    GameManager _gameManager; 
    public static void updateHealthPackNum(int num){
        healthPackNum+=num;
    }

    public static int getHealthPackNum(){
        return healthPackNum;
    }
    // Update is called once per frame
    
}
