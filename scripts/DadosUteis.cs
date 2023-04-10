using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace M11_PROJETOFINAL.scripts
{
    public class DadosUteis
    {
        /// <summary>
        /// Adciona todo o conteúdo de um ficheiro txt a uma lista que pode ser chamada em qualquer lugar
        /// </summary>
        /// <param name="path">Caminho do fichero</param>
        /// <returns>Lista com o conteudo</returns>
        public static List<string> FileToList(string path) => File.ReadAllLines(path).Select(x => x.Trim()).ToList();

        /// <summary>
        /// Envia todo o conteudo de uma lista, para um ficheiro
        /// </summary>
        /// <param name="path">Caminho do ficheiro</param>
        /// <param name="list">Lista que pretende salvar</param>
        public static void ListToFile(string path, List<string> list) => File.WriteAllLines(path, list.ToArray());

        /// <summary>
        /// Adiciona no aoenas uma linha de informação no ficheiro
        /// </summary>
        /// <param name="path">Caminho do ficheiro</param>
        /// <param name="data">Linha de dado que pretende salavar</param>
        public static void AppendToFile(string path, string data) => File.AppendAllLines(path, new[] { data });
    }
}
