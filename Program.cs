using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Diagnostics;

namespace pastanova
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.Run(new Formulario());
        }
    }

	public class Formulario : Form {

		Label lblNome;
		Label lblDtnasc;
		Label lblCpf;
		Label lblDiasdev;

		RichTextBox txtNome;
		TextBox txtDtnasc;
		MaskedTextBox txtCpf;
		ComboBox cbDiasdev;
		NumericUpDown numDiasDev;

		CheckBox chbAtivo;

		RadioButton rbSexoMasc;
		RadioButton rbSexoFem;

		RadioButton rbCasado;
		RadioButton rbSolteiro;

		GroupBox gpSexo;
		GroupBox gpEstadoCivil;

		Button btnConfirmar;
		Button btnCancelar;

		PictureBox pbImagem;
		LinkLabel linkHelp;

		ListBox listBox;
		ListView listView;
		CheckedListBox checkedList;

		public Formulario(){
			this.BackColor = ColorTranslator.FromHtml("#38323e");
			this.Text = "Titulo da Janela";

			lblNome = new Label();
			lblNome.Text = "Nome:";
			lblNome.Location = new Point(20,20);

			lblDtnasc = new Label();
			lblDtnasc.Text = "Data de Nascimento.:";
			lblDtnasc.AutoSize = true;
			lblDtnasc.Location = new Point(20,60);

			lblCpf = new Label();
			lblCpf.Text = "C.P.F.:";
			lblCpf.Location = new Point(20,100);

			lblDiasdev = new Label();
			lblDiasdev.Text = "Dias Dev.:";
			lblDiasdev.Location = new Point(20,140);

			txtNome = new RichTextBox();
			txtNome.Location = new Point(180, 20);
			txtNome.Size = new Size(100,18);
			txtNome.LoadFile("texto.rtf");

			txtDtnasc = new TextBox();
			txtDtnasc.Location = new Point(180, 60);
			txtDtnasc.Size = new Size(100,18);

			txtCpf = new MaskedTextBox();
			txtCpf.Location = new Point(180, 100);
			txtCpf.Size = new Size(100,18);
			txtCpf.Mask = "000,000,000-00";

			string[] diasDev = { "5", "10", "15", "20" };
			cbDiasdev = new ComboBox();
			foreach (var diaDev in diasDev)
			{
				cbDiasdev.Items.Add(diaDev);
			}
			cbDiasdev.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			cbDiasdev.Location = new Point(180, 140);
			cbDiasdev.Size = new Size(100,18);
			cbDiasdev.Sorted = true;
			
			numDiasDev = new NumericUpDown();
			numDiasDev.Location = new Point(280, 140);
			numDiasDev.Size = new Size(100,18);
			numDiasDev.Maximum = 20;
			numDiasDev.Minimum = 5;
			numDiasDev.Increment = 5;
			numDiasDev.ReadOnly = true;

			chbAtivo = new CheckBox();
			chbAtivo.Location = new Point(180, 180);
			chbAtivo.Size = new Size(100,18);
			chbAtivo.Text = "Ativo?";

			gpSexo = new GroupBox();
			gpSexo.Location = new Point(180,220);
			gpSexo.Size = new Size(200,40);
			gpSexo.Text = "Sexo";

			rbSexoMasc = new RadioButton();
			rbSexoMasc.Location = new Point(15,15);
			rbSexoMasc.Size = new Size(100,18);
			rbSexoMasc.Text = "Masculino";

			rbSexoFem = new RadioButton();
			rbSexoFem.Location = new Point(120,15);
			rbSexoFem.Size = new Size(100,18);
			rbSexoFem.Text = "Feminino";

			gpSexo.Controls.Add(rbSexoMasc);
			gpSexo.Controls.Add(rbSexoFem);

			gpEstadoCivil = new GroupBox();
			gpEstadoCivil.Location = new Point(180,260);
			gpEstadoCivil.Size = new Size(200,40);
			gpEstadoCivil.Text = "Estado Civil";

			rbSolteiro = new RadioButton();
			rbSolteiro.Location = new Point(15,15);
			rbSolteiro.Size = new Size(100,18);
			rbSolteiro.Text = "Solteiro";

			rbCasado = new RadioButton();
			rbCasado.Location = new Point(120,15);
			rbCasado.Size = new Size(100,18);
			rbCasado.Text = "Casado";

			gpEstadoCivil.Controls.Add(rbSolteiro);
			gpEstadoCivil.Controls.Add(rbCasado);

			btnConfirmar = new Button();
			btnConfirmar.Text = "Confirmar";
			btnConfirmar.Size = new Size(100,30);
			btnConfirmar.Location = new Point(180, 320);
			btnConfirmar.Click += new EventHandler(this.btnConfirmarClick);

			btnCancelar = new Button();
			btnCancelar.Text = "Cancelar";
			btnCancelar.Size = new Size(100,30);
			btnCancelar.Location = new Point(180, 360);
			btnCancelar.Click += new EventHandler(this.btnCancelarClick);

			pbImagem = new PictureBox();
			pbImagem.BackColor = Color.Red;
			pbImagem.Size = new Size(100,100);
			pbImagem.Location = new Point(50,320);
			pbImagem.ClientSize = new Size(100,100);
			pbImagem.Load("image.png");
			pbImagem.SizeMode = PictureBoxSizeMode.Zoom;

			linkHelp = new LinkLabel();
			linkHelp.Location = new Point(50, 280);
			linkHelp.Size = new Size(100,30);
			linkHelp.Text = "Ajuda";
			linkHelp.LinkClicked += new LinkLabelLinkClickedEventHandler(this.helpLink);

			listBox = new ListBox();
			listBox.Items.Add("Kill Bill");
			listBox.Items.Add("Rei Leão");
			listBox.Items.Add("Coringa");
			listBox.Location = new Point(15, 180);
			listBox.Size = new Size(100,100);
			// listBox.SelectionMode = SelectionMode.None;
			// listBox.MultiColumn = true;
			// listBox.EndUpdate();
			
			listView = new ListView();
			listView.Location = new Point(15, 180);
			listView.Size = new Size(150,100);
			listView.View = View.Details;
			ListViewItem filme1 = new ListViewItem("Kill Bill");
			filme1.SubItems.Add("3");
			filme1.SubItems.Add("2001");
			ListViewItem filme2 = new ListViewItem("Rei Leão");
			filme2.SubItems.Add("2");
			filme2.SubItems.Add("1994");
			ListViewItem filme3 = new ListViewItem("Coringa");
			filme3.SubItems.Add("1");	
			filme3.SubItems.Add("2020");		
			listView.Items.AddRange(new ListViewItem[]{filme1, filme2, filme3});
			listView.Columns.Add("Nome", -2, HorizontalAlignment.Left);
    		listView.Columns.Add("Estoque", -2, HorizontalAlignment.Left);
			listView.Columns.Add("Ano", -2, HorizontalAlignment.Left);
			listView.FullRowSelect = true;
			listView.GridLines = true;
			listView.AllowColumnReorder = true;
			listView.Sorting = SortOrder.Ascending;
		
			checkedList = new CheckedListBox();
			checkedList.Location = new Point(15, 180);
			checkedList.Size = new Size(150,100);
			string[] filmes = { "Kill Bill", "Rei Leão", "Coringa" };
			checkedList.Items.AddRange(filmes);
			checkedList.SelectionMode = SelectionMode.One;
			checkedList.CheckOnClick = true;
			// checkedList.CheckedItems;
 

			this.Controls.Add(lblNome);
			this.Controls.Add(lblDtnasc);
			this.Controls.Add(lblCpf);
			this.Controls.Add(lblDiasdev);
			this.Controls.Add(txtNome);
			this.Controls.Add(txtDtnasc);
			this.Controls.Add(txtCpf);
			this.Controls.Add(cbDiasdev);
			this.Controls.Add(numDiasDev);
			this.Controls.Add(btnCancelar);
			this.Controls.Add(btnConfirmar);
			this.Controls.Add(chbAtivo);
			this.Controls.Add(gpSexo);
			this.Controls.Add(gpEstadoCivil);
			this.Controls.Add(pbImagem);
			this.Controls.Add(linkHelp);
			//this.Controls.Add(listBox);
			//this.Controls.Add(listView);
			//this.Controls.Add(checkedList);
			this.Size = new Size(400,450);

		}

		private void helpLink(object sender, LinkLabelLinkClickedEventArgs e){
			this.linkHelp.LinkVisited = true;

			Process.Start(
				"google-chrome",
				"https://portal.sc.senac.br/"
			);
		}

		private void btnConfirmarClick(object sender, EventArgs e) {
			
			string nomeFilmes = "";

			string sexo = "Indefinido";
			foreach(var controle in this.gpSexo.Controls){
				RadioButton	radio = controle as RadioButton;

				if (radio != null && radio.Checked)
				{
					sexo = radio.Text;
				}
			}

			foreach(var element in listBox.SelectedItems)
				nomeFilmes += element;

			MessageBox.Show(
				$"Nome.: {this.txtNome.Text}\n" +
				$"Data Nasc.: {this.txtDtnasc.Text}\n" +
				$"C.P.F.: {this.txtCpf.Text}\n" +
				$"Dias Dev.: {this.cbDiasdev.Text}" +
				$"Ativo.: {(this.chbAtivo.Checked ? "Ativo" : "Inativo")}\n" +
				$"Sexo.: {(this.rbSexoMasc.Checked ? "Masculino" : this.rbSexoFem.Checked ? "Feminino" : "Indefinido" )}\n"+
				$"Sexo.: { sexo }\n" +
				$"Filmes.: { nomeFilmes }\n" +
				$"Estado Civil.: {(this.rbCasado.Checked ? "Casado" : "Solteiro")}",
				"Cliente",
				MessageBoxButtons.OK
			);
		}

		private void btnCancelarClick(object sender, EventArgs e) {
			this.Close();
		}
	}
}
