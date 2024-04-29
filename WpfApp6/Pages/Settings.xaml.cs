using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WindowsAPICodePack.Dialogs;
using WpfApp6.Services;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace WpfApp6.Pages
{
    public partial class Settings : UserControl
    {
        public Settings()
        {
            InitializeComponent();

            // Subscribe to the Loaded event
            Loaded += Settings_Loaded;
        }

        private void Settings_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            // Implement actions to be performed when the control is loaded
        }

        private void LoadUserDetails()
        {
            try
            {
                // Load user details from configuration
                EmailBox.Text = UpdateINI.ReadFromConfig("Auth", "Email");
                PasswordBox.Password = UpdateINI.ReadFromConfig("Auth", "Password");
                PathBox.Text = UpdateINI.ReadFromConfig("Auth", "Path");
            }
            catch (Exception ex)
            {
                // Log any errors encountered during loading
                MessageBox.Show($"Error loading user details: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SaveUserDetails()
        {
            try
            {
                // Save user details to configuration
                UpdateINI.WriteToConfig("Auth", "Email", EmailBox.Text);
                UpdateINI.WriteToConfig("Auth", "Password", PasswordBox.Password);
                UpdateINI.WriteToConfig("Auth", "Path", PathBox.Text);
            }
            catch (Exception ex)
            {
                // Log any errors encountered during saving
                MessageBox.Show($"Error saving user details: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Prompt user to select a Fortnite build folder
                CommonOpenFileDialog dialog = new CommonOpenFileDialog();
                dialog.IsFolderPicker = true;
                dialog.Title = "Select A Fortnite Build";

                if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    string selectedPath = dialog.FileName;
                    string exePath = System.IO.Path.Combine(selectedPath, "FortniteGame\\Binaries\\Win64\\FortniteClient-Win64-Shipping.exe");

                    if (System.IO.File.Exists(exePath))
                    {
                        PathBox.Text = selectedPath;
                    }
                    else
                    {
                        MessageBox.Show("Please make sure that the folder contains FortniteGame and Engine.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                // Log any errors encountered during folder selection
                MessageBox.Show($"Error selecting folder: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Save user details when the "Save" button is clicked
            SaveUserDetails();
        }

        private void TextBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            // You can put any logic related to text input validation here
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // You can put any logic related to text changes in the TextBox here
        }
    }
}
