using SwinGameSDK;
using System.Collections.Generic;
using System;

/// <summary>
/// The GameResources class stores all of the Games Media Resources, such as Images, Fonts
/// Sounds, Music.
/// </summary>
public static class GameResources
{
	/// <summary>
    /// LoadFonts loads the fonts used in the game.
    /// </summary>
	private static void LoadFonts()
	{
		NewFont("ArialLarge", "arial.ttf", 80);
		NewFont("Courier", "cour.ttf", 14);
		NewFont("CourierSmall", "cour.ttf", 8);
		NewFont("Menu", "ffaccess.ttf", 9);
		NewFont("GameMenu", "ffaccess.ttf", 10);
		NewFont("Scores", "ffaccess.ttf", 12);
	}
	
    /// <summary>
    /// LoadImages loads the images used in the game.
    /// </summary>
	private static void LoadImages()
	{
		//Back Button
		NewImage("Back", "back-icon.png");
		//Backgrounds
		NewImage("Menu", "main_menu.jpg");
		NewImage("Discovery", "discover.jpg");
		NewImage("Deploy", "deploy.jpg");
		NewImage("EndScore", "enddetailsback.jpg");

		//Deployment
		NewImage("LeftRightButton", "deploy_dir_button_horiz.png");
		NewImage("UpDownButton", "deploy_dir_button_vert.png");
		NewImage("SelectedShip", "deploy_button_hl.png");
		NewImage("PlayButton", "deploy_play_button.png");
		NewImage("RandomButton", "deploy_randomize_button.png");
		
		//Ships
		int i = 0;
		for (i = 1; i <= 5; i++)
		{
			NewImage("ShipLR" + System.Convert.ToString(i), "ship_deploy_horiz_" + System.Convert.ToString(i) +".png");
			NewImage("ShipUD" + System.Convert.ToString(i), "ship_deploy_vert_" + System.Convert.ToString(i) +".png");
		}
		
		//Explosions
		NewImage("Explosion", "explosion.png");
		NewImage("Splash", "splash.png");
		
	}
	
    /// <summary>
    /// LoadSounds loads the sounds used in the game.
    /// </summary>
	private static void LoadSounds()
	{
        NewSound("Error", "error.wav");
		NewSound("Hit", "hit.wav");
		NewSound("Sink", "sink2.wav");
		NewSound("Siren", "siren.wav");
		NewSound("Miss", "watershot.wav");
		NewSound("Winner", "winner.wav");
		NewSound("Lose", "lose.wav");
        NewSound("Easy", "easy.wav");
        NewSound("Medium", "medium.wav");
        NewSound("Hard", "hard.wav");
		NewSound("Insane", "insane.wav");
    }
	
    /// <summary>
    /// LoadMusic loads the music used in the game.
    /// </summary>
	private static void LoadMusic()
	{
		NewMusic("Background", "mainMenuMusic.mp3");
        Audio.SetMusicVolume((float) 0);
        //Audio.SetMusicVolume((float)0.1);
	}
	
	/// <summary>
	/// Gets a Font Loaded in the Resources
	/// </summary>
	/// <param name="font">Name of Font</param>
	/// <returns>The Font Loaded with this Name</returns>
	
	public static Font GameFont(string font)
	{
		return _Fonts[font];
	}
	
	/// <summary>
	/// Gets an Image loaded in the Resources
	/// </summary>
	/// <param name="image">Name of image</param>
	/// <returns>The image loaded with this name</returns>
	
	public static Bitmap GameImage(string image)
	{
		return _Images[image];
	}
	
	/// <summary>
	/// Gets an sound loaded in the Resources
	/// </summary>
	/// <param name="sound">Name of sound</param>
	/// <returns>The sound with this name</returns>
	
	public static SoundEffect GameSound(string sound)
	{
		return _Sounds[sound];
	}
	
	/// <summary>
	/// GameMusic gets the music loaded in the Resources
	/// </summary>
	/// <param name="music">Name of music</param>
	/// <returns>The music with this name</returns>
	
	public static Music GameMusic(string music)
	{
		return _Music[music];
	}
	
	private static Dictionary<string, Bitmap> _Images = new Dictionary<string, Bitmap>();
	private static Dictionary<string, Font> _Fonts = new Dictionary<string, Font>();
	private static Dictionary<string, SoundEffect> _Sounds = new Dictionary<string, SoundEffect>();
	private static Dictionary<string, Music> _Music = new Dictionary<string, Music>();
	
	private static Bitmap _Background;
	private static Bitmap _Animation;
	private static Bitmap _LoaderFull;
	private static Bitmap _LoaderEmpty;
	private static Font _LoadingFont;
	private static SoundEffect _StartSound;
	
