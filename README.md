# Parking Project

O sistema deve possuir uma interface desktop ou web para registrar as entradas, saídas e parametrizações.
Utilizar uma estrutura de armazenamento local como Arquivo, SQLite, Access, MySql, DB4, etc.
O sistema deve ser implementado em C#.
A interface pode ser Desktop ou Web.
Se possível utilizar conceitos de mercado como Entity framework, LINQ, MVC, design patterns, TDD.

## Description

Desenvolver um aplicativo simples para controle de estacionamento onde o usuário poderá registrar a entrada e saída dos veículos.

Os valores praticados pelo estacionamento devem ser parametrizados em uma tabela de preços com controle vigência. Exemplo: Valores válidos para o período de 01/01/2015 até 31/12/2015.

Utilizar a data de entrada do veículo como referência para buscar a tabela de preç os.

A tabela de preço deve contemplar o valor da hora inicial e valor para as horas adicionais.

Será cobrado metade do valor da hora inicial quando o tempo total de permanência no estacionamento for igual ou inferior a 30 minutos.

O valor da hora adicional possui uma tolerância de 10 minutos para cada 1 hora. Exemplo: 30 minutos valor R$ 1,00 | 1 hora valor R$ 2,00 | 1 hora 10 minutos valor R$ 2,00 | 1 hora e 15 minutos valor R$ 3,00 | 2 horas e 5 minutos valor R$ 3,00 | 2 horas e 15 minutos valor R$ 4,00.

Utilizar a placa do veículo como chave de busca.

## Usage

Abaixo os comandos, passo a passo para executar o projeto(exemplo no Windows 10). Em uma pasta de sua preferência digite em sequência os seguintes comandos:

```
$ git clone https://github.com/jaquiel/parking.git
```


```
$ cd parking
```

```
$ dotnet build
```

```
$ dotnet run
```

E por fim, acesse http://localhost:5000/ ou https://localhost:5001/.



