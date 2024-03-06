using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace examen_practico_RA2_Michael_Rijo_5toD1
{
    public partial class Form1 : Form
    {
        private List<Persona> estudiante = new List<Persona>();
        public Form1()
        {
            InitializeComponent();
            cb_curso.Items.AddRange(new object[] { "cuarto", "quinto", "sexto" });
            cb_seccion.Items.AddRange(new object[] { "A", "B", "C","D","E" });
            cb_area.Items.AddRange(new object[] { "Enfermeria", "Contabilidad", "Gastronomia","Informatica","Electricidad" });
        }

        private void btn_Nuevo_Click(object sender, EventArgs e)
        {  
            btn_Nuevo.Enabled = false;
            btn_Guardar.Enabled = true;
            btn_agregar.Enabled = true;
            btn_Eliminar.Enabled = false;


         
           
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            btn_Guardar.Enabled = false;
            btn_Eliminar.Enabled = true;
            btn_agregar.Enabled = true;
            btn_Nuevo.Enabled = true;

            DialogResult resultado = sfg_guardar.ShowDialog();

            // Verificar si el usuario presionó el botón Guardar
            if (resultado == DialogResult.OK)
            {

                string ruta_archivo = sfg_guardar.FileName;
                string crea_texto = ruta_archivo;


                using (StreamWriter archivo = File.CreateText(ruta_archivo))
                {
                 
                    foreach (DataGridViewRow fila in dgv_datos.Rows)
                    {
                        // Obtiene los valores de las celdas 
                        string valorColumna1 = fila.Cells[0].Value?.ToString() ?? "";
                        string valorColumna2 = fila.Cells[1].Value?.ToString() ?? "";
                        string valorColumna6 = fila.Cells[6].Value?.ToString() ?? "";
                        string valorColumna7 = fila.Cells[7].Value?.ToString() ?? "";
                        string valorColumna8 = fila.Cells[8].Value?.ToString() ?? "";

                        // Escribe los valores en el archivo de texto
                        archivo.WriteLine($"\rMatricula: {valorColumna1},\rNombre: {valorColumna2},\rCurso: {valorColumna6},\rsecccion: {valorColumna7},\rArea: {valorColumna8}");
                           
                           
                    }
                }
            }
        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {

            btn_Eliminar.Enabled = true;
            txt_Matricula.Focus();

            string genero = rgv_femenino.Checked ? "Femenino" : "Masculino";
            dgv_datos.Rows.Add(txt_Matricula.Text,txt_Nombre.Text,txt_Direccionn.Text,
            txt_Telefono.Text,genero,txt_Email.Text,cb_curso.Text,cb_seccion.Text,
            cb_area.Text,txt_Maestro.Text);

            txt_Matricula.Clear();
            txt_Nombre.Clear();
            txt_Direccionn.Clear();
            txt_Telefono.Clear();
            txt_Email.Clear();
            cb_curso.Items.Clear();
            cb_seccion.Items.Clear();
            cb_area.Items.Clear();
            txt_Maestro.Clear();


           
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (dgv_datos.Rows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar una fila para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int fila;
                fila = dgv_datos.CurrentRow.Index;
                DialogResult respuesta;
                respuesta = MessageBox.Show("Desea eliminar este registro?", "Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta == DialogResult.Yes)
                {
                    dgv_datos.Rows.RemoveAt(fila);
                    MessageBox.Show("Registro eliminado");

                }
            }
        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            DialogResult Respuesta;
            Respuesta =MessageBox.Show("Desea salir de la aplicacion","Aviso",MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation);
            if(Respuesta==DialogResult.Yes) {
            Close();
            }
        }

        private void btn_Limpiar_Click(object sender, EventArgs e)
        {
            txt_Matricula.Clear();
            txt_Nombre.Clear();
            txt_Telefono.Clear();
            txt_Email.Clear();
            txt_Direccionn.Clear();
            txt_Maestro.Clear();
            dgv_datos.Rows.Clear();
            cb_curso.Items.Clear();
            cb_seccion.Items.Clear();
            cb_area.Items.Clear();
            

        }
    }
}