    /// <summary>
    /// LoadResources loads the all the resources used in the game.
    /// </summary>
	public static void LoadResources()
	{
		int width = 0;
		int height = 0;
		
		width = System.Convert.ToInt32(SwinGame.ScreenWidth());
		height = System.Convert.ToInt32(SwinGame.ScreenHeight());
		
		SwinGame.ChangeScreenSize(800, 600);
		
		ShowLoadingScreen();
		
		ShowMessage("Loading fonts...", 0);
		LoadFonts();
		SwinGame.Delay(100);
		
		ShowMessage("Loading images...", 1);
		LoadImages();
		SwinGame.Delay(100);
		
		ShowMessage("Loading sounds...", 2);
		LoadSounds();
		SwinGame.Delay(100);
		
		ShowMessage("Loading music...", 3);
		LoadMusic();
		SwinGame.Delay(100);
		
		SwinGame.Delay(100);
		ShowMessage("Game loaded...", 5);
		SwinGame.Delay(100);
		EndLoadingScreen(width, height);
	}
	
    /// <summary>
    /// ShowLoadingScreen displays the loading screen.
    /// </summary>
	private static void ShowLoadingScreen()
	{
		_Background = SwinGame.LoadBitmap(SwinGame.PathToResource("SplashBack.png", ResourceKind.BitmapResource));
		SwinGame.DrawBitmap(_Background, 0, 0);
		SwinGame.RefreshScreen();
		SwinGame.ProcessEvents();
		
		_Animation = SwinGame.LoadBitmap(SwinGame.PathToResource("SwinGameAni.jpg", ResourceKind.BitmapResource));
		_LoadingFont = SwinGame.LoadFont(SwinGame.PathToResource("arial.ttf", ResourceKind.FontResource), 12);
		_StartSound = Audio.LoadSoundEffect(SwinGame.PathToResource("SwinGameStart.ogg", ResourceKind.SoundResource));
		
		_LoaderFull = SwinGame.LoadBitmap(SwinGame.PathToResource("loader_full.png", ResourceKind.BitmapResource));
		_LoaderEmpty = SwinGame.LoadBitmap(SwinGame.PathToResource("loader_empty.png", ResourceKind.BitmapResource));
		
		PlaySwinGameIntro();
	}
	
    /// <summary>
    /// PlaySwinGameIntro plays an intro animation of SwinGame.
    /// </summary>
	private static void PlaySwinGameIntro()
	{
		const int ANI_X = 143;
		const int ANI_Y = 134;
		const int ANI_W = 546;
		const int ANI_H = 327;
		const int ANI_V_CELL_COUNT = 6;
		const int ANI_CELL_COUNT = 11;
		
		Audio.PlaySoundEffect(_StartSound);
		SwinGame.Delay(200);
		
		int i = 0;
		for (i = 0; i <= ANI_CELL_COUNT - 1; i++)
		{
			SwinGame.DrawBitmap(_Background, 0, 0);
			SwinGame.DrawBitmapPart(_Animation, (i / ANI_V_CELL_COUNT) * ANI_W, (i % ANI_V_CELL_COUNT) * ANI_H, ANI_W, ANI_H, ANI_X, ANI_Y);
			SwinGame.Delay(20);
			SwinGame.RefreshScreen();
			SwinGame.ProcessEvents();
		}
		
		SwinGame.Delay(1500);
		
	}
	
    /// <summary>
    /// ShowMessage displays messages in the game.
    /// </summary>
    /// <param name="message">The message to be displayed</param>
    /// <param name="number">The width of the message.</param>
	private static void ShowMessage(string message, int number)
	{
		const int TX = 310;
		const int TY = 493;
		const int TW = 200;
		const int TH = 25;
		const int STEPS = 5;
		const int BG_X = 279;
		const int BG_Y = 453;
		
		int fullW = 0;
		
		fullW = System.Convert.ToInt32(260 * number / STEPS);
		SwinGame.DrawBitmap(_LoaderEmpty, BG_X, BG_Y);
		SwinGame.DrawBitmapPart(_LoaderFull, 0, 0, fullW, 66, BG_X, BG_Y);
		
		SwinGame.DrawTextLines(message, Color.White, Color.Transparent, _LoadingFont, FontAlignment.AlignCenter, TX, TY, TW, TH);
		
		SwinGame.RefreshScreen();
		SwinGame.ProcessEvents();
	}
	
