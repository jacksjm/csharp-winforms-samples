using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.IO;

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
			Application.EnableVisualStyles();
            Application.Run(new Formulario());
        }
    }

	public class Formulario : Form {

		TabControl tabControl;
		TabPage tabPagePrincipal;
		TabPage tabPageSecundario;

		ToolTip toolTipNome = new ToolTip();

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

		Button btnOpenFile;

		PictureBox pbImagem;
		LinkLabel linkHelp;

		ListBox listBox;
		ListView listView;
		CheckedListBox checkedList;

		MonthCalendar mcCalendar;

		DateTimePicker dtPicker;

		ProgressBar pbTest;

		WebBrowser webBrowse;

		TrackBar track;
		TextBox textBox1;

		public Formulario(){
			this.Text = "Titulo da Janela";

			tabPagePrincipal = new TabPage();
			tabPagePrincipal.Text = "Principal";
			tabPagePrincipal.Size = new Size(900, 550);

			tabPageSecundario = new TabPage();
			tabPageSecundario.Text = "Secundário";
			tabPageSecundario.Size = new Size(900, 550);

			tabControl = new TabControl();
            tabControl.Location = new Point(0,35);
			tabControl.Size = new Size(900, 550);
            tabControl.Controls.Add(tabPagePrincipal);
            tabControl.Controls.Add(tabPageSecundario);

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

			toolTipNome.AutoPopDelay = 5000;
			toolTipNome.InitialDelay = 1000;
			toolTipNome.ReshowDelay = 500;
			toolTipNome.ShowAlways = true;
			toolTipNome.SetToolTip(txtNome, "Informe o nome");

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
			rbSexoFem.Size = new Size(70,18);
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
			rbCasado.Size = new Size(70,18);
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

			btnOpenFile = new Button();
			btnOpenFile.Text = "Open File";
			btnOpenFile.Size = new Size(100,30);
			btnOpenFile.Location = new Point(280, 360);
			btnOpenFile.Click += new EventHandler(this.btnOpenFileClick);

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

            // DateTime dtInicial = new DateTime(2020,05,16);
			mcCalendar = new MonthCalendar();
			mcCalendar.Location = new Point(400, 15);
			// mcCalendar.MaxSelectionCount = 10;
			// mcCalendar.MinDate = new DateTime(2019,05,10);
			// mcCalendar.MaxDate = new DateTime(2020,12,31);
			// mcCalendar.SelectionRange = new SelectionRange(dtInicial, new DateTime(2020,05,19));
			
			dtPicker = new DateTimePicker();
			dtPicker.Location = new Point(575, 15);
            dtPicker.Size = new Size(300,15);
			// dtPicker.Format = DateTimePickerFormat.Time;
			// dtPicker.Format = DateTimePickerFormat.Custom;
			// dtPicker.CustomFormat = "dd/MM/yyyy HH:mm";
			// dtPicker.ShowCheckBox = true;
   			// dtPicker.ShowUpDown = true;

			pbTest = new ProgressBar();
			pbTest.Location = new Point(400, 200);
            pbTest.Size = new Size(300,15);
			pbTest.Value = 0;
            pbTest.Maximum = 100;
            pbTest.Step = 1;
			// pbTest.Style = ProgressBarStyle.Marquee;
			// pbTest.MarqueeAnimationSpeed = 30;
			
			webBrowse = new WebBrowser();
			webBrowse.Location = new Point(500, 200);
			webBrowse.Size = new Size(200,200);
			webBrowse.Navigate("https://www.google.com");

			track = new TrackBar();
			track.Location = new System.Drawing.Point(8, 8);
			track.Size = new System.Drawing.Size(224, 45);
			track.Maximum = 30;
			track.TickFrequency = 5;
			track.LargeChange = 5;
			track.SmallChange = 5;
			track.Scroll += new EventHandler(track_Scroll);

			textBox1 = new TextBox();
			textBox1.Location = new System.Drawing.Point(300,300);

            // Create ToolStripPanel controls.
            /*ToolStripPanel tspTop = new ToolStripPanel();
            ToolStripPanel tspBottom = new ToolStripPanel();
            ToolStripPanel tspLeft = new ToolStripPanel();
            ToolStripPanel tspRight = new ToolStripPanel();

            // Dock the ToolStripPanel controls to the edges of the form.
            tspTop.Dock = DockStyle.Top;
            tspBottom.Dock = DockStyle.Bottom;
            tspLeft.Dock = DockStyle.Left;
            tspRight.Dock = DockStyle.Right;

            // Create ToolStrip controls to move among the 
            // ToolStripPanel controls.

            // Create the "Top" ToolStrip control and add
            // to the corresponding ToolStripPanel.
            ToolStrip tsTop = new ToolStrip();
            tsTop.Items.Add("Top");
            tsTop.Items.Add("Novo Item");
            tspTop.Join(tsTop);

            // Create the "Bottom" ToolStrip control and add
            // to the corresponding ToolStripPanel.
            ToolStrip tsBottom = new ToolStrip();
            tsBottom.Items.Add("Bottom");
            tspBottom.Join(tsBottom);

            // Create the "Right" ToolStrip control and add
            // to the corresponding ToolStripPanel.
            ToolStrip tsRight = new ToolStrip();
            tsRight.Items.Add("Right");
            tspRight.Join(tsRight);

            // Create the "Left" ToolStrip control and add
            // to the corresponding ToolStripPanel.
            ToolStrip tsLeft = new ToolStrip();
            tsLeft.Items.Add("Left");
            tspLeft.Join(tsLeft);*/

            // Create a MenuStrip control with a new window.
            MenuStrip ms = new MenuStrip();
            ToolStripMenuItem windowMenu = new ToolStripMenuItem("Window");
            ToolStripMenuItem windowNewMenu = new ToolStripMenuItem("New", null, new EventHandler(windowNewMenu_Click));
            ToolStripMenuItem windowSaveMenu = new ToolStripMenuItem("Save");
            windowSaveMenu.Click += new EventHandler(windowsSaveMenu_Click);
            windowMenu.DropDownItems.Add(windowNewMenu);
            windowMenu.DropDownItems.Add(windowSaveMenu);
            ((ToolStripDropDownMenu)(windowMenu.DropDown)).ShowImageMargin = false;
            ((ToolStripDropDownMenu)(windowMenu.DropDown)).ShowCheckMargin = true;

            // Assign the ToolStripMenuItem that displays 
            // the list of child forms.
            ms.MdiWindowListItem = windowMenu;

            // Add the window ToolStripMenuItem to the MenuStrip.
            ms.Items.Add(windowMenu);

            // Dock the MenuStrip to the top of the form.
            ms.Dock = DockStyle.Top;

            // The Form.MainMenuStrip property determines the merge target.
            this.MainMenuStrip = ms;

            // Add the ToolStripPanels to the form in reverse order.
            /*this.Controls.Add(tspRight);
            this.Controls.Add(tspLeft);
            this.Controls.Add(tspBottom);
            this.Controls.Add(tspTop);*/

            // Add the MenuStrip last.
            // This is important for correct placement in the z-order.
            this.Controls.Add(ms);

			tabPageSecundario.Controls.Add(track);
			tabPageSecundario.Controls.Add(textBox1);

			tabPagePrincipal.Controls.Add(lblNome);
			tabPagePrincipal.Controls.Add(lblDtnasc);
			tabPagePrincipal.Controls.Add(lblCpf);
			tabPagePrincipal.Controls.Add(lblDiasdev);
			tabPagePrincipal.Controls.Add(txtNome);
			tabPagePrincipal.Controls.Add(txtDtnasc);
			tabPagePrincipal.Controls.Add(txtCpf);
			tabPagePrincipal.Controls.Add(cbDiasdev);
			tabPagePrincipal.Controls.Add(numDiasDev);
			tabPagePrincipal.Controls.Add(btnCancelar);
			tabPagePrincipal.Controls.Add(btnOpenFile);
			tabPagePrincipal.Controls.Add(btnConfirmar);
			tabPagePrincipal.Controls.Add(chbAtivo);
			tabPagePrincipal.Controls.Add(gpSexo);
			tabPagePrincipal.Controls.Add(gpEstadoCivil);
			tabPagePrincipal.Controls.Add(pbImagem);
			tabPagePrincipal.Controls.Add(linkHelp);
			// tabPagePrincipal.Controls.Add(listBox);
			// tabPagePrincipal.Controls.Add(listView);
			// tabPagePrincipal.Controls.Add(checkedList);
			tabPagePrincipal.Controls.Add(mcCalendar);
			tabPagePrincipal.Controls.Add(dtPicker);
			tabPagePrincipal.Controls.Add(pbTest);
			tabPagePrincipal.Controls.Add(webBrowse);
			this.Controls.Add(tabControl);
			this.Size = new Size(900,550);

		}

        private void windowNewMenu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("New!!!!");
        }
        private void windowsSaveMenu_Click(object sender, EventArgs e){
            MessageBox.Show("Save!!!!");
        }
		private void track_Scroll(object sender, EventArgs e) { // Display the trackbar value in the text box. 
			textBox1.Text = "" + track.Value;
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

            for(int i = 0; i < 100; i++){
                Thread.Sleep(500);
                pbTest.PerformStep();
            }

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
				$"Estado Civil.: {(this.rbCasado.Checked ? "Casado" : "Solteiro")}\n" +
				$"Calendário Inicial: {this.mcCalendar.SelectionRange.Start}\n" +
                $"Calendário Final: {this.mcCalendar.SelectionRange.End}\n" +
                $"Picker.: {this.dtPicker.Value}",
				"Cliente",
				MessageBoxButtons.OK
			);

            //pbTest.PerformStep();
		}

		private void btnCancelarClick(object sender, EventArgs e) {
			this.Close();
		}

		private void btnOpenFileClick(object sender, EventArgs e) {
			OpenFileDialog dialog = new OpenFileDialog();
            //dialog.InitialDirectory = @"C:\";
            //dialog.Multiselect = true;
            dialog.Title = "Selecionar arquivos...";
            dialog.Filter = "Arquivo de Texto (*.TXT; *.RTF) |abrirarquivo.txt";
			if (dialog.ShowDialog() != DialogResult.Cancel){
				StreamReader arquivo = new StreamReader(dialog.FileName);
                string conteudo = arquivo.ReadLine();
                arquivo.Dispose();

                MessageBox.Show(conteudo);
			}
		}
	}
}
