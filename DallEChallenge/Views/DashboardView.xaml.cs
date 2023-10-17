using DallEChallenge.Models;
using System.Collections.ObjectModel;

namespace DallEChallenge.Views;

public partial class DashboardView : ContentPage
{
	public ObservableCollection<Profile> Profiles { get; set; }
	public ObservableCollection<GeneratedImage> GeneratedImages { get; set; }
	public DashboardView()
	{
		InitializeComponent();
        LoadData();

		BindingContext = this;
	}

    private void LoadData()
    {
		Profiles = new ObservableCollection<Profile>
		{
			new Profile
			{
				Name = "Héctor",
				ProfileImage = "dotnet_bot.png",
				NoPhotos = 12
			},
            new Profile
            {
                Name = "Maddy",
                ProfileImage = "dotnet_bot.png",
                NoPhotos = 5
            },
            new Profile
            {
                Name = "Henry",
                ProfileImage = "dotnet_bot.png",
                NoPhotos = 25
            }
        };

        GeneratedImages = new ObservableCollection<GeneratedImage>
        {
            new GeneratedImage
            {
                ImagePath = "dotnet_bot.png",
                MainKeyword = "Castle",
                Keywords = new List<string>
                {
                    "Epic, hill, mountain, trees, blue sky"
                }
            },
            new GeneratedImage
            {
                ImagePath = "dotnet_bot.png",
                MainKeyword = "Mountains",
                Keywords = new List<string>
                {
                    "Landscape, photorealistic, dawn, mountains, blue sky"
                }
            },
            new GeneratedImage
            {
                ImagePath = "dotnet_bot.png",
                MainKeyword = "Robot",
                Keywords = new List<string>
                {
                    "AI, robotic, human, light, metal"
                }
            },
        };
    }
}