    /// <summary>
    /// EndLoadingScreen displays the end after the loading screen.
    /// </summary>
    /// <param name="width">Width of the window of the end of loading screen</param>
    /// <param name="height">The height of the window of the end of the loading screen.</param>
	private static void EndLoadingScreen(int width, int height)
	{
		SwinGame.ProcessEvents();
		SwinGame.Delay(500);
		SwinGame.ClearScreen();
		SwinGame.RefreshScreen();
		SwinGame.FreeFont(_LoadingFont);
		SwinGame.FreeBitmap(_Background);
		SwinGame.FreeBitmap(_Animation);
		SwinGame.FreeBitmap(_LoaderEmpty);
		SwinGame.FreeBitmap(_LoaderFull);
		Audio.FreeSoundEffect(_StartSound);
		SwinGame.ChangeScreenSize(width, height);
	}
	
    /// <summary>
    /// NewFont insert in fonts to be used in the game.
    /// </summary>
    /// <param name="fontName">Name of font</param>
    /// <param name="filename">Location of font file</param>
    /// <param name="size">File size of font file</param>
	private static void NewFont(string fontName, string filename, int size)
	{
		_Fonts.Add(fontName, SwinGame.LoadFont(SwinGame.PathToResource(filename, ResourceKind.FontResource), size));
	}
	
    /// <summary>
    /// NewImage insert in images to be used in the game.
    /// </summary>
    /// <param name="imageName">Name of image.</param>
    /// <param name="filename">Name of image file.</param>
	private static void NewImage(string imageName, string filename)
	{
		_Images.Add(imageName, SwinGame.LoadBitmap(SwinGame.PathToResource(filename, ResourceKind.BitmapResource)));
	}
	
    /// <summary>
    /// NewTransparentColorImage insert in transparent images used in the game.
    /// </summary>
    /// <param name="imageName">Name of image</param>
    /// <param name="fileName">File name of image file</param>
    /// <param name="transColor">The color used to create transparent effect over the image</param>
	private static void NewTransparentColorImage(string imageName, string fileName, Color transColor)
	{
		_Images.Add(imageName, SwinGame.LoadBitmap(SwinGame.PathToResource(fileName, ResourceKind.BitmapResource), true, transColor));
	}
	
    /// <summary>
    /// NewTransparentColourImage initializes a new NewTransparentColorImage object.
    /// </summary>
    /// <param name="imageName">Name of image</param>
    /// <param name="fileName">File name of image</param>
    /// <param name="transColor">Color to give transparent effect over image</param>
	private static void NewTransparentColourImage(string imageName, string fileName, Color transColor)
	{
		NewTransparentColorImage(imageName, fileName, transColor);
	}
	
    /// <summary>
    /// NewSound insert in sounds to be used in the game.
    /// </summary>
    /// <param name="soundName">Name of sound</param>
    /// <param name="filename">File name of sound file</param>
	private static void NewSound(string soundName, string filename)
	{
		_Sounds.Add(soundName, Audio.LoadSoundEffect(SwinGame.PathToResource(filename, ResourceKind.SoundResource)));
	}
	
    /// <summary>
    /// NewMusic insert in music to be used in the game.
    /// </summary>
    /// <param name="musicName">Name of music</param>
    /// <param name="filename">FIle name of music file</param>
	private static void NewMusic(string musicName, string filename)
	{
		_Music.Add(musicName, Audio.LoadMusic(SwinGame.PathToResource(filename, ResourceKind.SoundResource)));
	}
	
    /// <summary>
    /// FreeFonts unloads font files from memory.
    /// </summary>
	private static void FreeFonts()
	{
		Font obj = default(Font);
		foreach (Font tempLoopVar_obj in _Fonts.Values)
		{
			obj = tempLoopVar_obj;
			SwinGame.FreeFont(obj);
		}
	}
	
    /// <summary>
    /// FreeImages unloads image files from memory.
    /// </summary>
	private static void FreeImages()
	{
		Bitmap obj = default(Bitmap);
		foreach (Bitmap tempLoopVar_obj in _Images.Values)
		{
			obj = tempLoopVar_obj;
			SwinGame.FreeBitmap(obj);
		}
	}
	
    /// <summary>
    /// FreeSounds unload sound files from memory.
    /// </summary>
	private static void FreeSounds()
	{
		SoundEffect obj = default(SoundEffect);
		foreach (SoundEffect tempLoopVar_obj in _Sounds.Values)
		{
			obj = tempLoopVar_obj;
			Audio.FreeSoundEffect(obj);
		}
	}
	
    /// <summary>
    /// FreeMusic unloads music files from memory.
    /// </summary>
	private static void FreeMusic()
	{
		Music obj = default(Music);
		foreach (Music tempLoopVar_obj in _Music.Values)
		{
			obj = tempLoopVar_obj;
			Audio.FreeMusic(obj);
		}
	}
	
    /// <summary>
    /// FreeResources unloads game resources from memory.
    /// </summary>
	public static void FreeResources()
	{
		FreeFonts();
		FreeImages();
		FreeMusic();
		FreeSounds();
		SwinGame.ProcessEvents();
	}
}
