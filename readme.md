<h2>Sistema de gerenciamento escolar</h2>
<p>
    <h3>Intu�to da aplica��o-></h3> Gerir um ambiente escolar, com n�veis de permiss�es para professores, alunos e administradores do respectivo sistema
</p>
<p>
    <h3>Link para as tarefas referentes ao projeto:</h3>
    <a href="https://miro.com/app/board/uXjVOCXx8OM=/">Link para tarefas</a>
</p>
<p>
    <h3>Diagrama do banco de dados utilizado:</h3>
    <img src="https://i.imgur.com/HLdm7DJ.png" alt="Diagrama do banco">
</p>
<p>
    <h3>Passo a passo para acessar o Postman para teste das APIs</h3>
    &nbsp;1.&nbsp;Acesse esse <a href="https://www.postman.com/red-station-999714/workspace/5e0cc1ef-7cfd-4b00-8c1f-bafb3d4d8832/overview">link</a>, e fa�a o seu cadastro  gratuito na ferramento;<br>
    &nbsp;2.&nbsp;Selecione cada um dos grupos de APIs exibidos no lado esquerdo da tela, clique nos tr�s pontos, que fica ao lado do grupo de APIs, e selecione a op��o "Create a fork" para cada grupo;<br>
    &nbsp;3.&nbsp;Na API Login, cole o texto abaixo, e fa�a a chamada da API para gerar o token de valida��o para a chamada das demais APIs:<br>
    &nbsp;&nbsp;&nbsp;&nbsp;{<br>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"email": "adm@adm.com",<br>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"password": "adm"<br>
    &nbsp;&nbsp;&nbsp;&nbsp;}<br>
    &nbsp;4.&nbsp;Em seguida, preencha o token gerado no Login para conseguir utilizar as demais APIs, preenchedo-a no Header das demais APIs, no campo "Authorization", ap�s o texto "Bearer";<br>
    &nbsp;5.&nbsp;Ao realizar a chamada de uma API, preenchendo o token gerado no passo 3, ser� poss�vel consultar todas as APIs, mesmo que a API selecionada n�o tenha dados para retornar no momento.<br>
</p>
