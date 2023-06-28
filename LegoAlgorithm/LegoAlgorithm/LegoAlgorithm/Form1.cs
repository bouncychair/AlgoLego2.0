using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LegoAlgorithm
{
    public partial class Form1 : Form
    {
        // CsvS<string> _csv = new CsvS<string>();
        private ChrisArrayList<string> _arrayList;
        private CorvinLinkedList<string> _linkedList;
        private Dll<string> _doubleLinkedList;
        private object[] values;
        public Form1()
        {
            InitializeComponent();
            //_csv.NodeBuilder("C:\\Users\\Chris\\Source\\Repos\\AlgoLego2.0\\LegoAlgorithm\\LegoAlgorithm\\LegoAlgorithm\\colors.csv");
            this._arrayList = new ChrisArrayList<string>();
            this._linkedList = new CorvinLinkedList<string>();
            this._doubleLinkedList = new Dll<string>();
            DefaultOptions();
        }
        private void importCSVBtn_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV Files (*.csv)|*.csv";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                using (StreamReader reader = new StreamReader(filePath))
                {
                    reader.ReadLine();

                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] fields = line.Split(','); //check here
                        if (fields.Length >= 2)
                        {
                            InsertIntoAll(fields[1].Trim());
                        }
                        outputListBox.Items.Add(string.Join(", ", fields));
                    }
                }
                /*using (StreamReader sr = new StreamReader(filePath))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        values = line.Split(',');

                        foreach (string data in values)
                        {
                            InsertIntoAll(data);
                            
                        }
                        outputListBox.Items.Add(string.Join(", ", values));
                    }
                }*/

            }
        }


    private void InsertIntoAll(string data)
            {
                try
                {
                    _arrayList.Add(data);
                    _linkedList.AddLast(data);
                    _doubleLinkedList.AddLastNode(data);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }

            private void DefaultOptions()
            {
                BinarySearchRadio.Enabled = false;
                BinarySearchRadio.Checked = false;
                SentinelSearchRadio.Enabled = false;
                SentinelSearchRadio.Checked = false;

                QuickSortRadio.Enabled = false;
                BubbleSortRadio.Enabled = false;
                LinearSearchRadio.Enabled = false;
                ForwardTraversRadio.Enabled = false;
                BackwardsTraversRadio.Enabled = false;

                QuickSortRadio.Checked = false;
                BubbleSortRadio.Checked = false;
                LinearSearchRadio.Checked = false;
                ForwardTraversRadio.Checked = false;
                BackwardsTraversRadio.Checked = false;

                SortBtn.Enabled = false;
                SearchBtn.Enabled = false;
            }

            private void collectionChoice_SelectedIndexChanged(object sender, EventArgs e)
            {
                chosenList.Text = collectionChoice.Text;
            }

            private void collectionChoice_SelectionChangeCommitted(object sender, EventArgs e)
            {
                DefaultOptions();
                string selectedOption = collectionChoice.SelectedItem.ToString();

                if (selectedOption.Equals("ArrayList"))
                {
                    BinarySearchRadio.Enabled = true;
                    LinearSearchRadio.Enabled = true;
                    QuickSortRadio.Enabled = true;
                    BubbleSortRadio.Enabled = true;
                    SearchBtn.Enabled = true;
                    SortBtn.Enabled = true;
                }
                else if (selectedOption.Equals("LinkedList"))
                {
                    BinarySearchRadio.Enabled = true;
                    LinearSearchRadio.Enabled = true;
                    QuickSortRadio.Enabled = true;
                    BubbleSortRadio.Enabled = true;
                    SearchBtn.Enabled = true;
                    SortBtn.Enabled = true;

                }
                else if (selectedOption.Equals("DoubleLinkedList"))
                {
                    BinarySearchRadio.Enabled = true;
                    LinearSearchRadio.Enabled = true;
                    QuickSortRadio.Enabled = true;
                    BubbleSortRadio.Enabled = true;
                    ForwardTraversRadio.Enabled = true;
                    BackwardsTraversRadio.Enabled = true;
                    SentinelSearchRadio.Enabled = true;
                    SearchBtn.Enabled = true;
                    SortBtn.Enabled = true;
                }
            }

            private void SortBtn_Click(object sender, EventArgs e)
            {
            string searchColor = "Black";
            int positionSls = _doubleLinkedList.linearSearch("Black");

            if (positionSls != -1)
            {
                //$ is string inerpolation {} are bindings. String interpolation allows us to bind the variables to the string.
                Console.WriteLine($"Position (sentinel linear search) of '{searchColor}' is {positionSls}");
            }
            else
            {
                Console.WriteLine($"'{searchColor}' not found !");
            }
            //do something
        }

            /* private T GetCollectionType(string collectionType)
             {
                 if (collectionType.Equals("LinkedList"))
                 {
                     return _linkedList;
                 }
                 else if (collectionType.Equals("ArrayList"))
                 {
                     return _arrayList;
                 }
                 else if (collectionType.Equals("BinarySearchTree"))
                 {
                     return null;
                 }
                 else
                 {
                     throw new InvalidOperationException("This collection wont work with this item");
                 }
             }*/
        }
    }
