using SwinGameSDK;

/// <summary>
/// GameLogic contains the main game loop
/// </summary>
static class GameLogic
{
	public static void Main()
	{
		//Opens a new Graphics Window
		SwinGame.OpenGraphicsWindow("Battle Ships", 800, 600);

		//Load Resources
		GameResources.LoadResources();

		//Play Background Music
		SwinGame.PlayMusic(GameResources.GameMusic("Background"));

		GameController.PushStatesInStack();

		//Game Loop
		do {
			GameController.HandleUserInput();
			GameController.DrawScreen();
		} while (!(SwinGame.WindowCloseRequested() == true | GameController.CurrentState == GameState.Quitting));

		//Stop Background Music
		SwinGame.StopMusic();

		//Free Resources and Close Audio, to end the program.
		GameResources.FreeResources();
	}
}