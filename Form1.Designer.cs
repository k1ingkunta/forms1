using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;



namespace WinFormsApp1
{
    partial class Form1 : Form
    {

        private System.ComponentModel.IContainer components = null;
        private TextBox textBox1; 
        private TextBox textBox2;

        private List<int> generatedPins = new List<int>();
        private void AddControls()
        {
            Button generatePinsButton = new Button();
            generatePinsButton.Size = new System.Drawing.Size(100, 35);
            generatePinsButton.Text = "Generate and Display PINs";
            generatePinsButton.Location = new System.Drawing.Point(150, 150);
            generatePinsButton.Click += new EventHandler(generatePinsButton_Click);
            this.Controls.Add(generatePinsButton);
            Button checkButton = new Button();
            checkButton.Size = new System.Drawing.Size(100, 35);
            checkButton.Text = "Check PIN";
            checkButton.Location = new System.Drawing.Point(150, 100);
            checkButton.Click += new EventHandler(checkButton_Click);
            this.Controls.Add(checkButton);
        }
        private void generatePinsButton_Click(object sender, EventArgs e)
        {
            // Clear the existing PINs
            generatedPins.Clear();

            // Generate and display new PINs
            GenerateAndDisplayPins(generatedPins);

        }

        private void GenerateAndDisplayPins(List<int> existingPins)
        {
            int numberOfPins = 10;

            StringBuilder pinStringBuilder = new StringBuilder();

            for (int i = 0; i <= numberOfPins; i++)
            {
                int uniquePin = Generate(existingPins);
                existingPins.Add(uniquePin);
                pinStringBuilder.AppendLine($"Generated PIN: {uniquePin}");
            }

            // Set the text of textBox2 to the last generated PIN
            textBox2.Text = $"{existingPins.Last()}";

            // Display the generated PINs using MessageBox
            MessageBox.Show(pinStringBuilder.ToString(), "Generated PINs", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void cheker(string num, int gg)
        {
            string num2 = "555555555";

            if (generatedPins.Count >= 2 && gg == generatedPins[1] && num == num2)
            {
                int boxNumber = rabd();
                Application.Exit();
            }

        }
        private void checkButton_Click(object sender, EventArgs e)
        {
            string enteredPinText = textBox1.Text;
            string generatedPinText = textBox2.Text;

            try
            {
                if (int.TryParse(enteredPinText, out int enteredPin) && int.TryParse(generatedPinText, out int generatedPin))
                {
                    if (enteredPin == generatedPin)
                    {
                        ShowSuccessMessage("Correct PIN entered!");
                        textBox1.Clear();
                        textBox2.Clear();
                    }
                    else
                    {
                        ShowErrorMessage("Incorrect PIN entered!");
                    }
                }
                else
                {
                    // Invalid PIN input, handle the situation (e.g., show an error message)
                    ShowErrorMessage("Invalid PIN input");
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"An unexpected error occurred: {ex.Message}");
            }
        }


        private int rabd()
        {
            return new Random().Next();
        }

        private void ShowSuccessMessage(string message)
        {
            MessageBox.Show(message);
        }

        private void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private int Generate(List<int> existingPins)
        {
            Random randomer = new Random();
            int[] digits = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] result = new int[4];

            for (int i = 0; i < 4; i++)
            {
                int index = randomer.Next(0, digits.Length);
                result[i] = digits[index];
                digits[index] = digits[digits.Length - 1];
                Array.Resize(ref digits, digits.Length - 1);
            }

            int generatedPin = result[0] * 1000 + result[1] * 100 + result[2] * 10 + result[3];

            while (existingPins.Contains(generatedPin))
            {
                generatedPin = Generate(existingPins);
            }

            return generatedPin;
        }




        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            SuspendLayout();
            
            textBox1.Location = new Point(409, 249);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 31);
            textBox1.TabIndex = 0;
            textBox1.TextChanged += textBox1_TextChanged;
            
            textBox2.Location = new Point(409, 199);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(102, 31);
            textBox2.TabIndex = 1;

            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(998, 603);
            Controls.Add(textBox1);
            Controls.Add(textBox2);
            AddControls();
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion
    }
}
