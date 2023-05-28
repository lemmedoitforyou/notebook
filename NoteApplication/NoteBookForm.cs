using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoteApplication
{
    public partial class NoteBookForm : Form
    {
        List<FileInfo> files = new List<FileInfo>();
        private const string folderPath = "..\\..\\NoteBookFiles";
        public NoteBookForm()
        {
            InitializeComponent();

            string[] filePaths = Directory.GetFiles(folderPath);

            foreach (string filePath in filePaths)
            {
                files.Add(new FileInfo(filePath));
            }

            selectedFileComboBox.DataSource = files;
            selectedFileComboBox.DisplayMember = "Name";
            selectedFileComboBox.SelectedIndex = -1;
            fileNameTextBox.Text = "";
            fileContentsRichTextBox.Text = "";
        }

        private void newNoteButton_Click(object sender, EventArgs e)
        {
            string baseFileName = "Note";
            int fileNumber = 1;
            string fileName = $"{baseFileName}{fileNumber}.txt";
            string filePath = Path.Combine(folderPath, fileName);

            while (System.IO.File.Exists(filePath))
            {
                fileNumber++;
                fileName = $"{baseFileName}{fileNumber}.txt";
                filePath = Path.Combine(folderPath, fileName);
            }

            System.IO.File.WriteAllText(filePath, "");

            FileInfo newNote = new FileInfo(filePath);

            files.Add(newNote);

            selectedFileComboBox.DataSource = null;
            selectedFileComboBox.DataSource = files;
            selectedFileComboBox.DisplayMember = "Name";

            selectedFileComboBox.SelectedItem = newNote;

            MessageBox.Show("File created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void selectedFileComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectedFileComboBox.SelectedItem is FileInfo selectedFile)
            {
                fileNameTextBox.Text = selectedFile.Name;
                fileContentsRichTextBox.Text = selectedFile.Content;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string fileName = fileNameTextBox.Text.Trim();
            string contents = fileContentsRichTextBox.Text;
            if(fileName == "secret.game")
            {
                GameForm gameForm = new GameForm();
                gameForm.ShowDialog();
            }
            if (selectedFileComboBox.SelectedItem is FileInfo selectedFile)
            {
                if (selectedFile.SaveUpdates(fileName, contents))
                {
                    MessageBox.Show("Changes were saved successfully.", "Save Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Invalid file format. The file name must end with '.txt'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (selectedFileComboBox.SelectedItem is FileInfo selectedFile)
            {
                DialogResult result = MessageBox.Show($"Are you sure you want to delete the file '{selectedFile.Name}'?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        System.IO.File.Delete(selectedFile.FilePath);

                        files.Remove(selectedFile);
                        selectedFileComboBox.DataSource = null; // Set the DataSource to null before updating
                        selectedFileComboBox.DataSource = files; // Update the DataSource
                        selectedFileComboBox.DisplayMember = "Name";

                        fileNameTextBox.Clear();
                        fileContentsRichTextBox.Clear();

                        MessageBox.Show("File deleted successfully.", "Deletion Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        selectedFileComboBox.SelectedIndex = -1;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while deleting the file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
