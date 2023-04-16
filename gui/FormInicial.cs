using M11_PROJETOFINAL.common;
using M11_PROJETOFINAL.gui;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace M11_PROJETOFINAL
{
    public partial class FormInicial : Form
    {

        //CRIAR UM BOTAO PRA SAIR


        /// <summary>
        /// Singleton instance of the FormInicial class, to be used across the program.
        /// </summary>
        public static FormInicial INSTANCE { get; private set; } = new FormInicial();

        string pasta = "./InstrumentosLista/";

        /// <summary>
        /// Main constructor for the FormInicial class. This constructor enforces the usage of the singleton
        /// instance property and sets the form at the center of the screen upon launch.
        /// </summary>
        private FormInicial()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            if (File.Exists("Registo_CompraVenda.xml"))
            {
                FileStream ficheiroExistente = new FileStream("Registo_CompraVenda.xml", FileMode.Open, FileAccess.Read);
                XmlSerializer serie_ = new XmlSerializer(typeof(List<Compra_Venda>));
                List<Compra_Venda> listaExistente = (List<Compra_Venda>)serie_.Deserialize(ficheiroExistente);
                Compra_Venda.Lista.Lista_CompraVenda.AddRange(listaExistente);
                ficheiroExistente.Close();
            }

            if (File.Exists("Registo_Manutencoes.xml"))
            {
                FileStream ficheiroExistente = new FileStream("Registo_Manutencoes.xml", FileMode.Open, FileAccess.Read);
                XmlSerializer serie_ = new XmlSerializer(typeof(List<Manutencoes>));
                List<Manutencoes> listaExistente = (List<Manutencoes>)serie_.Deserialize(ficheiroExistente);
                Manutencoes.Lista.Lista_Manu.AddRange(listaExistente);
                ficheiroExistente.Close();
            }
        }


        private void FormInicial_Load(object sender, EventArgs e)
        {
            FormLogin loginForm = new FormLogin { StartPosition = FormStartPosition.CenterScreen };

            if (loginForm.ShowDialog() == DialogResult.OK)
            {

                this.Show();

            }
            else
            {
                this.Close();
            }

        }

        private void bttGuardar_CompraVenda_Click(object sender, EventArgs e)
        {
            bool dadosValidos = true;


            if (txtNome_CompraVenda.Text == "" || cbxInstrumento_CompraVenda.Text == ""
                || cbxMarca_CompraVenda.Text == "" || txtPreco_CompraVenda.Text == "" || cbxTipo_CompraVenda.Text == "")
            {
                MessageBox.Show("Dados incompletos", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Validação para caso a quantidade de caracteres na textbox número seja menor que 9 ou vazia
            else if (txtTel_CompraVenda.Text.Length < 9 | txtTel_CompraVenda.Text == "")
            {
                MessageBox.Show("Número de telemóvel incorreto", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dadosValidos = false;
            }
            else
            {
                Compra_Venda novaCompra_Venda = new Compra_Venda();

                novaCompra_Venda.Nome = txtNome_CompraVenda.Text;
                novaCompra_Venda.Tel = txtTel_CompraVenda.Text;
                novaCompra_Venda.Instrumento = cbxInstrumento_CompraVenda.Text;
                novaCompra_Venda.Marca = cbxMarca_CompraVenda.Text;
                novaCompra_Venda.Preco = txtPreco_CompraVenda.Text;

                if (cbxTipo_CompraVenda.Text == "Compra") novaCompra_Venda.Tipo = cbxTipo_CompraVenda.Text;
                if (cbxTipo_CompraVenda.Text == "Venda") novaCompra_Venda.Tipo = cbxTipo_CompraVenda.Text;

                // Caso o ficheiro XML Registo_CompraVenda exista, essa validação irá fazer a Desserialização do ficheiro,
                // adicionar a lista
                if (File.Exists("Registo_CompraVenda.xml"))
                {
                    FileStream ficheiroExistente = new FileStream("Registo_CompraVenda.xml", FileMode.Open, FileAccess.Read);
                    XmlSerializer serie_ = new XmlSerializer(typeof(List<Compra_Venda>));
                    List<Compra_Venda> listaExistente = (List<Compra_Venda>)serie_.Deserialize(ficheiroExistente);
                    Compra_Venda.Lista.Lista_CompraVenda.AddRange(listaExistente);
                    ficheiroExistente.Close();
                }


                Compra_Venda.Lista.Lista_CompraVenda.Add(novaCompra_Venda);


                //Criar uma nova instancia de filestream para escrita
                FileStream ficheiro_CompraVenda = new FileStream("Registo_CompraVenda.xml", FileMode.Create, FileAccess.Write);
                //Criar uma instancia XML do tipo Compra_Venda
                XmlSerializer serie_CompraVenda = new XmlSerializer(typeof(List<Compra_Venda>));

                serie_CompraVenda.Serialize(ficheiro_CompraVenda, Compra_Venda.Lista.Lista_CompraVenda);
                ficheiro_CompraVenda.Close();

            }

            if (dadosValidos)
            {
                txtNome_CompraVenda.Clear();
                txtTel_CompraVenda.Clear();
                txtPreco_CompraVenda.Clear();
                cbxMarca_CompraVenda.SelectedIndex = -1;
                cbxInstrumento_CompraVenda.SelectedIndex = -1;
                cbxTipo_CompraVenda.SelectedIndex = -1;
                txtDescricao.Clear();
            }

        }

        private void bttGuardarManu_Click(object sender, EventArgs e)
        {
            bool dadosValidos = true;

            if (txtNome_Manu.Text == "" || cbxInstrumentos_Manu.Text == "" || cbxDefeitos.Text == "" || txtDescricao.Text == "" || txtPreco_Manu.Text == "")
            {
                MessageBox.Show("Dados incompletos", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Validação para caso a quantidade de caracteres na textbox número seja menor que 9 ou vazia
            else if (txtTel_Manu.Text.Length < 9 | txtTel_Manu.Text == "")
            {
                MessageBox.Show("Número de telemóvel incorreto", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dadosValidos = false;
            }

            else
            {
                Manutencoes novaManutencao = new Manutencoes();

                novaManutencao.Nome = txtNome_Manu.Text;
                novaManutencao.Tel = txtTel_Manu.Text;
                novaManutencao.Instrumento = cbxInstrumentos_Manu.Text;
                novaManutencao.Defeito = cbxDefeitos.Text;
                novaManutencao.Descricao = txtDescricao.Text;
                novaManutencao.Preco = txtPreco_Manu.Text;

                // Validação para a quantidade de números inseridos na textbox Tel


                // Verifica se o arquivo XML existe antes de desserializar os dados existentes


                Manutencoes.Lista.Lista_Manu.Add(novaManutencao);

                FileStream ficheiro_Manutencoes = new FileStream("Registo_Manutencoes.xml", FileMode.Create, FileAccess.Write);
                XmlSerializer serie_Manutencoes = new XmlSerializer(typeof(List<Manutencoes>));
                serie_Manutencoes.Serialize(ficheiro_Manutencoes, Manutencoes.Lista.Lista_Manu);
                ficheiro_Manutencoes.Close();

                //Apagar todos os dados inseridos das textBox's

            }


            if (dadosValidos)
            {
                txtNome_Manu.Clear();
                txtTel_Manu.Clear();
                txtPreco_Manu.Clear();
                cbxDefeitos.SelectedIndex = -1;
                cbxInstrumentos_Manu.SelectedIndex = -1;
                txtDescricao.Clear();

            }


        }

        private void bttAtualizar_Historico_Click(object sender, EventArgs e)
        {

            try
            {

                //Conversão dos dados armazenados no ficheiro para a lista
                FileStream ficheiro = new FileStream("Registo_CompraVenda.xml", FileMode.Open, FileAccess.Read);
                XmlSerializer serie = new XmlSerializer(typeof(List<Compra_Venda>));
                Compra_Venda.Lista.Lista_CompraVenda = (List<Compra_Venda>)(serie.Deserialize(ficheiro));
                ficheiro.Close();

                dgvHistorico.Rows.Clear();
                foreach (Compra_Venda item in Compra_Venda.Lista.Lista_CompraVenda)
                {

                    dgvHistorico.Rows.Add(item.Nome, item.Tel.ToString(), item.Instrumento, item.Marca, item.Preco,
                    item.Tipo);

                }

            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Não existem dados registados", "", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void bttAtualizar_Conserto_Click(object sender, EventArgs e)
        {


            try
            {
                dgvManu.Rows.Clear();

                //Conversão dos dados armazenados no ficheiro para a lista
                FileStream ficheiro = new FileStream("Registo_Manutencoes.xml", FileMode.Open, FileAccess.Read);
                XmlSerializer serie = new XmlSerializer(typeof(List<Manutencoes>));
                Manutencoes.Lista.Lista_Manu = (List<Manutencoes>)(serie.Deserialize(ficheiro));
                ficheiro.Close();

                foreach (Manutencoes item in Manutencoes.Lista.Lista_Manu)
                {
                    dgvManu.Rows.Add(item.Nome, item.Tel.ToString(), item.Instrumento, item.Defeito,
                        item.Descricao, item.Preco);

                }

            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Não existem dados registados", "", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }



        private void cbxInstrumento_CompraVenda_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPreco_CompraVenda.Clear();
            cbxMarca_CompraVenda.Items.Clear();

            string[] pastas = Directory.GetDirectories(pasta);

            string nomeInstrumento = cbxInstrumento_CompraVenda.Text;
            string nomeArquivo = nomeInstrumento + "Dados.txt";
            string caminhoArquivo = Path.Combine(pasta, nomeInstrumento, nomeArquivo);

            List<string> marcas = new List<string>();

            if (File.Exists(caminhoArquivo))
            {
                string[] linhas = File.ReadAllLines(caminhoArquivo);
                foreach (string linha in linhas)
                {
                    string[] dados = linha.Split(':');
                    string marca = dados[0];
                    marcas.Add(marca);
                }

                cbxMarca_CompraVenda.Items.AddRange(marcas.ToArray());
                cbxMarca_CompraVenda.Enabled = true;
            }
            else if (nomeArquivo == "Dados.txt")
            {
                return;
            }
            else
            {
                MessageBox.Show("Ficheiro 'InstrumentosLista' não encontrado", "Falha", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbxMarca_CompraVenda.Enabled = false;
            }
        }

        private void cbxMarca_CompraVenda_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPreco_CompraVenda.Clear();

            string pasta = "./InstrumentosLista/";
            string nomeInstrumento = cbxInstrumento_CompraVenda.Text;
            string nomeArquivo = nomeInstrumento + "Dados.txt";
            string caminhoArquivo = Path.Combine(pasta, nomeInstrumento, nomeArquivo);
            string marcaSelecionada = cbxMarca_CompraVenda.Text;

            if (File.Exists(caminhoArquivo))
            {
                string[] linhas = File.ReadAllLines(caminhoArquivo);
                foreach (string linha in linhas)
                {
                    string[] dados = linha.Split(':');
                    string marca = dados[0];
                    string precoD = dados[1];

                    if (marca == marcaSelecionada)
                    {
                        txtPreco_CompraVenda.Text = precoD;
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Ficheiro 'InstrumentosLista' não encontrado", "Falha", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbxInstrumentos_Manu_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPreco_Manu.Enabled = true;
            txtPreco_Manu.Clear();


            if (cbxInstrumentos_Manu.SelectedIndex == 3)
            {
                List<string> list = new List<string> { "Corda partida", "Desafinação", "Outro" };
                cbxDefeitos.Items.Clear();
                cbxDefeitos.Items.AddRange(list.ToArray());
            }
            else
            {
                List<string> list = new List<string> { "Corda partida", "Outro" };
                cbxDefeitos.Items.Clear();
                cbxDefeitos.Items.AddRange(list.ToArray());
            }
        }

        private void cbxDefeitos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxInstrumentos_Manu.SelectedIndex == 0) { if (cbxDefeitos.SelectedIndex == 0) txtPreco_Manu.Text = "2,99"; }
            if (cbxInstrumentos_Manu.SelectedIndex == 1) { if (cbxDefeitos.SelectedIndex == 0) txtPreco_Manu.Text = "1,99"; }
            if (cbxInstrumentos_Manu.SelectedIndex == 2) { if (cbxDefeitos.SelectedIndex == 0) txtPreco_Manu.Text = "0,99"; }
            if (cbxInstrumentos_Manu.SelectedIndex == 3)
            {
                if (cbxDefeitos.SelectedIndex == 0) txtPreco_Manu.Text = "84,99";
                if (cbxDefeitos.SelectedIndex == 1) txtPreco_Manu.Text = "29,90";
                if (cbxDefeitos.SelectedIndex == 2) txtPreco_Manu.Clear();
            }
            if (cbxInstrumentos_Manu.SelectedIndex < 3 && cbxDefeitos.SelectedIndex == 1) txtPreco_Manu.Clear();

        }

        private void txtPreco_Manu_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica se a tecla pressionada é um número ou uma vírgula
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
            // Permite a vírgula somente uma vez na string
            if (e.KeyChar == ',' && (sender as TextBox).Text.Contains(","))
            {
                e.Handled = true;
            }
        }

        private void txtPreco_CompraVenda_KeyPress(object sender, KeyPressEventArgs e)
        {

            // Verifica se a tecla pressionada é um número ou uma vírgula
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
            // Permite a vírgula somente uma vez na string
            if (e.KeyChar == ',' && (sender as TextBox).Text.Contains(","))
            {
                e.Handled = true;
            }
        }

    }

}
