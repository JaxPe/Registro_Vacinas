# Cadastro de Pacientes

Este é um projeto simples em C# para cadastro de pacientes, desenvolvido para fins de aprendizado. O sistema permite cadastrar, remover, listar e consultar pacientes por CPF ou RG. Os dados são armazenados localmente em um arquivo binário.

## Funcionalidades

- **Cadastrar Paciente:** Adiciona um novo paciente com nome, CPF, RG e número de celular.
- **Remover Paciente:** Remove um paciente da lista pelo seu código.
- **Listar Pacientes:** Exibe todos os pacientes cadastrados.
- **Consultar Paciente:** Permite consultar um paciente pelo CPF ou RG.
- **Persistência:** Os dados dos pacientes são salvos em um arquivo chamado `Pacientes.txt`.

## Estrutura do Projeto

- `Program.cs`: Arquivo principal com a lógica do sistema.
- `FormatCnpjCpf.cs`: Contém funções utilitárias para formatação e remoção de formatação de CPF.
- `Cadastro.csproj`: Arquivo de configuração do projeto.

## Como Executar

1. Abra o projeto no Visual Studio ou VS Code.
2. Compile o projeto.
3. Execute o programa. O menu principal será exibido no console.

## Observações

- O arquivo de dados `Pacientes.txt` será criado automaticamente na primeira execução.
- O projeto utiliza serialização binária para salvar e carregar os dados dos pacientes.

## Exemplo de Uso

```
Sistema de Vacinação
1 - Cadastrar Paciente
2 - Remover
3 - Listar Pacientes
4 - Consultar por CPF
5 - Sair
```

---

Desenvolvido para fins didáticos.