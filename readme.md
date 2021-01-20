<br />
<p align="center">

  <h3 align="center">RabbitMq Quinta code sample</h3>

  <p align="center">
    Projeto com a finalidade apresentar o RabbitMq e processamento em fila
    <br />
    pego como base o exemplo no tutorial do RabbitMq C# 
    <a href="https://www.rabbitmq.com/tutorials/tutorial-one-dotnet.html">Ir Para</a>
  </p>
</p>



<!-- TABLE OF CONTENTS -->
<details open="open">
  <summary><h2 style="display: inline-block">Summario</h2></summary>
  <ol>
    <li>
      <a href="#about-the-project">Sobre o projeto</a>
      <ul>
        <li><a href="#construido-com">Construido com</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
        <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li><a href="#usage">Usage</a></li>
    <li><a href="#roadmap">Roadmap</a></li>
    <li><a href="#contributing">Contributing</a></li>
    <li><a href="#license">License</a></li>
    <li><a href="#contact">Contact</a></li>
    <li><a href="#acknowledgements">Acknowledgements</a></li>
  </ol>
</details>



<!-- ABOUT THE PROJECT -->
## About The Project

projeto simples mostrando a utilização do processamento e comunicação de filas entre serviços

### Construido com

* [Docker](https://www.docker.com/products/docker-desktop)
* [RabbitMq](https://www.rabbitmq.com/download.html)
* [Visual Code](https://code.visualstudio.com/download)
* [.Net Core SDK 5.x](https://dotnet.microsoft.com/download)





<!-- GETTING STARTED -->
## Getting Started


Após as intalações do Docker **[opcional]** execute os seguinte comandos para realizar download da imagem e também iniciar os serviços
```
docker run -it --rm --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3-management
```


### Prerequisites

* Instalação do [Docker](https://www.docker.com/get-started) [opcional]

* Instalação do serviço [RabbitMq](https://www.rabbitmq.com/#getstarted), caso não tenha optado pelo uso do docker.

* Inclusão do RabbitMq Client nas dlls dos projeto

### Installation

1. Clone o repositorio
   ```sh
   git clone https://github.com/correajns/QuintaCodeRabbitMq.git
   ```
2. Install NPM packages
   ```sh
   npm install
   ```



<!-- USAGE EXAMPLES -->
## Usage

build and run 

