// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GamePage.cs" company="ArcTouch, Inc.">
//   All rights reserved.
//
//   This file, its contents, concepts, methods, behavior, and operation
//   (collectively the "Software") are protected by trade secret, patent,
//   and copyright laws. The use of the Software is governed by a license
//   agreement. Disclosure of the Software to third parties, in any form,
//   in whole or in part, is expressly prohibited except as authorized by
//   the license agreement.
// </copyright>
// <summary>
//   Defines the GamePage type.
// </summary>
//  --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using CocosSharp;

namespace FruityFalls
{
	public class GamePage : ContentPage
	{
		CocosSharpView gameView;
		
		public GamePage ()
		{
			gameView = new CocosSharpView () {
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				// Set the game world dimensions
				DesignResolution = new Size (1024, 768),
				// Set the method to call once the view has been initialised
				ViewCreated = LoadGame
			};

			Content = gameView;
		}
		
		protected override void OnDisappearing ()
		{
			if (gameView != null) {
				gameView.Paused = true;
			}

			base.OnDisappearing ();
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();

			if (gameView != null)
				gameView.Paused = false;
		}

		void LoadGame (object sender, EventArgs e)
		{
			var nativeGameView = sender as CCGameView;

			if (nativeGameView != null) {
				var contentSearchPaths = new List<string> () { "Fonts", "Sounds" };
				CCSizeI viewSize = nativeGameView.ViewSize;
				CCSizeI designResolution = nativeGameView.DesignResolution;

				// Determine whether to use the high or low def versions of our images
				// Make sure the default texel to content size ratio is set correctly
				// Of course you're free to have a finer set of image resolutions e.g (ld, hd, super-hd)
				if (designResolution.Width < viewSize.Width) {
					contentSearchPaths.Add ("Images/Hd");
					CCSprite.DefaultTexelToContentSizeRatio = 2.0f;
				} else {
					contentSearchPaths.Add ("Images/Ld");
					CCSprite.DefaultTexelToContentSizeRatio = 1.0f;
				}

				nativeGameView.ContentManager.SearchPaths = contentSearchPaths;

				CCScene gameScene = new CCScene (nativeGameView);
				gameScene.AddLayer (new GameLayer ());
				nativeGameView.RunWithScene (gameScene);
			}
		}
	}
}
