using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NetDiscordRpc.DiscordRPC;

namespace Frost
{
    public class DiscordManager
    {
        private DiscordRpcClient? client;

        public DiscordManager()
        {
            client = null; // Initialize to null to satisfy nullable reference types
            try
            {

                client = new DiscordRpcClient("1232526546796023829"); // Your Discord application ID
                client.OnReady += (sender, e) =>
                {
                    Console.WriteLine("Discord RPC client is ready.");
                };
                client.OnError += (sender, e) =>
                {
                    if (e is MessageEventArgs messageEventArgs)
                    {
                        Console.WriteLine($"Discord RPC error: {messageEventArgs.Message}");
                    }
                    else
                    {
                        Console.WriteLine($"Unexpected Discord RPC error occurred.");
                    }
                };

                client.Initialize();
                Console.WriteLine("Discord RPC client initialized successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to initialize Discord RPC client: {ex.Message}");
            }
        }

        public void SetActivity()
        {
            try
            {
                var activity = new RichPresence()
                {
                    Details = "In Launcher", // Details about what the user is doing
                    State = "Playing Frost", // State of the activity
                    Timestamps = new Timestamps(DateTime.UtcNow), // Use current UTC time
                    Assets = new Assets()
                    {
                        LargeImageKey = "https://cdn.discordapp.com/attachments/1185822246703484948/1227632579465842768/360_F_369799193_D7bhKPUKNN3FFvrmp3PqtS6pi1NCGQmJ_1.jpg?ex=66291cef&is=6616a7ef&hm=f921aab42eb0d4d36811e306ea0dfbb213e64dfc7ca8575a71e50a3c8a7bc9d6&",
                        LargeImageText = "Frost", // Text shown when hovering over the large image
                        SmallImageKey = "https://cdn.discordapp.com/attachments/1185822246703484948/1227632579465842768/360_F_369799193_D7bhKPUKNN3FFvrmp3PqtS6pi1NCGQmJ_1.jpg?ex=66291cef&is=6616a7ef&hm=f921aab42eb0d4d36811e306ea0dfbb213e64dfc7ca8575a71e50a3c8a7bc9d6&",
                        SmallImageText = "Launcher" // Text shown when hovering over the small image
                    }
                };

#pragma warning disable CS8602 // Dereference of a possibly null reference.
                client.SetPresence(activity);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                Console.WriteLine("Discord RPC presence set successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to set Discord RPC presence: {ex.Message}");
            }
        }

        public void ClearActivity()
        {
            try
            {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                client.ClearPresence();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                Console.WriteLine("Discord RPC presence cleared successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to clear Discord RPC presence: {ex.Message}");
            }
        }
    }
}
