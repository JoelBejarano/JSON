using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections;
using System.IO;


namespace JSONpokemon
{
    public partial class Form1 : Form
    {
        int current = 0;
        private ArrayList Pokes = new ArrayList();

        public Form1()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {

            save();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StreamReader inFile = File.OpenText("Pokemon.JSON");
            while (inFile.Peek() != -1 )
            {
                string pString = inFile.ReadLine();
                Pokemon p = JsonSerializer.Deserialize<Pokemon>(pString);
                Pokes.Add(p);
            }
            inFile.Close();
        }
        public void Show(int c)
        {
            if (c >= 0 && c < Pokes.Count)
            {
                Pokemon p = (Pokemon)Pokes[c];
                nameBox.Text = p.name;
                typeBox.Text = p.type;
                moveBox.Text = p.move;
                descriptionBox.Text = p.description;
                if (File.Exists(p.picture))
                {
                    pictureBox1.Load(p.picture);
                }
                weightBox.Text = p.weight;
                heightBox.Text = p.height;
                HPBox.Text = p.HP;
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            save();
            Clear();
        }
        private void Clear()
        {
            nameBox.Clear();
            typeBox.Clear();
            moveBox.Clear();
            descriptionBox.Clear();
            HPBox.Clear();
            weightBox.Clear();
            heightBox.Clear();
            pictureBox1.Image = null;
        }
        public void save()
        {
            var p = new Pokemon
            {
                name = nameBox.Text,
                type = typeBox.Text,
                move = moveBox.Text,
                description = descriptionBox.Text,
                picture = pictureBox1.ImageLocation,
                weight = weightBox.Text,
                height = heightBox.Text,
                HP = HPBox.Text
            };

            Pokes.Add(p);

            StreamWriter outFile = File.CreateText("Pokemon.JSON");
            foreach (var item in Pokes)
            {
                outFile.WriteLine(JsonSerializer.Serialize(item));
            }
            outFile.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            current = 0;
            Show(current);
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            Pokes.Remove(Pokes[current]);
            Show(current - 1);
            save();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            if (System.IO.File.Exists(openFileDialog1.FileName))
                pictureBox1.Load(openFileDialog1.FileName);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Show(Pokes.Count - 1);
            current = Pokes.Count - 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (current > 0)
            {
                current--;
                Show(current);
            }
           
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (current < Pokes.Count)
            {
                current++;
                Show(current);
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {

        }
    }
}
