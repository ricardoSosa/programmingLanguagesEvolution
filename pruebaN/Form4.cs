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

namespace pruebaN
{
    public partial class Form4 : Form
    {
        GraphClient graphClient;
        public Form4(GraphClient graphClient)
        {
            InitializeComponent();
            this.graphClient = graphClient;
        }

        private void parentsButton_Click(object sender, EventArgs e)
        {
            string selectedLanguage = this.languageText.Text;
            Boolean existsLanguage = existsNode(selectedLanguage);

            if (existsLanguage)
            {
                List<string> parentsList = graphClient.Cypher
                    .Match("(lang:Language)-[:DERIVED_FROM]->(parent:Language)")
                    .Where("lang.name = {name}")
                    .WithParam("name", selectedLanguage)
                    .Return(parent => parent.As<Language>().name)
                    .Results.ToList();

                this.resultList.Items.Clear();
                foreach (string parent in parentsList)
                    this.resultList.Items.Add(parent);
            }
            else
            {
                MessageBox.Show('"' + selectedLanguage + '"' + " does not exist.");
            }
        }

        public bool existsNode(string nodeName)
        {
            Boolean exists;

            var node = graphClient.Cypher
                .OptionalMatch("(lang:Language)")
                .Where("lang.name = {name}")
                .WithParam("name", nodeName)
                .Return(lang => lang.As<Language>().name)
                .Results
                .Single();

            if (node == null)
            {
                exists = false;
            }
            else
            {
                exists = true;
            }

            return exists;
        }

        private void childrenButton_Click(object sender, EventArgs e)
        {
            string selectedLanguage = this.languageText.Text;
            Boolean existsLanguage = existsNode(selectedLanguage);

            if (existsLanguage)
            {
                List<string> childrenList = graphClient.Cypher
                    .Match("(lang:Language)<-[:DERIVED_FROM]-(child:Language)")
                    .Where("lang.name = {name}")
                    .WithParam("name", selectedLanguage)
                    .Return(child => child.As<Language>().name)
                    .Results.ToList();

                this.resultList.Items.Clear();
                foreach (string child in childrenList)
                    this.resultList.Items.Add(child);
            }
            else
            {
                MessageBox.Show('"' + selectedLanguage + '"' + " does not exist.");
            }
        }
    }
}
