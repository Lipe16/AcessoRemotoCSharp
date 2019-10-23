# AcessoRemotoCSharp
Dois programas em C#, sendo um o cliente e o outro o servidor para acesso remoto

As funções presente no programa são:
 - compartilhamento da tela;
 - controle remoto da tela através do mouse(funções de teclado não disponivéis ainda);
 - escalonamento de tela.
 
 O servidor remoto recebe dados através de uma conexão via socket do cliente remoto, os dados consistem em imagens(da tela) e strings(representam comandos do mouse em um objeto json), para prever a posição do mouse são utilizadas as coordenadas do mesmo em cima da imagem que representa a tela...
 
