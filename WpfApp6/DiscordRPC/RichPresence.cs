using static NetDiscordRpc.DiscordRPC;
using Frost;
using System;
using WpfApp6;
using System.Windows;

namespace WpfApp6
{
    public static class DiscordRichPresence
    {
        private static DiscordRpcClient client;

        public static void Initialize()
        {
            try
            {
                client = new DiscordRpcClient("1225746906844631072"); // Replace 'your_client_id' with your actual Discord application's client ID
                client.Initialize();

                Console.WriteLine("Discord Rich Presence initialized successfully.");

                // Define launcher details
                RichPresenceDetails presenceDetails = new RichPresenceDetails()
                {
                    Details = "Playing Frost",
                    State = "Do Not Disturb",
                    Assets = new Assets()
                    {
                        LargeImageKey = "https://cdn.discordapp.com/attachments/1185822246703484948/1227632579465842768/360_F_369799193_D7bhKPUKNN3FFvrmp3PqtS6pi1NCGQmJ_1.jpg", // Replace 'launcher_icon' with the name of your launcher's image asset
                        LargeImageText = "Frost Launcher" // Replace 'My Launcher' with your launcher's name
                    }
                };

                // Update presence
                client.SetPresence(presenceDetails);

                Console.WriteLine("Discord Rich Presence updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error initializing Discord Rich Presence: {ex.Message}");
            }
        }

        public static void Shutdown()
        {
            try
            {
                client.Dispose();
                Console.WriteLine("Discord Rich Presence shut down successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error shutting down Discord Rich Presence: {ex.Message}");
            }
        }
    }
}