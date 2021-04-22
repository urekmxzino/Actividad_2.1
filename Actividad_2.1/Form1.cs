using Actividad_2._1.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Actividad_2._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BDContext bd = new BDContext();

            comboCursos.DataSource = bd.Cursos.ToList();
            comboCursos.DisplayMember = "Nombre";
        }

        private void comboCursos_SelectedIndexChanged(object sender, EventArgs e)
        {
            BDContext bd = new BDContext();

            Cursos cursoSeleccionado = (Cursos)comboCursos.SelectedItem;

            List<Alumnos> AlumnosDelCurso = bd.Alumnos.Where(Cursos => Cursos.idCurso == cursoSeleccionado.idCurso).ToList();
            gridAlumnos.DataSource = AlumnosDelCurso;
            gridAlumnos.Columns[2].Visible = false;
            gridAlumnos.Columns[3].Visible = false;
            gridAlumnos.Columns[4].Visible = false;

            List<Profesores> ProfesoresDelCurso = bd.Profesores.Where(Cursos => Cursos.idProfesor == cursoSeleccionado.idProfesor).ToList();
            gridProfesores.DataSource = ProfesoresDelCurso;
            gridProfesores.Columns[2].Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
