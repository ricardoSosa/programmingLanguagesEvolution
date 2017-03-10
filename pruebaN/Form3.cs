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
            string newParent = Interaction.InputBox("Introduce the new parent's name: ", "Add new parent");
            if(newParent != "")
            {
                //Validating the parent's existence.
                var selected = graphClient.Cypher
                    .OptionalMatch("(lang:Language)")
                    .Where("lang.name = {name}")
                    .WithParam("name", newParent)
                    .Return(lang => lang.As<Language>().name)
                    .Results
                    .Single();
                if (selected == null)
                {
                    MessageBox.Show('"' + newParent + '"' + " does not exist.");
                }
                else
                {
                    //Validating if it's an actual parent.
                    if (this.parentsList.Items.Contains(newParent))
                    {
                        MessageBox.Show('"' + newParent + '"' + " is an actual parent.");
                    }
                    else
                    {
                        graphClient.Cypher
                            .Match("(langA:Language), (langB:Language)")
                            .Where("langA.name = {nameA}")
                            .WithParam("nameA", selectedLanguage)
                            .AndWhere("langB.name = {nameB}")
                            .WithParam("nameB", newParent)
                            .Create("(langA)-[:DERIVED_FROM]->(langB)")
                            .ExecuteWithoutResults();
                        this.parentsList.Items.Add(newParent);
                    }
                }
            }    
        }

        private void deletePButton_Click(object sender, EventArgs e)
        {
            if (this.parentsList.SelectedIndex == -1)
            {
                MessageBox.Show("No selected.");
            }
            else
            {
                string languageToDelete = this.parentsList.SelectedItem.ToString();
                DialogResult dialogResult = MessageBox
                    .Show("Are you sure you want to delete " + '"' + languageToDelete + '"' + " as a parent?",
                        "Deletion of a parent",
                        MessageBoxButtons.YesNo);

                if(dialogResult == DialogResult.Yes)
                {
                    graphClient.Cypher
                    .Match("(langA:Language)-[d:DERIVED_FROM]->(langB:Language)")
                    .Where("langA.name = {nameA}")
                    .WithParam("nameA", selectedLanguage)
                    .AndWhere("langB.name = {nameB}")
                    .WithParam("nameB", languageToDelete)
                    .Delete("d")
                    .ExecuteWithoutResults();

                    this.parentsList.Items.Remove(languageToDelete);
                }
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            if(this.selectTextField.Text != "")
            {
                selectedLanguage = this.selectTextField.Text;
                //Validation
                var selected = graphClient.Cypher
                    .OptionalMatch("(lang:Language)")
                    .Where("lang.name = {name}")
                    .WithParam("name", selectedLanguage)
                    .Return(lang => lang.As<Language>().name)
                    .Results
                    .Single();
                if (selected == null)
                {
                    this.selectedLabel.Text = "Parents:";
                    this.parentsList.Items.Clear();
                    this.addPButton.Enabled = false;
                    this.deletePButton.Enabled = false;
                    MessageBox.Show('"' + selectedLanguage + '"' + " does not exist.");
                }
                else
                {
                    List<string> parentsList = graphClient.Cypher
                                    .Match("(lang:Language)-[:DERIVED_FROM]->(parent:Language)")
                                    .Where("lang.name = {name}")
                                    .WithParam("name", selectedLanguage)
                                    .Return(parent => parent.As<Language>().name)
                                    .Results.ToList();

                    this.selectedLabel.Text = '"' + selectedLanguage + '"' + " parents:";
                    this.parentsList.Items.Clear();
                    foreach (string parent in parentsList)
                        this.parentsList.Items.Add(parent);
                    this.addPButton.Enabled = true;
                    this.deletePButton.Enabled = true;
                }
            }
        }

        private void selectTextField_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
