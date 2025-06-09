# Cadastro de Clientes

Este é um projeto simples em C# para cadastro de clientes, desenvolvido para fins de aprendizado. O sistema permite cadastrar, remover, listar e consultar clientes por CPF ou RG. Os dados são armazenados localmente em um arquivo binário.

## Funcionalidades

- **Cadastrar Cliente:** Adiciona um novo cliente com nome, CPF, RG e número de celular.
- **Remover Cliente:** Remove um cliente da lista pelo seu código.
- **Listar Clientes:** Exibe todos os clientes cadastrados.
- **Consultar Cliente:** Permite consultar um cliente pelo CPF ou RG.
- **Persistência:** Os dados dos clientes são salvos em um arquivo chamado `Clientes.txt`.

## Estrutura do Projeto

- `Program.cs`: Arquivo principal com a lógica do sistema.
- `FormatCnpjCpf.cs`: Contém funções utilitárias para formatação e remoção de formatação de CPF e RG.
- `Cadastro.csproj`: Arquivo de configuração do projeto.

## Como Executar

1. Abra o projeto no Visual Studio ou VS Code.
2. Compile o projeto.
3. Execute o programa. O menu principal será exibido no console.

## Observações

- O arquivo de dados `Clientes.txt` será criado automaticamente na primeira execução.
- O projeto utiliza serialização binária para salvar e carregar os dados dos clientes.

## Exemplo de Uso

```
Sistema de clientes
1 - Cadastrar Cliente
2 - Remover
3 - Listar Clientes
4 - Consultar por CPF
5 - Sair
```

---

Desenvolvido para fins didáticos.