using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Atividade.EfCore.Senai.Utils
{
    public static class Upload
    {
        public static string Local (IFormFile file)
        {

           
                 //gero nome unico do arquivo
                //pego a extensão do arquivo 
                //concateno o nome do arquivo com sua estensão
                var NomeArquivo = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);
                //etCurrentDirectory - pega o caminho do diretorio atual, aplicação esta
                var CaminhoArquivo = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot/Upload/Imagem", NomeArquivo);
                //cria um objeto FileStream passando o caminho do arquivo 
                //passa para criar o arquivo
                using var streamImagem = new FileStream(CaminhoArquivo, FileMode.Create);
                //executa o comando de criação do arquivo no local indicado 
                file.CopyTo(streamImagem);

                return "http://localhost:50665/Upload/Imagem/" + NomeArquivo;
       
        }
    }
}
