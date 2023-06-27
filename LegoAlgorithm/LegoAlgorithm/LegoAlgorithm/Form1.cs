﻿using System;
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
        CsvS<string> _csv = new CsvS<string>();

        public Form1()
        {
            InitializeComponent();
            _csv.NodeBuilder("C:\\Users\\Chris\\Source\\Repos\\AlgoLego2.0\\LegoAlgorithm\\LegoAlgorithm\\LegoAlgorithm\\colors.csv");
        }

        private void ImportCSVBtn_Click(object sender, EventArgs e)
        {
            FileDialog fileDialog = new OpenFileDialog()
            {
                Filter = "CSV Files (*.csv)|*.csv",
            };
            if (fileDialog.ShowDialog().Equals(DialogResult.OK))
            {
                try
                {
                    using (StreamReader sr = new StreamReader(fileDialog.FileName))
                    {
                        //ignores fist line
                        bool firtstline = true;
                        while (!sr.EndOfStream)
                        {
                            //read line
                            string line = sr.ReadLine();
                            //split line
                            string[] values = line.Split(',');
                            if (firtstline)
                            {
                                foreach (string s in values)
                                {
                                    //result_TB.Text += s + "\t";
                                }
                                //result_TB.Text += "\n";
                                firtstline = false;
                            }
                            else
                            {
                                int id = int.Parse(values[0]);
                                string name = values[1];
                                string rgb = values[2];
                                string transparency = values[3];
                                //create new lego data
                                //LegoData legoData = new LegoData(id, name, rgb, transparency);
                                //ArrayList.Add(legoData);
                                //add to listbox
                                foreach (string s in values)
                                {
                                    //result_TB.Text += s + "\t";
                                }
                                //result_TB.Text += "\n";
                            }

                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void collectionChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            chosenList.Text = collectionChoice.Text;
        }

        private void collectionChoice_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string selectedOption = collectionChoice.SelectedItem.ToString();

            switch (selectedOption)
            {
                case "ArrayList":
                    HandleArrayList();
                    break;

                case "LinkedList":
                    //LinkedList<T> LinkedList = new LinkedList<T>();

                    break;

                case "DoubleLinkedList":
                    //DoubleLinkedList<T> DoubleLinkedList = new DoubleLinkedList<>();
                    break;
            }
        }

        private void HandleArrayList()
        {
            
            //ChrisArrayList<T> arrayList = new ChrisArrayList<T>();
            
        }
    }
}
