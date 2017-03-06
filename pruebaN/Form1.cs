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
            string languageName = Interaction.InputBox("Nombre del lenguaje: ", "Agregar lenguaje de programación");
            Language newLanguage = new Language(languageName);
            graphClient.Cypher
                .Merge("(lan:Language { Name: {name} })")
                .OnCreate()
                .Set("lan = {newLanguage}")
                .WithParams(new {
                    name = newLanguage.getName(),
                    newLanguage
                })
                .ExecuteWithoutResults();
            //var tomHanks =
            //    graphClient.Cypher.Match("(person:Person)")
            //    .Where((Person person) => person.name == "Tom Hanks")
            //    .Return(person => person.As<Person>())
            //    .Results
            //    .Single();

            //string actorsName = "Tom Hanks";
            //List<string> cocoActors =
            //graphClient.Cypher
            //.Match("(tom:Person {name:{nameParam}})-[:ACTED_IN]->(m)<-[:ACTED_IN]-(coActor:Person),(coActor)-[:ACTED_IN]->(m2)<-[:ACTED_IN]-(cocoActor:Person)")
            //.WithParam("nameParam", actorsName)
            //.Where("NOT (tom)-[:ACTED_IN]->(m2)")
            //.ReturnDistinct(cocoActor => cocoActor.As<Person>().name)
            //.Results.ToList();

            //MessageBox.Show(cocoActors[1]);
            //MessageBox.Show(cocoActors[2]);

            //graphClient.Cypher
            //    .Create("INDEX ON :Animal(name)").ExecuteWithoutResults();
        }

        private void readButton_Click(object sender, EventArgs e)
        {

        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();

            if (f2.ShowDialog() == DialogResult.OK)
            {
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            string languageName = Interaction.InputBox("Nombre del lenguaje: ", "Eliminar lenguaje de programación");
            graphClient.Cypher
                .OptionalMatch("(lan:Language)")
                .Where("lan.name = {languageName}")
                .WithParams(new
                {
                    languageName = languageName
                })
                .Delete("lan")
                .ExecuteWithoutResults();
        }
    }

    public class Language
    {
        public string name;

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
