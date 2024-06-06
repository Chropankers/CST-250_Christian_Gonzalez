using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FileIOApp
{
    public partial class MainForm : Form
    {
        // List to store Person objects
        private List<Person> people = new List<Person>();

        // File paths for data storage
        private string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data.txt");
        private string outPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "peopleOut.txt");

        // Constructor
        public MainForm()
        {
            InitializeComponent();
            InitializeFiles(); // Ensure files exist
            LoadPeopleFromFile(); // Load existing data from file
        }

        // Ensure that the necessary files exist and create them with default content if they don't
        private void InitializeFiles()
        {
            if (!File.Exists(filePath))
            {
                // Create the file and write default content
                using (StreamWriter sw = File.CreateText(filePath))
                {
                    sw.WriteLine("John,Doe,http://example.com");
                    sw.WriteLine("Jane,Doe,http://example.org");
                }
            }

            if (!File.Exists(outPath))
            {
                // Create the file and write default content
                using (StreamWriter sw = File.CreateText(outPath))
                {
                    sw.WriteLine("FirstName,LastName,URL");
                }
            }

            // Debugging: Ensure files are created and can be accessed
            MessageBox.Show($"Files initialized at:\nData File: {filePath}\nOutput File: {outPath}");
        }

        // Load people from the data file into the list and list box
        private void LoadPeopleFromFile()
        {
            people.Clear(); // Clear existing data
            listBoxPeople.Items.Clear(); // Clear list box

            if (File.Exists(filePath))
            {
                try
                {
                    // Read all lines from the file
                    List<string> lines = File.ReadAllLines(filePath).ToList();
                    foreach (string line in lines)
                    {
                        string[] entries = line.Split(',');

                        // Validate the line format
                        if (entries.Length != 3)
                        {
                            MessageBox.Show($"Error: Line '{line}' is not correctly formatted.");
                            continue;
                        }

                        // Create a new Person object and add it to the list
                        Person p = new Person
                        {
                            firstName = entries[0],
                            lastName = entries[1],
                            Url = entries[2]
                        };

                        people.Add(p); // Add to the list
                        listBoxPeople.Items.Add($"{p.firstName} {p.lastName} - {p.Url}"); // Add to the list box
                    }
                }
                catch (Exception ex)
                {
                    // Handle any errors that occur during file reading
                    MessageBox.Show($"An error occurred while loading the file: {ex.Message}");
                }
            }
            else
            {
                // Handle case where the file does not exist
                MessageBox.Show("File not found.");
            }
        }

        // Event handler for the Load button click event
        private void buttonLoad_Click(object sender, EventArgs e)
        {
            LoadPeopleFromFile(); // Reload data from file
        }

        // Event handler for the Add button click event
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            // Read input from text boxes
            string firstName = textBoxFirstName.Text;
            string lastName = textBoxLastName.Text;
            string url = textBoxUrl.Text;

            // Validate input
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(url))
            {
                MessageBox.Show("All fields must be filled out.");
                return;
            }

            // Create a new Person object
            Person p = new Person
            {
                firstName = firstName,
                lastName = lastName,
                Url = url
            };

            // Add the Person to the list and list box
            people.Add(p);
            listBoxPeople.Items.Add($"{p.firstName} {p.lastName} - {p.Url}");

            // Clear the input text boxes
            textBoxFirstName.Clear();
            textBoxLastName.Clear();
            textBoxUrl.Clear();
        }

        // Event handler for the Save button click event
        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Prepare data to be written to the file
                List<string> outputLines = new List<string>();
                foreach (Person p in people)
                {
                    outputLines.Add($"{p.firstName},{p.lastName},{p.Url}");
                }

                // Write data to the file
                File.WriteAllLines(filePath, outputLines);

                // Debugging: Verify the file content
                MessageBox.Show("Data saved successfully.");
                string savedData = File.ReadAllText(filePath);
                MessageBox.Show($"Saved data in {filePath}:\n{savedData}");

                // Reload the updated data into the GUI
                LoadPeopleFromFile();
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during file writing
                MessageBox.Show($"An error occurred while saving the file: {ex.Message}");
            }
        }
    }

    // Person class representing a person with first name, last name, and URL
    public class Person
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string Url { get; set; }
    }
}
