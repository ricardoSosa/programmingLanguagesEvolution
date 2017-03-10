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

    public partial class Form1 : Form
    {
        GraphClient graphClient;
        public Form1()
        {
            InitializeComponent();
            graphClient = new GraphClient(new Uri("http://localhost:7474/db/data"), "neo4j", "pruebas");
            graphClient.Connect();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void createButton_Click(object sender, EventArgs e)
        {
            string languageName = Interaction.InputBox("Language name: ", "Add programming language");
            Language newLanguage = new Language(languageName);
            graphClient.Cypher
                .Merge("(lan:Language {name: {name}})")
                .OnCreate()
                .Set("lan = {newLanguage}")
                .WithParams(new {
                    name = newLanguage.getName(),
                    newLanguage
                })
                .ExecuteWithoutResults();
        }

        private void readButton_Click(object sender, EventArgs e)
        {

        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();

            if (f2.ShowDialog() == DialogResult.OK)
            {
                string option = f2.getComboText();
                switch (option)
                {
                    case "Modify parents":
                        using (Form3 f3 = new Form3(graphClient))
                        {
                            f3.ShowDialog(this);
                        }
                        break;
                    case "Change name":
                        string languageName = Interaction.InputBox("Language name: ", "Change language name");
                        //Validating the parent's existence.
                        var selected = graphClient.Cypher
                            .OptionalMatch("(lang:Language)")
                            .Where("lang.name = {name}")
                            .WithParam("name", languageName)
                            .Return(lang => lang.As<Language>().name)
                            .Results
                            .Single();
                        if (selected == null)
                        {
                            MessageBox.Show("Language does not exist");
                        }
                        else
                        {
                            string newName = Interaction.InputBox("New name: ", "Add new name");
                            graphClient.Cypher
                                .Match("(lang:Language {name: {oldName}})")
                                .Set("lang.name = {newName}")
                                .WithParams(new
                                {
                                    oldName = languageName,
                                    newName = newName
                                })
                                .ExecuteWithoutResults();
                            MessageBox.Show("The name has been changed.");
                        }
                        break;
                }
            }
        }
        
        private void deleteButton_Click(object sender, EventArgs e)
        {
            string languageName = Interaction.InputBox("Language name: ", "Delete programming language");

            //Validating the parent's existence.
            var selected = graphClient.Cypher
                .OptionalMatch("(lang:Language)")
                .Where("lang.name = {name}")
                .WithParam("name", languageName)
                .Return(lang => lang.As<Language>().name)
                .Results
                .Single();
            if (selected == null)
            {
                MessageBox.Show("Language does not exist");
            }
            else
            {
                DialogResult dialogResult = MessageBox
                    .Show("Are you sure you want to delete " + '"' + languageName + '"' + "?",
                        "Deletion of a language",
                        MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    graphClient.Cypher
                        .OptionalMatch("(lan:Language)")
                        .Where("lan.name = {languageName}")
                        .WithParam("languageName", languageName)
                        .DetachDelete("lan")
                        .ExecuteWithoutResults();
                }
            }
        }
    }

    public class Language
    {
        public string name;

        public Language()
        {

        }

        public Language(string name)
        {
            this.name = name;
        }

        public string getName()
        {
            return name;
        }

        public void setName(string name)
        {
            this.name = name;
        }
    }
}
