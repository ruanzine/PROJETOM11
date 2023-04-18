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
        /// É a instância singleton da classe FormInicial para poder ser usada em outras partes do programa
        /// </summary>
        public static FormInicial INSTANCE { get; private set; } = new FormInicial();

        string pasta = "./InstrumentosLista/";

        /// <summary>
        /// Construtor principal da classe FormInicial.
        /// Este construtor impõe o uso da propriedade de instância singleton e posiciona o formulário no centro da tela ao ser lançado.
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

        /// <summary>
        /// Método que é executado quando o formulário principal é carregado.
        /// Cria uma instância do FormLogin, o coloca na posição central da tela e exibe-o.
        /// Caso o diálogo retorne DialogResult.OK, o formulário principal é exibido.
        /// Caso contrário, o formulário é fechado.
        /// </summary>
        /// <param name="sender">O objeto que acionou o evento.</param>
        /// <param name="e">Os argumentos do evento.</param>
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

        /// <summary>
        /// Manipulador do evento Click do botão "Guardar Compra/Venda".
        /// Salva uma nova entrada de Compra/Venda no arquivo XML e limpa os campos do formulário se os dados forem válidos.
        /// </summary>
        /// <param name="sender">Objeto que desencadeou o evento.</param>
        /// <param name="e">Argumentos do evento.</param>
        private void bttGuardar_CompraVenda_Click(object sender, EventArgs e)
        {
            bool dadosValidos = true;

            // Verifica se todos os campos obrigatórios foram preenchidos.
            if (txtNome_CompraVenda.Text == "" || cbxInstrumento_CompraVenda.Text == ""
                || cbxMarca_CompraVenda.Text == "" || txtPreco_CompraVenda.Text == "" || cbxTipo_CompraVenda.Text == "")
            {
                // Se algum campo obrigatório não foi preenchido, exibe uma mensagem de erro.
                MessageBox.Show("Dados incompletos", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Verifica se o número de telefone tem pelo menos 9 caracteres.
            else if (txtTel_CompraVenda.Text.Length < 9 | txtTel_CompraVenda.Text == "")
            {
                // Se o número de telefone não tiver pelo menos 9 caracteres, exibe uma mensagem de erro
                MessageBox.Show("Número de telemóvel incorreto", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dadosValidos = false;
            }
            else
            {
                // Cria um novo objeto Compra_Venda e preenche seus campos com os valores dos controles do formulário.
                Compra_Venda novaCompra_Venda = new Compra_Venda();
                novaCompra_Venda.Nome = txtNome_CompraVenda.Text;
                novaCompra_Venda.Tel = txtTel_CompraVenda.Text;
                novaCompra_Venda.Instrumento = cbxInstrumento_CompraVenda.Text;
                novaCompra_Venda.Marca = cbxMarca_CompraVenda.Text;
                novaCompra_Venda.Preco = txtPreco_CompraVenda.Text;

                // Define o tipo da Compra_Venda com base na seleção do controle ComboBox
                if (cbxTipo_CompraVenda.Text == "Compra") novaCompra_Venda.Tipo = cbxTipo_CompraVenda.Text;
                if (cbxTipo_CompraVenda.Text == "Venda") novaCompra_Venda.Tipo = cbxTipo_CompraVenda.Text;

                // Adiciona a nova entrada de Compra/Venda à lista estática Lista_CompraVenda da classe Compra_Venda.
                Compra_Venda.Lista.Lista_CompraVenda.Add(novaCompra_Venda);

                // Cria um novo arquivo XML de registro de Compra/Venda e salva a lista de Compra_Venda nele.
                FileStream ficheiro_CompraVenda = new FileStream("Registo_CompraVenda.xml", FileMode.Create, FileAccess.Write);
                XmlSerializer serie_CompraVenda = new XmlSerializer(typeof(List<Compra_Venda>));
                serie_CompraVenda.Serialize(ficheiro_CompraVenda, Compra_Venda.Lista.Lista_CompraVenda);
                ficheiro_CompraVenda.Close();
            }

            // Limpa os campos do formulário se os dados forem válidos.
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


        /// <summary>
        /// Evento executado ao clicar no botão "Guardar" da manutenção, que adiciona uma nova manutenção à lista de manutenções e serializa a lista em um arquivo XML.
        /// </summary>
        /// <param name="sender">O objeto que disparou o evento</param>
        /// <param name="e">Os argumentos do evento</param
        private void bttGuardarManu_Click(object sender, EventArgs e)
        {
            bool dadosValidos = true;

            // Verifica se algum dos campos obrigatórios está vazio
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
                // Cria uma nova instância da classe Manutencoes com os dados informados pelo usuário
                Manutencoes novaManutencao = new Manutencoes();
                novaManutencao.Nome = txtNome_Manu.Text;
                novaManutencao.Tel = txtTel_Manu.Text;
                novaManutencao.Instrumento = cbxInstrumentos_Manu.Text;
                novaManutencao.Defeito = cbxDefeitos.Text;
                novaManutencao.Descricao = txtDescricao.Text;
                novaManutencao.Preco = txtPreco_Manu.Text;



                // Adiciona a nova manutenção à lista de manutenções
                Manutencoes.Lista.Lista_Manu.Add(novaManutencao);

                // Serializa a lista de manutenções em um arquivo XML
                FileStream ficheiro_Manutencoes = new FileStream("Registo_Manutencoes.xml", FileMode.Create, FileAccess.Write);
                XmlSerializer serie_Manutencoes = new XmlSerializer(typeof(List<Manutencoes>));
                serie_Manutencoes.Serialize(ficheiro_Manutencoes, Manutencoes.Lista.Lista_Manu);
                ficheiro_Manutencoes.Close();
            }

            // Limpa os campos do formulário se os dados forem válidos.
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

        /// <summary>
        /// Event handler que atualiza o histórico de compras e vendas na tabela do formulário.
        /// </summary>
        /// <param name="sender">O objeto que aciona o evento.</param>
        /// <param name="e">Os argumentos do evento.</param>
        private void bttAtualizar_Historico_Click(object sender, EventArgs e)
        {

            try
            {
                // Conversão dos dados armazenados no ficheiro para a lista de Compra_Venda.
                FileStream ficheiro = new FileStream("Registo_CompraVenda.xml", FileMode.Open, FileAccess.Read);
                XmlSerializer serie = new XmlSerializer(typeof(List<Compra_Venda>));
                Compra_Venda.Lista.Lista_CompraVenda = (List<Compra_Venda>)(serie.Deserialize(ficheiro));
                ficheiro.Close();

                // Limpa todas as linhas da DataGridView 'dgvHistorico'.
                dgvHistorico.Rows.Clear();

                // Adiciona cada item da lista 'Lista_CompraVenda' à DataGridView 'dgvHistorico', preenchendo cada célula com seus respectivos atributos.
                foreach (Compra_Venda item in Compra_Venda.Lista.Lista_CompraVenda)
                {
                    
                    dgvHistorico.Rows.Add(item.Nome, item.Tel.ToString(), item.Instrumento, item.Marca, item.Preco,
                    item.Tipo);

                }

            }
            catch (FileNotFoundException)
            {
          
                // Mostra uma caixa de mensagem de erro indicando que não existem dados registados.
                MessageBox.Show("Não existem dados registados", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }


        /// <summary>
        /// Evento que atualiza a tabela de manutenções, exibindo as informações armazenadas no arquivo XML "Registo_Manutencoes.xml"
        /// </summary>
        /// <param name="sender">O objeto que disparou o evento</param>
        /// <param name="e">Os argumentos do evento</param>
        private void bttAtualizar_Conserto_Click(object sender, EventArgs e)
        {
            

            try
            {
                // Limpa as linhas da tabela antes de exibir as informações atualizadas
                dgvManu.Rows.Clear();

                // Lê as informações armazenadas no arquivo XML "Registo_Manutencoes.xml" e as desserializa para uma lista de objetos do tipo "Manutencoes"
                FileStream ficheiro = new FileStream("Registo_Manutencoes.xml", FileMode.Open, FileAccess.Read);
                XmlSerializer serie = new XmlSerializer(typeof(List<Manutencoes>));
                Manutencoes.Lista.Lista_Manu = (List<Manutencoes>)(serie.Deserialize(ficheiro));
                ficheiro.Close();

                // Adiciona as informações da lista de manutenções na tabela
                foreach (Manutencoes item in Manutencoes.Lista.Lista_Manu)
                {
                    dgvManu.Rows.Add(item.Nome, item.Tel.ToString(), item.Instrumento, item.Defeito,
                        item.Descricao, item.Preco);

                }

            }
            catch (FileNotFoundException)
            {
                // Exibe uma mensagem de erro caso o arquivo "Registo_Manutencoes.xml" não exista
                MessageBox.Show("Não existem dados registados", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Evento que é acionado quando um item é selecionado na ComboBox de instrumentos para compra/venda. 
        /// Preenche a ComboBox de marcas com as marcas disponíveis para o instrumento selecionado.
        /// </summary>
        /// <param name="sender">Objeto que acionou o evento.</param>
        /// <param name="e">Argumentos do evento.</param>
        private void cbxInstrumento_CompraVenda_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Limpa o campo de preço e a ComboBox de marcas
            txtPreco_CompraVenda.Clear();
            cbxMarca_CompraVenda.Items.Clear();

            // Obtém a lista de pastas dentro do diretório pasta
            string[] pastas = Directory.GetDirectories(pasta);

            // Obtém o nome do instrumento selecionado na ComboBox
            string nomeInstrumento = cbxInstrumento_CompraVenda.Text;

            // Monta o caminho para o arquivo de dados do instrumento selecionado
            string nomeArquivo = nomeInstrumento + "Dados.txt";
            string caminhoArquivo = Path.Combine(pasta, nomeInstrumento, nomeArquivo);

            // Cria uma lista de marcas
            List<string> marcas = new List<string>();

            // Se o arquivo existir, lê suas linhas e adiciona as marcas à lista
            if (File.Exists(caminhoArquivo))
            {
                string[] linhas = File.ReadAllLines(caminhoArquivo);
                foreach (string linha in linhas)
                {
                    string[] dados = linha.Split(':');
                    string marca = dados[0];
                    marcas.Add(marca);
                }

                // Adiciona as marcas à ComboBox de marcas e a habilita
                cbxMarca_CompraVenda.Items.AddRange(marcas.ToArray());
                cbxMarca_CompraVenda.Enabled = true;
            }
            // Se o arquivo não existir e o nome do arquivo for "Dados.txt", não faz nada
            else if (nomeArquivo == "Dados.txt")
            {
                return;
            }
            else
            {
                // Se o arquivo não existir e o nome do arquivo não for "Instrumentos"+"Dados.txt", exibe uma mensagem de erro e desabilita a ComboBox de marcas
                MessageBox.Show("Ficheiro 'InstrumentosLista' não encontrado", "Falha", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbxMarca_CompraVenda.Enabled = false;
            }
        }

        /// <summary>
        /// Método que é executado quando a opção de marca de instrumento é selecionada.
        /// Obtém o preço correspondente à marca selecionada e o exibe no campo de preço.
        /// </summary>
        /// <param name="sender">O objeto que acionou o evento.</param>
        /// <param name="e">Os argumentos do evento.</param>
        private void cbxMarca_CompraVenda_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Limpa o campo de preço
            txtPreco_CompraVenda.Clear();

            // Obtém a lista de pastas contendo os arquivos de dados dos instrumentos
            string pasta = "./InstrumentosLista/";

            // Obtém a lista de pastas contendo os arquivos de dados dos instrumentos
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
                // Se o arquivo não existir e o nome do arquivo não for "Instrumento"+"Dados.txt", exibe uma mensagem de erro 
                MessageBox.Show("Ficheiro 'InstrumentosLista' não encontrado", "Falha", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Evento que é acionado quando o índice do item selecionado no ComboBox de instrumentos para manutenção é alterado.
        /// </summary>
        /// <param name="sender">O objeto que acionou o evento.</param>
        /// <param name="e">Os argumentos do evento.</param>
        private void cbxInstrumentos_Manu_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Habilita o campo de preço e o limpa
            txtPreco_Manu.Enabled = true;
            txtPreco_Manu.Clear();

            // Verifica se o instrumento selecionado é uma Piano
            if (cbxInstrumentos_Manu.SelectedIndex == 3)
            {
                // Se for um piano, cria uma lista de defeitos possíveis e atualiza o ComboBox de defeitos
                List<string> list = new List<string> { "Corda partida", "Desafinação", "Outro" };
                cbxDefeitos.Items.Clear();
                cbxDefeitos.Items.AddRange(list.ToArray());
            }
            else
            {
                // Se não for um piano, cria uma lista de defeitos possíveis e atualiza o ComboBox de defeitos
                List<string> list = new List<string> { "Corda partida", "Outro" };
                cbxDefeitos.Items.Clear();
                cbxDefeitos.Items.AddRange(list.ToArray());
            }
        }

        /// <summary>
        /// Evento acionado quando há uma mudança na seleção de defeitos na manutenção de instrumentos.
        /// </summary>
        /// <param name="sender">O objeto que acionou o evento.</param>
        /// <param name="e">Os argumentos do evento.</param>
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

        /// <summary>
        /// Evento que verifica se a tecla pressionada é um número ou uma vírgula.
        /// </summary>
        /// <param name="sender">Objeto que acionou o evento.</param>
        /// <param name="e">Argumento do evento que contém informações sobre a tecla pressionada.</param>
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

        /// <summary>
        /// Evento que verifica se a tecla pressionada é um número ou uma vírgula.
        /// </summary>
        /// <param name="sender">Objeto que acionou o evento.</param>
        /// <param name="e">Argumento do evento que contém informações sobre a tecla pressionada.</param>
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

    }

}
