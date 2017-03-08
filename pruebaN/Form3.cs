using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Neo4jClient;
using Microsoft.VisualBasic;

namespace pruebaN
{
    public partial class Form3 : Form
    {
        GraphClient graphClient;
        string selectedLanguage;

        public Form3(GraphClient graphClient)
        {
            InitializeComponent();
            this.graphClient = graphClient;
            this.addPButton.Enabled = false;
            this.deletePButton.Enabled = false;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void addPButton_Click(object sender, EventArgs e)
        {
            //string nameB = Interaction.InputBox("Introduce the new parent's name: ", "Add new parent");
            //var tomHanks =
            // graphClient.Cypher
            //    .Match("(langA:Language), (langB:Language)")
            //    .Where("langA.name = {nameA}")
            //    .WithParam("nameA", )
            //    .AndWhere("langB.name = {nameB}")
            //    .Return(lan => lan.As<Language>().name)
            //    .Results;
            //foreach (var person in tomHanks)
            //    MessageBox.Show("" + person);
        }

        private void deletePButton_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            selectedLanguage = this.selectTextField.Text;
            var parentsList = graphClient.Cypher
                                .Match("(lang:Language)-[:DERIVED_FROM]->(parent:Language)")
                                .Where("lang.name = {name}")
                                .WithParam("name", selectedLanguage)
                                .Return(parent => parent.As<Language>().name)
                                .Results.ToList();

            this.parentsList.Items.Clear();
            foreach (var parent in parentsList)
                this.parentsList.Items.Add(parent);
        }

        private void selectTextField_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
