using AlgoVizz.Algorithms;
using AlgoVizz.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AlgoVizz
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            // Set default selections
            comboBox1.SelectedIndex = 0;  // Default to "10"
            comboBox2.SelectedIndex = 0;  // Default to "Insertion Sort"
            comboBox3.SelectedIndex = 1;  // Default to "Normal"
            
            // Enable double buffering to prevent flicker
            this.DoubleBuffered = true;
            EnableDoubleBuffer(panel1);
        }

        private static void EnableDoubleBuffer(Control control)
        {
            typeof(Control).GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic)
                ?.SetValue(control, true);
        }

        private List<Element> elements = new List<Element>();
        private AnimationManager animationManager;
        int tk = 20;
        int ICount;

        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Validate input is not empty
                if (string.IsNullOrWhiteSpace(textBox3.Text) || textBox3.Text == "Enter Values Seperated by space")
                {
                    MessageBox.Show("Please enter values separated by space", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                elements.Clear();
                
                string[] myText = textBox3.Text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                
                if (myText.Length == 0)
                {
                    MessageBox.Show("Please enter at least one value", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int[] arr = new int[myText.Length];
                int height = panel1.Height;
                int padding = 30 + 5;

                for (int i = 0; i < myText.Length; i++)
                {
                    if (!int.TryParse(myText[i], out int parsedValue))
                    {
                        MessageBox.Show($"Invalid number: '{myText[i]}'", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    arr[i] = parsedValue;
                }

                int size = arr.Length;

                for (int i = 0; i < size; i++)
                {
                    var start = new Point(padding, height);
                    int value = height - arr[i] * 10;
                    var end = new Point(padding, value);
                    int rvalue = height - value;
                    var element = new Element(start, end, rvalue);
                    elements.Add(element);
                    padding += 40;
                }
                
                // Trigger the paint event to draw elements
                panel1.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            // First, validate that elements exist
            if (elements.Count == 0)
            {
                MessageBox.Show("Please generate or input an array first", "No Array", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate algorithm is selected
            String algo = comboBox2.Text;
            if (string.IsNullOrEmpty(algo) || algo == "")
            {
                MessageBox.Show("Please Select Sorting Algorithm", "Select Sorting Algorithm", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate speed is selected
            String speed = comboBox3.Text;
            if (string.IsNullOrEmpty(speed) || speed == "")
            {
                MessageBox.Show("Please Select Speed", "Select Speed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int s;
            if (speed == "Slow")
            {
                s = 700;
            }
            else if (speed == "Normal")
            {
                s = 200;
            }
            else if (speed == "Fast")
            {
                s = 50;
            }
            else
            {
                s = 200;
            }

            try
            {
                // Disable controls during animation
                DisableControls();

                // Create animation manager
                animationManager = new AnimationManager(panel1, s);

                if (algo == "Insertion Sort")
                {
                    ICount = Algorithms.InsertionSort.Sort(elements, animationManager, tk);
                    textBox1.Text = String.Format("This is an in-place sorting algorithm based on the idea that one element from the input elements is consumed in each iteration to find its correct position i.e, the position to which it belongs in a sorted array." +
                    "\r\n\r\nTime Complexity: O(N^2)" + "\r\n\r\nTotal No. of Iterations: {0}", ICount);
                }
                else if (algo == "Merge Sort")
                {
                    ICount = Algorithms.MergeSort.Sort(elements, animationManager, tk);
                    textBox1.Text = String.Format("Merge Sort is a divide-and-conquer algorithm based on the idea of breaking down a list into several sub-lists until each sublist consists of a single element and merging those sublists in a manner that results into a sorted list." +
                    "\r\n\r\nTime Complexity: O(N log(N)) " + "\r\n\r\nTotal No. of Iterations: {0}", ICount);
                }
                else
                {
                    MessageBox.Show("Algorithm not implemented yet", "Algorithm Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    EnableControls();
                    return;
                }

                textBox2.Text = String.Format("Iterations: {0}\r\nSpeed: {1}ms", ICount, s);

                // Start animation and re-enable controls when done
                animationManager.StartAnimation(() =>
                {
                    panel1.Invalidate();
                    EnableControls();
                    animationManager.Dispose();
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during sorting: {ex.Message}", "Sorting Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                EnableControls();
            }
        }

        private void DisableControls()
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            comboBox3.Enabled = false;
            textBox3.Enabled = false;
        }

        private void EnableControls()
        {
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
            comboBox3.Enabled = true;
            textBox3.Enabled = true;
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox2.Text == "Bubble Sort")
            {
                textBox1.Text = "Bubble Sort is the simplest sorting algorithm that works by repeatedly swapping the adjacent elements if the are in wrong order." +
                    "\r\n\r\nTime Complexity: O(N^2)";
            }
            else if (comboBox2.Text == "Selection Sort")
            {
                textBox1.Text = "Selection Sort algorithm sorts an array by repeatedly finding the minimum element and from the unsorted part and putting it at the beginning." +
                    "\r\n\r\nTime Complexity: O(N^2)";
            }
            else if (comboBox2.Text == "Quick Sort")
            {
                textBox1.Text = "Quicksort is a divide-and-conquer algorithm. It works by selecting the a 'pivot' element from the array and partitioning the other elements into two sub-arrays, according to whether they are less than or greater than the pivot." +
                    "\r\n\r\nTime Complexity: O(N^2)";
            }
            else if (comboBox2.Text == "Merge Sort")
            {
                textBox1.Text = "Merge Sort is a divide-and-conquer algorithm based on the idea of breaking down a list into several sub-lists until each sublist consists of a single element and merging those sublists in a manner that results into a sorted list." +
                    "\r\n\r\nTime Complexity: O(N log(N))";
            }
            else if (comboBox2.Text == "Insertion Sort")
            {
                textBox1.Text = "This is an in-place sorting algorithm based on the idea that one element from the input elements is consumed in each iteration to find its correct position i.e, the position to which it belongs in a sorted array." +
                    "\r\n\r\nTime Complexity: O(N^2)";
            }
            else
            {
                textBox1.Text = "";
            }
        }

        private void textBox1_TextChanged_2(object sender, EventArgs e)
        {
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
        }

        private void label3_Click_1(object sender, EventArgs e)
        {
        }

        private void comboBox3_SelectedIndexChanged_1(object sender, EventArgs e)
        {
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            
            // Draw all elements
            foreach (var element in elements)
            {
                element.Draw(e.Graphics, tk);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox3_Enter_1(object sender, EventArgs e)
        {
            if (textBox3.Text == "Enter Values Seperated by space")
            {
                textBox3.Text = "";
                textBox3.ForeColor = Color.Black;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text == "")
                {
                    MessageBox.Show("Please Select Array Size", "Select Array Size", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                elements.Clear();
                
                var rand = new Random();
                int height = panel1.Height;
                int padding = 30 + 5;

                int size = Convert.ToInt32(comboBox1.Text);

                for (int i = 0; i < size; i++)
                {
                    var start = new Point(padding, height);
                    int value = height - rand.Next(1, 30) * 10;
                    var end = new Point(padding, value);
                    int rvalue = height - value;
                    var element = new Element(start, end, rvalue);
                    elements.Add(element);
                    padding += 40;
                }

                panel1.Invalidate();
            }
            catch (Exception)
            {
                MessageBox.Show("Please Select Array Size", "Select Array Size", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using var pathfindingForm = new PathfindingForm();
            pathfindingForm.ShowDialog(this);
        }
    }
}