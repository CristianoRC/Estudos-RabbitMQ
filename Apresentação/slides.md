---
theme: "night"
transition: "slide"
title: "Mensageria"
enableMenu: false
enableSearch: false
enableChalkboard: false
---

### Mensageria

![Message](https://miro.medium.com/max/1120/0*CNrhO2ApguksmRSr.png){width=100%}

---

### O que vamos falar

- **Comunicações Síncronas e Assíncronas**
- **Filas**
- **Tópicos**
- **Boas práticas na integração dos sistemas**

---

### Sistema de E-Commerce

![E-Commerce](https://accendadigital.com.br/wp-content/uploads/2020/05/accenda-ecommerce.png){width=60%}

---

### HTTP

![HTTP](./images/01-request.png)

---

### HTTP

![HTTP](./images/02-response.png)

---

### HTTP

![HTTP](./images/03-badRequest.png)

---

### É muito mais complexo que isso

![Arquitetura](./images/ms.svg)

---

### E muitas veses precisamos fazer isso de forma assíncrona

- Não temos informação na hora
- Não temos poder computacional para processar tudo na mesma hora
- ...

---

### O que fazer nesses casos então?

---

### Mensageria nos ajuda nisso

![HTTP](./images/question.svg)

---

### Principais conceitos - Producer

![HTTP](./images/05-producer.png)

---

### Principais conceitos - Producer

![HTTP](./images/06-message.png)

---

### Principais conceitos - Message Broker

![HTTP](./images/07-broker.png){width=60%}

---

### Principais conceitos - Consumer

![HTTP](./images/08-consumer.png){width=60%}

---

### Filas

![HTTP](./images/09-queue.png){width=80%}

---

### Filas - Importante

A mensagem só pode ser lida por um consumidor!

---

### Tópicos

![HTTP](./images/10-topic.png){width=90%}

---

### Tópicos - Como funciona

![HTTP](./images/11-real.png){width=100%}

---

### Exemplo com RabbitMQ

![HTTP](./images/Exemplo.png){width=80%}

---

### Exemplo com RabbitMQ

![HTTP](./images/Flow.png){width=80%}

---

### Exemplo com RabbitMQ

- Exemplo de velocidade de processamento
- Um evento chama o outro

---

### E se der problemas?

---

### Chave de idepotencia - Reprocessar

---

### Dúvidas?

![alt](https://media3.giphy.com/media/3o6MbudLhIoFwrkTQY/giphy.gif?cid=790b76117789c6161150915091725a365bdeac4e06fd01cd&rid=giphy.gif&ct=g){ width=90% }
